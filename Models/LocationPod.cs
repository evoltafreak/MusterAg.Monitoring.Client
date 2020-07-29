using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class LocationPod
    {
        public int FidLocation { get; set; }
        public int FidPod { get; set; }

        public virtual Location FidLocationNavigation { get; set; }
        public virtual Pod FidPodNavigation { get; set; }
    }
}
