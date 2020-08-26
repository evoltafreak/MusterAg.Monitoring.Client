using System.Collections.ObjectModel;
using MusterAg.Monitoring.Client.Models;

namespace MusterAg.Monitoring.Client
{
    public interface IMainViewModel
    {
        void ReadLogList();
        void ClearLog(long id);
        string FindDuplicates();
        string ShowAllLocation();
        ObservableCollection<VLogentries> LogList { get; set; }
        
    }
}