using MusterAg.Monitoring.Client.Models;

namespace MusterAg.Monitoring.Client
{
    public interface ILogViewModel
    {
        VLogentries Log { get; set; }
        void LoadData();
        void ReadSeverityList();
        void ReadPodList();
        void AddLog();
    }
}