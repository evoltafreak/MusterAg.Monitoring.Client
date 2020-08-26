using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MusterAg.Monitoring.Client.Customer
{
    public class CustomerViewModel : INotifyPropertyChanged, ICustomerViewModel
    {

        public String SearchKey { get; set; }
        public ObservableCollection<Models.Customer> CustomerList { get; set; }

        private readonly ICustomerRepository _customerRepository;

        public CustomerViewModel(ICustomerRepository customerRepository)
        {
            SearchKey = "";
            _customerRepository = customerRepository;
        }

        public void ReadCustomerList()
        {
            CustomerList = new ObservableCollection<Models.Customer>(_customerRepository.ReadCustomerList());
            OnPropertyChanged(this, nameof(CustomerList));
        }
        
        public void ReadCustomerListBySearchKey()
        {
            CustomerList = new ObservableCollection<Models.Customer>(_customerRepository.ReadCustomerListBySearchKey(SearchKey));
            OnPropertyChanged(this, nameof(CustomerList));
        }
        
        
        public void DeleteCustomer(Models.Customer customer)
        {
            _customerRepository.DeleteCustomer(customer);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(Object sender, string propertyName)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }

    }
}