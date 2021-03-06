﻿using System.Collections.Generic;
using System.Linq;
using MusterAg.Monitoring.Client.Models;

namespace MusterAg.Monitoring.Client.Repository
{

    public class LocationEFRepository : ILocationRepository
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
        
        public List<LocTree> ReadLocTree()
        {
            using (var ctx = new musteragContext())
            {
                return ctx.LocTree.OrderBy(lo => lo.Lvl).ToList();
            }
        }

    }

}