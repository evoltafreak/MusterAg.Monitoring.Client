using System.Collections.Generic;
using MusterAg.Monitoring.Client.Model;

namespace MusterAg.Monitoring.Client.Repository
{
    public interface IPodRepository
    {
        public List<Pod> ReadPodList();
        public string ConnectionString { get; set; }
    }
}