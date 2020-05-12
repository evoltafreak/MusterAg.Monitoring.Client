using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using DuplicateCheckerLib;
using MusterAg.Monitoring.Client.Model;
using MusterAg.Monitoring.Client.Repository;

namespace MusterAg.Monitoring.Client
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string connectionString;
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
                _logRepository.ConnectionString = value;
            }
        }

        public ObservableCollection<Log> LogList { get; set; }

        private readonly LogRepository _logRepository;

        public MainViewModel()
        {
            _logRepository = new LogRepository(connectionString);
            ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }
        
        public void ReadLogList()
        {
            LogList = new ObservableCollection<Log>(_logRepository.ReadLogList());
            OnPropertyChanged(this, nameof(LogList));
        }

        public void ClearLog(long id)
        {
            _logRepository.ClearLog(id);
        }
        
        public string FindDuplicates()
        {
            string message = "";
            DuplicateChecker duplicateChecker = new DuplicateChecker();
            IEnumerable<Log> logEnumerable = LogList;
            List<Log> list =  new List<Log>(logEnumerable);
            var duplicateList = duplicateChecker.FindDuplicates(list);
            foreach(Log log in duplicateList)
            {
                message += log.ToString() + "\n";
            }

            return message;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(Object sender, string propertyName)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }

    }
}