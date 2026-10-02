using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clientes.Models;
using Clientes.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Clientes.Controllers
{
    [Route("api/whatsapp")]
    [ApiController]
    public class WhatsAppController : ControllerBase
    {
        private readonly WhatsAppService _whatsApp;
        private readonly WhatsAppConfigService _config;
        private readonly WhatsAppNotificationProcessor _processor;
        private readonly IConfiguration _configuration;

        public WhatsAppController(WhatsAppService whatsApp, WhatsAppConfigService config,
            WhatsAppNotificationProcessor processor, IConfiguration configuration)
        {
            _whatsApp = whatsApp;
            _config = config;
            _processor = processor;
            _configuration = configuration;
        }

        [HttpPost("test")]
        public async Task<IActionResult> Test([FromBody] WhatsAppTestRequest request)
        {
            if (!Autorizado()) return Unauthorized();
            if (request == null || string.IsNullOrWhiteSpace(request.Telefono))
                return BadRequest("Telefono es requerido.");
            var config = _config.Obtener();
            if (config == null) return NotFound("No existe configuración.");
            var result = await _whatsApp.EnviarNotificacionAsync(config, request.Telefono,
                string.IsNullOrWhiteSpace(request.Plantilla) ? config.PlantillaAvisoPrevioNombre : request.Plantilla,
                request.Parametros ?? new List<string> { config.ServicioNombre, config.PrecioActual.ToString("0.00") },
                string.IsNullOrWhiteSpace(request.ImagenUrl) ? config.HeaderImagenUrlAvisoPrevio : request.ImagenUrl,
                request.Idioma ?? config.MetaLanguageCode);
            return result.Enviado ? Ok(new { success = true, meta = result.Detalle }) : StatusCode(502, new { success = false, message = result.Detalle, metaStatus = result.StatusCode });
        }

        [HttpPost("run")]
        public async Task<ActionResult<NotificationRunResult>> Run()
        {
            if (!Autorizado()) return Unauthorized();
            return Ok(await _processor.ProcesarAsync());
        }

        [HttpGet("config")]
        public ActionResult<WhatsAppConfig> GetConfig()
        {
            if (!Autorizado()) return Unauthorized();
            var config = _config.Obtener();
            if (config == null) return NotFound();
            config.MetaAccessToken = null;
            return Ok(config);
        }

        [HttpPut("config")]
        public ActionResult<WhatsAppConfig> PutConfig([FromBody] WhatsAppConfig config)
        {
            if (!Autorizado()) return Unauthorized();
            if (config == null) return BadRequest();
            var saved = _config.Guardar(config);
            saved.MetaAccessToken = null;
            return Ok(saved);
        }

        private bool Autorizado()
        {
            var expected = _configuration["WhatsApp:AdminKey"];
            return !string.IsNullOrWhiteSpace(expected) &&
                Request.Headers.TryGetValue("X-WhatsApp-Admin-Key", out var provided) &&
                string.Equals(provided.ToString(), expected, StringComparison.Ordinal);
        }
    }

    public class WhatsAppTestRequest
    {
        public string Telefono { get; set; }
        public string Plantilla { get; set; }
        public List<string> Parametros { get; set; }
        public string ImagenUrl { get; set; }
        public string Idioma { get; set; }
    }
}