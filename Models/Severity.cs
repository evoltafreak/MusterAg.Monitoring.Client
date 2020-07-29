using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class Severity
    {
        public Severity()
        {
            Logging = new HashSet<Logging>();
        }

        public int IdSeverity { get; set; }
        public string Severity1 { get; set; }

        public virtual ICollection<Logging> Logging { get; set; }
    }
}
