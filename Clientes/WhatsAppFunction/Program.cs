using Clientes.Models;
using Clientes.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration((context, builder) =>
    {
        builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .AddEnvironmentVariables();
    })
    .ConfigureServices((context, services) =>
    {
        services.AddHttpClient();
        services.AddDbContext<ClientesContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("Produccion")));
        services.AddScoped<WhatsAppService>();
        services.AddScoped<WhatsAppConfigService>();
        services.AddScoped<WhatsAppNotificationProcessor>();
    })
    .Build();

await host.RunAsync();