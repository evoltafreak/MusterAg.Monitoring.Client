using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MusterAg.Monitoring.Client.Models;
using MusterAg.Monitoring.Client.Repository;

namespace MusterAg.Monitoring.Client.Customer
{
    public class CustomerDetailViewModel : INotifyPropertyChanged
    {

        public Models.Customer Customer { get; set; }
        public ObservableCollection<string> GenderList { get; set; }
        public ObservableCollection<Location> LocationList { get; set; }
        public ObservableCollection<Models.Customer> CustomerList { get; set; }
        private readonly CustomerEFRepository _customerRepository;
        private readonly LocationEFRepository _locationRepository;

        public CustomerDetailViewModel()
        {
            Customer = new Models.Customer();
            _customerRepository = new CustomerEFRepository();
            _locationRepository = new LocationEFRepository();

            GenderList = new ObservableCollection<string>(new List<string>{"M", "F"});
            OnPropertyChanged(this, nameof(GenderList));
            
            LocationList = new ObservableCollection<Location>(_locationRepository.ReadAllLocationList());
            OnPropertyChanged(this, nameof(LocationList));
        }

        public void CreateCustomer()
        {
            _customerRepository.CreateCustomer(Customer);
        }
        
        public void UpdateCustomer()
        {
            _customerRepository.UpdateCustomer(Customer);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(Object sender, string propertyName)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }

    }
}