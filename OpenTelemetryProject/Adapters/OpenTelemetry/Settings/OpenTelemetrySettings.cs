using System.Text.Json;

namespace Adapters.OpenTelemetry.Settings
{
    public record OpenTelemetrySettings
    {
        public string ServiceName { get; set; }
        public string ServiceVersion { get; set; }
        public string Endpoint { get; set; }
        public string AgentHost { get; set; }
        public int AgentPort { get; set; }
        public bool IsEnabled { get; set; }




    }
}
