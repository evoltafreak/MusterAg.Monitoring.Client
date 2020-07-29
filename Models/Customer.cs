using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Pod = new HashSet<Pod>();
        }

        public int IdCustomer { get; set; }
        public string Gender { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public int FidLocation { get; set; }

        public virtual Location FidLocationNavigation { get; set; }
        public virtual ICollection<Pod> Pod { get; set; }
    }
}
