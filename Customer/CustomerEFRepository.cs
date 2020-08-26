using System.Collections.Generic;
using System.Linq;
using MusterAg.Monitoring.Client.Models;

namespace MusterAg.Monitoring.Client.Customer
{
    public class CustomerEFRepository : ICustomerRepository {

        public List<Models.Customer> ReadCustomerList()
        {
            using (var ctx = new musteragContext())
            {
                return ctx.Customer.ToList();
            }
        }
        
        public List<Models.Customer> ReadCustomerListBySearchKey(string searchKey)
        {
            searchKey = searchKey.ToLower();
            using (var ctx = new musteragContext()) {
                
                return ctx.Customer.Where(c => c.Firstname.ToLower().Contains(searchKey) ||
                                                       c.Lastname.ToLower().Contains(searchKey)).ToList();
            }
        }
        
        public void CreateCustomer(Models.Customer customer)
        {
            using (var ctx = new musteragContext())
            {

                ctx.Customer.Add(customer);
                ctx.SaveChanges();
            }
        }
        
        public void UpdateCustomer(Models.Customer customer)
        {
            using (var ctx = new musteragContext())
            {

                ctx.Customer.Update(customer);
                ctx.SaveChanges();
            }
        }
        
        public void DeleteCustomer(Models.Customer customer)
        {
            using (var ctx = new musteragContext())
            {
                ctx.Customer.Remove(ctx.Customer.Single(c => c.IdCustomer == customer.IdCustomer));
                ctx.SaveChanges();
            }
        }
        
    }
}