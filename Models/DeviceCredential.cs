using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class DeviceCredential
    {
        public int FidDevice { get; set; }
        public int FidCredential { get; set; }

        public virtual Credential FidCredentialNavigation { get; set; }
        public virtual Device FidDeviceNavigation { get; set; }
    }
}
