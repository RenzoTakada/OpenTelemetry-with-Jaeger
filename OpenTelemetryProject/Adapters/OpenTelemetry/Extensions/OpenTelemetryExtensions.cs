using Adapters.OpenTelemetry.Settings;

using OpenTelemetry.Exporter;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System.Configuration;

namespace Adapters.OpenTelemetry.Extensions
{
    public static class OpenTelemetryExtensions
    {


        public static IServiceCollection AddpenTelemetryAdapter(this IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                       .Build();
            services.Configure<OpenTelemetrySettings>(options => configuration.GetSection("OpenTelemetry").Bind(options));
            var settings = new OpenTelemetrySettings()
            {
                ServiceName = "OpentelemetryTeste",
                ServiceVersion = "1.0",
                Endpoint = "http://localhost:5775/",
                IsEnabled = true,
            };
            //var settings = new OpenTelemetrySettings();
            //configuration.Bind("OpenTelemetry", settings);



            Console.WriteLine("Teste");
            Console.WriteLine(settings.ServiceName);
            Console.WriteLine(settings.ServiceVersion);
            Console.WriteLine(settings.Endpoint);
            Console.WriteLine(settings.IsEnabled);
            if (settings.IsEnabled == true)
            {

                services.AddOpenTelemetryTracing(opentelemetry =>
        {
            var resourceBuilder = ResourceBuilder
                .CreateDefault()
                .AddService(settings.ServiceName);
            opentelemetry.AddSource(settings.ServiceName)
                .SetResourceBuilder(ResourceBuilder.CreateDefault()
                 .AddService(serviceName: settings.ServiceName, serviceVersion: settings.ServiceVersion))


                .AddJaegerExporter(jaegerOptions =>
                {

                    jaegerOptions.Endpoint = new Uri($"{settings.Endpoint}");
                })
                .AddHttpClientInstrumentation()
                .AddAspNetCoreInstrumentation()
                .AddConsoleExporter();

            //opentelemetry.AddSource(settings.ServiceName)
            //    .SetResourceBuilder(resourceBuilder)
            //    .SetSampler(new AlwaysOnSampler())
            //    .AddConsoleExporter()
            //    .AddHttpClientInstrumentation()


            //    .AddJaegerExporter(jaegerOptions =>
            //    {
            //        jaegerOptions.Protocol = JaegerExportProtocol.HttpBinaryThrift;
            //        jaegerOptions.Endpoint = new Uri($"{settings.Endpoint}");
            //    });


        });
                return services;
            }
            else
            {
                throw new Exception("error");
            }

        }

    }
}
