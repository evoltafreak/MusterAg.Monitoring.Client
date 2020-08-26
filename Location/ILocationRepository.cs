using System.Collections.Generic;
using MusterAg.Monitoring.Client.Models;

namespace MusterAg.Monitoring.Client.Repository
{
    public interface ILocationRepository
    {
        long Count();
        List<Location> ReadAllLocationList();
        List<LocTree> ReadLocTree();
    }
}