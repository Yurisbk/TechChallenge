using Prometheus;
using System.Diagnostics;

namespace TechChallenge_ControleContatos.Prometheus
{


    public class MetricsService
    {
        private static readonly Gauge ProcessUptimeGauge = Metrics
            .CreateGauge("process_uptime_seconds", "Process uptime in seconds");

        private static readonly Gauge MemoryUsageGauge = Metrics
            .CreateGauge("process_memory_usage_bytes", "Current process memory usage in bytes");

        private static readonly Stopwatch ProcessUptimeStopwatch = Stopwatch.StartNew();

        public MetricsService()
        {
            // Atualizar as métricas periodicamente
            var updateInterval = TimeSpan.FromSeconds(10);
            var timer = new Timer(UpdateMetrics, null, TimeSpan.Zero, updateInterval);
        }

        private void UpdateMetrics(object state)
        {
            ProcessUptimeGauge.Set(ProcessUptimeStopwatch.Elapsed.TotalSeconds);
            MemoryUsageGauge.Set(Process.GetCurrentProcess().WorkingSet64);
        }
    }

}
