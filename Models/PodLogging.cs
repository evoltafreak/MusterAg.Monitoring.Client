using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class PodLogging
    {
        public int FidPod { get; set; }
        public int FidLogging { get; set; }

        public virtual Logging FidLoggingNavigation { get; set; }
        public virtual Pod FidPodNavigation { get; set; }
    }
}
