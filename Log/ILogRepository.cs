using System.Collections.Generic;
using MusterAg.Monitoring.Client.Model;

namespace MusterAg.Monitoring.Client.Repository
{
    public interface ILogRepository
    {
        public List<Log> ReadLogList();
        public void ClearLog(long id);
        public void AddLog(Log log);
        public string ConnectionString { get; set; }
    }
}