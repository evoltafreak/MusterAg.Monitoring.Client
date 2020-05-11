using System;

namespace MusterAg.Monitoring.Client.Model
{
    public class Log
    {
        public long IdPod { get; set; }
        public string Pod { get; set; }
        public string Location { get; set; }
        public string Hostname { get; set; }
        public Severity Severity { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
    }
}