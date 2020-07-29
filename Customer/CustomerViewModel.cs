using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MusterAg.Monitoring.Client.Customer
{
    public class CustomerViewModel : INotifyPropertyChanged
    {

        public String SearchKey { get; set; }
        public ObservableCollection<Models.Customer> CustomerList { get; set; }

        private CustomerEFRepository customerRepository;

        public CustomerViewModel()
        {
            SearchKey = "";
            customerRepository = new CustomerEFRepository();
        }

        public void ReadCustomerList()
        {
            CustomerList = new ObservableCollection<Models.Customer>(customerRepository.ReadCustomerList());
            OnPropertyChanged(this, nameof(CustomerList));
        }
        
        public void ReadCustomerListBySearchKey()
        {
            CustomerList = new ObservableCollection<Models.Customer>(customerRepository.ReadCustomerListBySearchKey(SearchKey));
            OnPropertyChanged(this, nameof(CustomerList));
        }
        
        
        public void DeleteCustomer(Models.Customer customer)
        {
            customerRepository.DeleteCustomer(customer);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(Object sender, string propertyName)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }

    }
}