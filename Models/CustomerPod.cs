using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class CustomerPod
    {
        public int FidCustomer { get; set; }
        public int FidPod { get; set; }
        public short Priority { get; set; }

        public virtual Customer FidCustomerNavigation { get; set; }
        public virtual Pod FidPodNavigation { get; set; }
    }
}
