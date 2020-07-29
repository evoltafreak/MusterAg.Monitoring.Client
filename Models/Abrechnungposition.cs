using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class Abrechnungposition
    {
        public int IdAbrechnungPosition { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Time { get; set; }
        public int FidPositionType { get; set; }

        public virtual Positiontype FidPositionTypeNavigation { get; set; }
    }
}
