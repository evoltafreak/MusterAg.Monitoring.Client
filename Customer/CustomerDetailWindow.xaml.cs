using System;
using System.Windows;
using System.Windows.Controls;
using MusterAg.Monitoring.Client.Models;

namespace MusterAg.Monitoring.Client.Customer
{
    public partial class CustomerDetailWindow : Window
    {
        public CustomerDetailViewModel CustomerDetailViewModel { get; set; }
        public CustomerDetailWindow()
        {
            InitializeComponent();
            CustomerDetailViewModel = new CustomerDetailViewModel();
            DataContext = CustomerDetailViewModel;
        }
        
        public CustomerDetailWindow(Models.Customer customer)
        {
            InitializeComponent();
            CustomerDetailViewModel = new CustomerDetailViewModel();
            DataContext = CustomerDetailViewModel;
            CustomerDetailViewModel.Customer = customer;
        }

        private void SaveKunde(object sender, RoutedEventArgs e)
        {
            if (CustomerDetailViewModel.Customer.IdCustomer > 0)
            {
                CustomerDetailViewModel.UpdateCustomer();
            }
            else
            {
                CustomerDetailViewModel.CreateCustomer();
            }
            Close();
        }
        
        public void SetLocation(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            try
            {
                CustomerDetailViewModel.Customer.FidLocation = ((Location) selectionChangedEventArgs.AddedItems[0]).IdLocation;
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
                CustomerDetailViewModel.Customer.Gender = ((string) selectionChangedEventArgs.AddedItems[0]);
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
                CustomerDetailViewModel.Customer.Birthdate = ((DateTime) selectionChangedEventArgs.AddedItems[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        private void SetPassword(object sender, RoutedEventArgs e)
        {
            try
            {
                PasswordBox pb = (PasswordBox) sender;
                CustomerDetailViewModel.Customer.Password = pb.Password;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

    }
}