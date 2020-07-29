using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class Pod
    {
        public Pod()
        {
            Abrechnung = new HashSet<Abrechnung>();
            Device = new HashSet<Device>();
        }

        public int IdPod { get; set; }
        public string Description { get; set; }
        public decimal? BillLimit { get; set; }
        public decimal? Credit { get; set; }
        public int FidCustomer { get; set; }

        public virtual Customer FidCustomerNavigation { get; set; }
        public virtual ICollection<Abrechnung> Abrechnung { get; set; }
        public virtual ICollection<Device> Device { get; set; }
    }
}
