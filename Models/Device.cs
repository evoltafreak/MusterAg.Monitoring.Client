using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class Device
    {
        public Device()
        {
            Networkinterface = new HashSet<Networkinterface>();
        }

        public int IdDevice { get; set; }
        public string Description { get; set; }
        public short IsPhysical { get; set; }
        public string Hostname { get; set; }
        public string IpAddress { get; set; }
        public int FidLocation { get; set; }
        public int? Maxcapacity { get; set; }
        public int FidPod { get; set; }
        public int FidCategories { get; set; }

        public virtual Categories FidCategoriesNavigation { get; set; }
        public virtual Location FidLocationNavigation { get; set; }
        public virtual Pod FidPodNavigation { get; set; }
        public virtual ICollection<Networkinterface> Networkinterface { get; set; }
    }
}
