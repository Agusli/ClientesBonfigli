using Clientes.Services;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace WhatsAppFunction;

public class WhatsAppTimerFunction
{
    private readonly WhatsAppNotificationProcessor _processor;
    private readonly ILogger<WhatsAppTimerFunction> _logger;

    public WhatsAppTimerFunction(WhatsAppNotificationProcessor processor, ILogger<WhatsAppTimerFunction> logger)
    {
        _processor = processor;
        _logger = logger;
    }

    [Function("WhatsAppExpirationNotifications")]
    public async Task Run([TimerTrigger("%WhatsAppTimerSchedule%")] TimerInfo timer)
    {
        _logger.LogInformation("Iniciando proceso WhatsApp. Ejecución programada: {NextRun}", timer.ScheduleStatus?.Next);
        var result = await _processor.ProcesarAsync();
        _logger.LogInformation("Proceso WhatsApp finalizado. Enviados: {Enviados}; fallidos: {Fallidos}; sin teléfono: {SinTelefono}; desactivado: {Desactivado}",
            result.Enviados, result.Fallidos, result.OmitidosSinTelefono, result.OmitidoPorConfiguracion);
    }
}