using System;
using System.Windows;
using System.Windows.Controls;
using MusterAg.Monitoring.Client.Models;

namespace MusterAg.Monitoring.Client.Customer
{
    public partial class CustomerDetailWindow : Window
    {
        public readonly ICustomerDetailViewModel _customerDetailViewModel;
        public Models.Customer Customer { get; set; }
        public CustomerDetailWindow(ICustomerDetailViewModel customerDetailViewModel)
        {
            InitializeComponent();
            _customerDetailViewModel = customerDetailViewModel;
            _customerDetailViewModel.Customer = Customer;
            DataContext = _customerDetailViewModel;
        }

        public void SaveKunde(object sender, RoutedEventArgs e)
        {
            if (_customerDetailViewModel.Customer.IdCustomer > 0)
            {
                _customerDetailViewModel.UpdateCustomer();
            }
            else
            {
                _customerDetailViewModel.CreateCustomer();
            }
            Close();
        }
        
        public void SetLocation(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            try
            {
                _customerDetailViewModel.Customer.FidLocation = ((Location) selectionChangedEventArgs.AddedItems[0]).IdLocation;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }
        
        public void SetGender(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            try
            {
                _customerDetailViewModel.Customer.Gender = ((string) selectionChangedEventArgs.AddedItems[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }
        
        public void SetBirthday(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            try
            {
                _customerDetailViewModel.Customer.Birthdate = ((DateTime) selectionChangedEventArgs.AddedItems[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        public void SetPassword(object sender, RoutedEventArgs e)
        {
            try
            {
                PasswordBox pb = (PasswordBox) sender;
                _customerDetailViewModel.Customer.Password = pb.Password;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

    }
}