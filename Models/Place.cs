using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class Place
    {
        public Place()
        {
            Location = new HashSet<Location>();
        }

        public int IdPlace { get; set; }
        public string ZipCode { get; set; }
        public string Place1 { get; set; }
        public string Canton { get; set; }
        public string CantonAbb { get; set; }

        public virtual ICollection<Location> Location { get; set; }
    }
}
