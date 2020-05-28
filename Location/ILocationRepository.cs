using System.Collections.Generic;
using MusterAg.Monitoring.Client.Model;

namespace MusterAg.Monitoring.Client.Repository
{
    public interface ILocationRepository
    {
        public long Count();
        public List<Location> ReadAllLocationList();
        public string ConnectionString { get; set; }
    }
}