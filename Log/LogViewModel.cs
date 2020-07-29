using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MusterAg.Monitoring.Client.Models;
using MusterAg.Monitoring.Client.Repository;

namespace MusterAg.Monitoring.Client
{
    public class LogViewModel : INotifyPropertyChanged
    {
        public VLogentries log;
        public VLogentries Log
        {
            get
            {
                return log;
            }
            set
            {
                log = value;
                OnPropertyChanged(this, nameof(VLogentries));
            }
        }
        public ObservableCollection<Severity> SeverityList { get; set; }
        public ObservableCollection<Pod> PodList { get; set; }

        private readonly LogEFRepository _logRepository;
        private readonly SeverityEFRepository _severityRepository;
        private readonly PodEFRepository _podRepository;

        public LogViewModel()
        {
            _logRepository = new LogEFRepository();
            _severityRepository = new SeverityEFRepository();
            _podRepository = new PodEFRepository();
            LoadData();
        }

        private void LoadData()
        {
            ReadSeverityList();
            ReadPodList();
            Log = new VLogentries();
        }
        
        public void ReadSeverityList()
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