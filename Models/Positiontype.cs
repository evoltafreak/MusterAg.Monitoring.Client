using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class Positiontype
    {
        public Positiontype()
        {
            Abrechnungposition = new HashSet<Abrechnungposition>();
        }

        public int IdPositionType { get; set; }
        public string PositionType1 { get; set; }

        public virtual ICollection<Abrechnungposition> Abrechnungposition { get; set; }
    }
}
