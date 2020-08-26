using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using MusterAg.Monitoring.Client.Model;

namespace MusterAg.Monitoring.Client.Repository
{
    public class SeverityLinqRepository : BaseLinqRepository<SeverityEntity>
    {
        public SeverityLinqRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<Severity> ReadSeverityList()
        {
            List<Severity> severityList = new List<Severity>();
            using (var ctx = new DataContext("MusterAgDb")) {
                ITable<SeverityEntity> severityTable = ctx.GetTable<SeverityEntity>();
                IQueryable<SeverityEntity> query = severityTable;
                foreach (SeverityEntity severityEntity in query)
                {
                    Severity severity = (Severity) Enum.Parse(typeof(Severity), severityEntity.Severity);
                    severityList.Add(severity);
                }
            }
            return severityList;
        }
        
        public override string TableName => "Severity";
        
    }
}