using System.Collections.Generic;
using System.Linq;
using MusterAg.Monitoring.Client.Models;

namespace MusterAg.Monitoring.Client.Repository
{
    public class SeverityEFRepository
    {

        public List<Severity> ReadSeverityList()
        {
            using (var ctx = new musteragContext())
            {
                return ctx.Severity.ToList();
            }
        }

    }
}