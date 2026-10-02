using System;
using System.Linq;
using Clientes.Models;

namespace Clientes.Services
{
    public class WhatsAppConfigService
    {
        private readonly ClientesContext _db;

        public WhatsAppConfigService(ClientesContext db)
        {
            _db = db;
        }

        public WhatsAppConfig Obtener()
        {
            return _db.WhatsAppConfig.OrderBy(x => x.Id).FirstOrDefault();
        }

        public WhatsAppConfig Guardar(WhatsAppConfig data)
        {
            var config = Obtener();
            if (config == null)
            {
                config = new WhatsAppConfig();
                _db.WhatsAppConfig.Add(config);
            }

            config.ServicioNombre = data.ServicioNombre?.Trim();
            config.PrecioActual = data.PrecioActual;
            config.DiasAnticipacion = Math.Max(0, data.DiasAnticipacion);
            config.HeaderImagenUrlAvisoPrevio = data.HeaderImagenUrlAvisoPrevio?.Trim();
            config.HeaderImagenUrlDiaVencimiento = data.HeaderImagenUrlDiaVencimiento?.Trim();
            config.EnvioAutomaticoActivo = data.EnvioAutomaticoActivo;
            config.MetaPhoneNumberId = data.MetaPhoneNumberId?.Trim();
            // Un PUT desde el panel no debe borrar el secreto existente si no lo incluye.
            if (!string.IsNullOrWhiteSpace(data.MetaAccessToken))
                config.MetaAccessToken = data.MetaAccessToken.Trim();
            config.MetaVersion = string.IsNullOrWhiteSpace(data.MetaVersion) ? "v20.0" : data.MetaVersion.Trim();
            config.MetaLanguageCode = string.IsNullOrWhiteSpace(data.MetaLanguageCode) ? "es_AR" : data.MetaLanguageCode.Trim();
            config.PlantillaAvisoPrevioNombre = data.PlantillaAvisoPrevioNombre?.Trim();
            config.PlantillaDiaVencimientoNombre = data.PlantillaDiaVencimientoNombre?.Trim();
            _db.SaveChanges();
            return config;
        }
    }
}