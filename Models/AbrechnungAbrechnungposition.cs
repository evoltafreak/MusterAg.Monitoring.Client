using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class AbrechnungAbrechnungposition
    {
        public int FidAbrechnung { get; set; }
        public int FidAbrechnungPosition { get; set; }

        public virtual Abrechnung FidAbrechnungNavigation { get; set; }
        public virtual Abrechnungposition FidAbrechnungPositionNavigation { get; set; }
    }
}
