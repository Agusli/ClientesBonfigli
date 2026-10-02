using System;

namespace Clientes.Models
{
    public class WhatsAppConfig
    {
        public int Id { get; set; }
        public string ServicioNombre { get; set; }
        public decimal PrecioActual { get; set; }
        public int DiasAnticipacion { get; set; } = 1;
        public string HeaderImagenUrlAvisoPrevio { get; set; }
        public string HeaderImagenUrlDiaVencimiento { get; set; }
        public bool EnvioAutomaticoActivo { get; set; } = true;
        
        // Meta API Settings (Podrían estar en appsettings, pero aquí permiten cambios rápidos)
        public string MetaPhoneNumberId { get; set; }
        public string MetaAccessToken { get; set; }
        public string MetaVersion { get; set; } = "v20.0";
        public string MetaLanguageCode { get; set; } = "es_AR";
        public string PlantillaAvisoPrevioNombre { get; set; }
        public string PlantillaDiaVencimientoNombre { get; set; }
    }
}
