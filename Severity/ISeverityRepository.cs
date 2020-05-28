using System.Collections.Generic;
using MusterAg.Monitoring.Client.Model;

namespace MusterAg.Monitoring.Client.Repository
{
    public interface ISeverityRepository
    {
        public List<Severity> ReadSeverityList();
        public string ConnectionString { get; set; }
    }
}