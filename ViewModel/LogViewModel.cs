using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MusterAg.Monitoring.Client.Model;
using MusterAg.Monitoring.Client.Repository;

namespace MusterAg.Monitoring.Client
{
    public class LogViewModel : INotifyPropertyChanged
    {
        public Log log;
        public Log Log
        {
            get
            {
                return log;
            }
            set
            {
                log = value;
                OnPropertyChanged(this, nameof(Log));
            }
        }
        public ObservableCollection<Severity> SeverityList { get; set; }
        public ObservableCollection<Pod> PodList { get; set; }

        private readonly LogRepository _logRepository;
        private readonly SeverityRepository _severityRepository;
        private readonly PodRepository _podRepository;

        public LogViewModel(string connectionString)
        {
            _logRepository = new LogRepository(connectionString);
            _severityRepository = new SeverityRepository(connectionString);
            _podRepository = new PodRepository(connectionString);
            LoadData();
        }

        private void LoadData()
        {
            ReadLogList();
            ReadPodList();
            Log = new Log();
        }
        
        public void ReadLogList()
        {
            SeverityList = new ObservableCollection<Severity>(_severityRepository.ReadSeverityList());
            OnPropertyChanged(this, nameof(SeverityList));
        }
        
        public void ReadPodList()
        {
            PodList = new ObservableCollection<Pod>(_podRepository.ReadPodList());
            OnPropertyChanged(this, nameof(PodList));
        }

        public void AddLog()
        {
            _logRepository.AddLog(Log);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(Object sender, string propertyName)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }

    }
}