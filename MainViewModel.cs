using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using DuplicateCheckerLib;
using MusterAg.Monitoring.Client.Models;
using MusterAg.Monitoring.Client.Repository;

namespace MusterAg.Monitoring.Client
{
    public class MainViewModel : INotifyPropertyChanged, IMainViewModel
    {
        public string ConnectionString { get; set; }
        public ObservableCollection<VLogentries> LogList { get; set; }
        
        private ILogRepository _logRepository;
        private ILocationRepository _locationRepository;

        public MainViewModel(ILogRepository logRepository, ILocationRepository locationRepository)
        {
            _logRepository = logRepository;
            _locationRepository = locationRepository;
            ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringSqlServer"].ConnectionString;
            OnPropertyChanged(this, nameof(ConnectionString));
        }

        public void ReadLogList()
        {
            LogList = new ObservableCollection<VLogentries>(_logRepository.ReadLogList());
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
            IEnumerable<VLogentries> logEnumerable = LogList;
            List<VLogentries> list =  new List<VLogentries>(logEnumerable);
            var duplicateList = duplicateChecker.FindDuplicates(list);
            foreach(VLogentries log in duplicateList)
            {
                message += log.ToString() + "\n";
            }

            return message;
        }

        public string ShowAllLocation()
        {
            string message = "";
            message += "Anzahl Standorte: " + _locationRepository.Count() + "\n";
            List<Location> locationList;
            locationList = _locationRepository.ReadAllLocationList();
            foreach(Location location in locationList)
            {
                message += location.ToString() + "\n";
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