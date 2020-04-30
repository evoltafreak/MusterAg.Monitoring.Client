using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using MusterAg.Monitoring.Client.Model;
using MusterAg.Monitoring.Client.Repository;

namespace MusterAg.Monitoring.Client
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string ConnectionString { get; set; }
        public List<Log> LogList { get; set; }

        private LogRepository _logRepository;

        public MainViewModel()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            _logRepository = new LogRepository();
        }
        
        public List<Log> ReadLogList()
        {
            LogList = _logRepository.ReadLogList(ConnectionString);
            Update();
            return LogList;
        }

        public void ClearLog(long id)
        {
            _logRepository.ClearLog(ConnectionString, id, LogList);
            Update();
        }

        private void Update()
        {
            OnPropertyChanged(this, nameof(ConnectionString));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(Object sender, string propertyName)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }

    }
}