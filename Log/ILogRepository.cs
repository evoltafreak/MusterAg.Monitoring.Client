using System.Collections.Generic;
using MusterAg.Monitoring.Client.Models;

namespace MusterAg.Monitoring.Client.Repository
{
    public interface ILogRepository
    {
        List<VLogentries> ReadLogList();
        void ClearLog(long id);
        void AddLog(VLogentries log);
    }
}