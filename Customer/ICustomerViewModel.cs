using System;

namespace MusterAg.Monitoring.Client.Customer
{
    public interface ICustomerViewModel
    {
        String SearchKey { get; set; }
        void ReadCustomerList();
        void ReadCustomerListBySearchKey();
        void DeleteCustomer(Models.Customer customer);
    }
}