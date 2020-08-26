using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using MusterAg.Monitoring.Client.Helper;
using MusterAg.Monitoring.Client.Models;
using MusterAg.Monitoring.Client.Repository;

namespace MusterAg.Monitoring.Client.Customer
{
    public class CustomerDetailViewModel : INotifyPropertyChanged, ICustomerDetailViewModel
    {

        public Models.Customer Customer { get; set; }
        public ObservableCollection<string> GenderList { get; set; }
        public ObservableCollection<Location> LocationList { get; set; }
        
        private readonly ICustomerRepository _customerRepository;
        private readonly ILocationRepository _locationRepository;

        public CustomerDetailViewModel(ICustomerRepository customerRepository, ILocationRepository locationRepository)
        {
            Customer = new Models.Customer();
            _customerRepository = customerRepository;
            _locationRepository = locationRepository;

            GenderList = new ObservableCollection<string>(new List<string>{"M", "F"});
            OnPropertyChanged(this, nameof(GenderList));
            
            LocationList = new ObservableCollection<Location>(_locationRepository.ReadAllLocationList());
            OnPropertyChanged(this, nameof(LocationList));
        }

        public void CreateCustomer()
        {
            if (checkCustomer())
            {
                _customerRepository.CreateCustomer(Customer);
            }else
            {
                MessageBox.Show("Die zu speichernen Informationen entsprechen nicht den Richtlinien.", "Speichern fehlgeschlagen");
            }
        }
        
        public void UpdateCustomer()
        {
            if(checkCustomer())
            {
                _customerRepository.UpdateCustomer(Customer);
            }
            else
            {
                MessageBox.Show("Die zu speichernen Informationen entsprechen nicht den Richtlinien.", "Speichern fehlgeschlagen");
            }
        }

        private bool checkCustomer()
        {
            return RegexHelper.MatchEmail(Customer.Email)
                   && RegexHelper.MatchEmail(Customer.CustomerNr)
                   && RegexHelper.MatchEmail(Customer.Website)
                   && Customer.Password != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(Object sender, string propertyName)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }

    }
}