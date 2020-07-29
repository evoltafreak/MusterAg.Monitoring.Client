using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class Networkinterface
    {
        public int IdNetworkInterface { get; set; }
        public string Description { get; set; }
        public int FidNetworkInterfaceMode { get; set; }
        public int FidDevice { get; set; }
        public short IsPhysical { get; set; }

        public virtual Device FidDeviceNavigation { get; set; }
        public virtual Networkinterfacemode FidNetworkInterfaceModeNavigation { get; set; }
    }
}
