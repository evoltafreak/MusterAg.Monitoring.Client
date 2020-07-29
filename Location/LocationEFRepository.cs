using System.Collections.Generic;
using System.Linq;
using MusterAg.Monitoring.Client.Models;

namespace MusterAg.Monitoring.Client.Repository
{
    public class LocationEFRepository
    {

        public long Count()
        {
            using (var ctx = new musteragContext())
            {
                return ctx.Location.Count();
            }
        }

        public List<Location> ReadAllLocationList()
        {
            using (var ctx = new musteragContext())
            {
                return ctx.Location.ToList();
            }
        }

    }

}