using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class Networkinterfacemode
    {
        public Networkinterfacemode()
        {
            Networkinterface = new HashSet<Networkinterface>();
        }

        public int IdNetworkinterfaceMode { get; set; }
        public string NetworkinterfaceMode1 { get; set; }
        public string Speed { get; set; }

        public virtual ICollection<Networkinterface> Networkinterface { get; set; }
    }
}
