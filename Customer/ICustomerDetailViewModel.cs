namespace MusterAg.Monitoring.Client.Customer
{
    public interface ICustomerDetailViewModel
    {
        Models.Customer Customer { get; set; }
        void CreateCustomer();
        void UpdateCustomer();
    }
}