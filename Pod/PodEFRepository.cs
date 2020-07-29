using System.Collections.Generic;
using System.Linq;
using MusterAg.Monitoring.Client.Models;

namespace MusterAg.Monitoring.Client.Repository
{
    public class PodEFRepository
    {

        public List<Pod> ReadPodList()
        {
            using (var ctx = new musteragContext())
            {
                return ctx.Pod.ToList();
            }
        }

    }
}