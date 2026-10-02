using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Clientes.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Clientes.Services
{
    public class WhatsAppService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<WhatsAppService> _logger;

        public WhatsAppService(IHttpClientFactory httpClientFactory, ILogger<WhatsAppService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        
        public async Task<WhatsAppSendResult> EnviarNotificacionAsync(WhatsAppConfig config, string telefono, string plantillaNombre, List<string> bodyParams = null, string imageUrl = null, string languageCode = null)
        {
            try
            {
                var telefonoNormalizado = NormalizarTelefono(telefono);
                if (string.IsNullOrEmpty(telefonoNormalizado))
                {
                    _logger.LogWarning("Teléfono inválido: {Telefono}", telefono);
                    return WhatsAppSendResult.Failure("Teléfono inválido.");
                }

                var client = _httpClientFactory.CreateClient();
                var url = $"https://graph.facebook.com/{config.MetaVersion}/{config.MetaPhoneNumberId}/messages";

                var components = new List<object>();
                if (!string.IsNullOrWhiteSpace(imageUrl))
                {
                    components.Add(new
                    {
                        type = "header",
                        parameters = new List<object>
                        {
                            new { type = "image", image = new { link = imageUrl } }
                        }
                    });
                }

                if (bodyParams != null && bodyParams.Count > 0)
                {
                    var parameters = new List<object>();
                    foreach (var param in bodyParams)
                        parameters.Add(new { type = "text", text = param ?? string.Empty });
                    components.Add(new { type = "body", parameters });
                }

                var payload = new
                {
                    messaging_product = "whatsapp",
                    to = telefonoNormalizado,
                    type = "template",
                    template = new
                    {
                        name = plantillaNombre,
                        language = new { code = string.IsNullOrWhiteSpace(languageCode) ? (string.IsNullOrWhiteSpace(config.MetaLanguageCode) ? "es_AR" : config.MetaLanguageCode) : languageCode },
                        components
                    }
                };

                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.MetaAccessToken);

                _logger.LogInformation("Enviando WhatsApp a {Telefono} usando plantilla {Plantilla}", telefonoNormalizado, plantillaNombre);

                var response = await client.PostAsync(url, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("WhatsApp enviado con éxito a {Telefono}. Respuesta: {Respuesta}", telefonoNormalizado, responseContent);
                    return WhatsAppSendResult.Success(responseContent);
                }
                else
                {
                    _logger.LogError("Error al enviar WhatsApp a {Telefono}. Status: {Status}. Respuesta: {Respuesta}", 
                        telefonoNormalizado, response.StatusCode, responseContent);
                    return WhatsAppSendResult.Failure(responseContent, (int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al enviar WhatsApp a {Telefono}", telefono);
                return WhatsAppSendResult.Failure(ex.Message);
            }
        }

        public string NormalizarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono)) return null;

            // Eliminar todo lo que no sea dígito
            var soloDigitos = System.Text.RegularExpressions.Regex.Replace(telefono, @"\D", "");

            if (string.IsNullOrEmpty(soloDigitos)) return null;

            // Lógica para Argentina
            // Argentina: quitar prefijo de discado nacional 0.
            while (soloDigitos.StartsWith("0")) soloDigitos = soloDigitos.Substring(1);

            // Si tiene 10 dígitos (ej: 1122334455), es un número local sin prefijo de país
            if (soloDigitos.Length == 10)
            {
                soloDigitos = "549" + soloDigitos;
            }
            // Si tiene 11 dígitos y empieza con 15 (ej: 151122334455), quitar el 15 y poner 549
            else if (soloDigitos.Length == 12 && soloDigitos.StartsWith("5415"))
            {
                soloDigitos = "549" + soloDigitos.Substring(4);
            }
            else if (soloDigitos.Length == 11 && soloDigitos.StartsWith("15"))
            {
                soloDigitos = "549" + soloDigitos.Substring(2);
            }
            // Si ya tiene prefijo internacional 54, conservar exactamente el formato
            // entregado por el operador/Meta. No insertar 9 automáticamente: algunas
            // cuentas de prueba o líneas registradas por Meta se expresan como 54 + área
            // + abonado, sin el 9 móvil visible.
            // Si no tiene prefijo internacional, asumimos 549
            else if (!soloDigitos.StartsWith("54") && soloDigitos.Length > 7 && soloDigitos.Length < 11)
            {
                soloDigitos = "549" + soloDigitos;
            }

            return soloDigitos.Length >= 8 ? soloDigitos : null;
        }
    }

    public class WhatsAppSendResult
    {
        public bool Enviado { get; private set; }
        public string Detalle { get; private set; }
        public int? StatusCode { get; private set; }

        public static WhatsAppSendResult Success(string detail) => new WhatsAppSendResult { Enviado = true, Detalle = detail };
        public static WhatsAppSendResult Failure(string detail, int? statusCode = null) => new WhatsAppSendResult { Enviado = false, Detalle = detail, StatusCode = statusCode };
    }
}
