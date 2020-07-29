using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class LocTree
    {
        public int IdLocation { get; set; }
        public string Address { get; set; }
        public string AddressNr { get; set; }
        public int Parent { get; set; }
        public int Lvl { get; set; }
    }
}
