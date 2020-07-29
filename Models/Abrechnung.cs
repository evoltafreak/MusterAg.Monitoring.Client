using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class Abrechnung
    {
        public int IdAbrechnung { get; set; }
        public short IsPaid { get; set; }
        public decimal? Bill { get; set; }
        public int FidPod { get; set; }

        public virtual Pod FidPodNavigation { get; set; }
    }
}
