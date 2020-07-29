using System;
using System.Windows;
using System.Windows.Controls;
using LinqToDB.Data;
using MusterAg.Monitoring.Client.Config;

namespace MusterAg.Monitoring.Client.Customer
{
    public partial class CustomerWindow : Window
    {
        
        private CustomerViewModel customerViewModel;

        public CustomerWindow()
        {
            InitializeComponent();
            DataConnection.DefaultSettings = new DbConfig();
            customerViewModel = new CustomerViewModel();
            DataContext = customerViewModel;
        }
        
        private void ReloadData(object sender, EventArgs e)
        {
            try
            {
                customerViewModel.ReadCustomerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        private void ReadCustomerList(object sender, RoutedEventArgs e)
        {
            try
            {
                customerViewModel.ReadCustomerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }
        
        private void ReadCustomerListBySearchKey(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox textBox = (TextBox) sender;
                customerViewModel.SearchKey = textBox.Text;
                customerViewModel.ReadCustomerListBySearchKey();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }
        
        private void CreateCustomer(object sender, RoutedEventArgs e)
        {
            try
            {
                CustomerDetailWindow customerDetailWindow = new CustomerDetailWindow();
                customerDetailWindow.Closed += ReloadData;
                customerDetailWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }
        
        private void UpdateCustomer(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedItem != null)
                {
                    Models.Customer customer = (Models.Customer) DataGrid.SelectedItem;
                    CustomerDetailWindow customerDetailWindow = new CustomerDetailWindow(customer);
                    customerDetailWindow.Closed += ReloadData;
                    customerDetailWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bitte wählen Sie eine Zeile aus.", "Auswahl fehlgeschlagen");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }
        
        private void DeleteCustomer(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (DataGrid.SelectedItem != null)
                {
                    Models.Customer customer = (Models.Customer) DataGrid.SelectedItem;
                    customerViewModel.DeleteCustomer(customer);
                    customerViewModel.ReadCustomerList();
                }
                else
                {
                    MessageBox.Show("Bitte wählen Sie eine Zeile aus.", "Auswahl fehlgeschlagen");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
            
        }

    }
}