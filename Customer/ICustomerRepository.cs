using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Customer
{
    public interface ICustomerRepository
    {
        List<Models.Customer> ReadCustomerList();
        List<Models.Customer> ReadCustomerListBySearchKey(string searchKey);
        void CreateCustomer(Models.Customer customer);
        void UpdateCustomer(Models.Customer customer);
        void DeleteCustomer(Models.Customer customer);
    }
}