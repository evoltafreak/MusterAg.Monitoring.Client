using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Device = new HashSet<Device>();
        }

        public int IdCategories { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Device> Device { get; set; }
    }
}
