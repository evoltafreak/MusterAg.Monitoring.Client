using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class Logging
    {
        public int IdLogging { get; set; }
        public DateTime Timestamp { get; set; }
        public byte[] Message { get; set; }
        public int FidSeverity { get; set; }

        public virtual Severity FidSeverityNavigation { get; set; }
    }
}
