using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using MusterAg.Monitoring.Client.Model;

namespace MusterAg.Monitoring.Client.Repository
{
    public class PodLinqRepository : BaseLinqRepository<Pod>
    {
        public PodLinqRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<Pod> ReadPodList()
        {
            List<Pod> podList = new List<Pod>();
            using (var ctx = new DataContext("MusterAgDb")) {

                ITable<PodEntity> podTable = ctx.GetTable<PodEntity>();
                IQueryable<PodEntity> query = podTable;
                foreach (PodEntity podEntity in query) {
                    Pod pod = new Pod(podEntity);
                    podList.Add(pod);
                }
     
            }
            return podList;
        }
        
        public override string TableName => "Pod";
        
    }
}