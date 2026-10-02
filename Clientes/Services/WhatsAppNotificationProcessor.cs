using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Clientes.Models;
using Microsoft.Extensions.Logging;

namespace Clientes.Services
{
    public class WhatsAppNotificationProcessor
    {
        private readonly ClientesContext _db;
        private readonly WhatsAppService _whatsApp;
        private readonly WhatsAppConfigService _configService;
        private readonly ILogger<WhatsAppNotificationProcessor> _logger;

        public WhatsAppNotificationProcessor(ClientesContext db, WhatsAppService whatsApp,
            WhatsAppConfigService configService, ILogger<WhatsAppNotificationProcessor> logger)
        {
            _db = db;
            _whatsApp = whatsApp;
            _configService = configService;
            _logger = logger;
        }

        public async Task<NotificationRunResult> ProcesarAsync(DateTime? utcNow = null)
        {
            var config = _configService.Obtener();
            if (config == null)
                throw new InvalidOperationException("No existe configuración de WhatsApp.");
            if (!config.EnvioAutomaticoActivo)
                return new NotificationRunResult { OmitidoPorConfiguracion = true };

            ValidarConfig(config);
            var now = utcNow ?? DateTime.UtcNow;
            var today = now.Date;
            var targetDate = today.AddDays(config.DiasAnticipacion);
            var clientes = _db.Clientes.Where(x => x.VencimientoC.HasValue &&
                (x.VencimientoC.Value.Date == today || x.VencimientoC.Value.Date == targetDate)).ToList();
            var result = new NotificationRunResult();

            foreach (var cliente in clientes)
            {
                if (string.IsNullOrWhiteSpace(cliente.Telefono))
                {
                    _logger.LogWarning("Cliente {ClienteId} no tiene teléfono; se omite.", cliente.Id);
                    result.OmitidosSinTelefono++;
                    continue;
                }

                var vencimiento = cliente.VencimientoC.Value.Date;
                var esHoy = vencimiento == today;
                var yaEnviado = esHoy ? cliente.UltimoAvisoVencimientoUTC : cliente.UltimoAvisoPrevioUTC;
                if (yaEnviado.HasValue && yaEnviado.Value.Date == today)
                    continue;

                var sendResult = await _whatsApp.EnviarNotificacionAsync(config, cliente.Telefono,
                    esHoy ? config.PlantillaDiaVencimientoNombre : config.PlantillaAvisoPrevioNombre,
                    esHoy ? null : new List<string> { config.ServicioNombre, config.PrecioActual.ToString("0.00", CultureInfo.InvariantCulture) },
                    esHoy ? config.HeaderImagenUrlDiaVencimiento : config.HeaderImagenUrlAvisoPrevio);

                if (!sendResult.Enviado) { result.Fallidos++; continue; }
                if (esHoy) cliente.UltimoAvisoVencimientoUTC = now;
                else cliente.UltimoAvisoPrevioUTC = now;
                result.Enviados++;
            }

            if (result.Enviados > 0) _db.SaveChanges();
            return result;
        }

        private static void ValidarConfig(WhatsAppConfig config)
        {
            if (string.IsNullOrWhiteSpace(config.MetaPhoneNumberId) || string.IsNullOrWhiteSpace(config.MetaAccessToken))
                throw new InvalidOperationException("Faltan MetaPhoneNumberId o MetaAccessToken.");
            if (string.IsNullOrWhiteSpace(config.PlantillaAvisoPrevioNombre) || string.IsNullOrWhiteSpace(config.PlantillaDiaVencimientoNombre))
                throw new InvalidOperationException("Faltan los nombres de las plantillas de Meta.");
        }
    }

    public class NotificationRunResult
    {
        public int Enviados { get; set; }
        public int Fallidos { get; set; }
        public int OmitidosSinTelefono { get; set; }
        public bool OmitidoPorConfiguracion { get; set; }
    }
}