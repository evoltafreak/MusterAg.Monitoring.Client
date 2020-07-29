using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class Credential
    {
        public int IdCredential { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
    }
}
