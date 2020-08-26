using System;
using System.Windows;
using System.Windows.Controls;
using LinqToDB.Data;
using MusterAg.Monitoring.Client.Config;

namespace MusterAg.Monitoring.Client.Customer
{
    public partial class CustomerWindow : Window
    {
        
        private readonly ICustomerViewModel _customerViewModel;
        private readonly CustomerDetailWindow _customerDetailWindow;

        public CustomerWindow(ICustomerViewModel customerViewModel, CustomerDetailWindow customerDetailWindow)
        {
            InitializeComponent();
            DataConnection.DefaultSettings = new DbConfig();
            _customerViewModel = customerViewModel;
            _customerDetailWindow = customerDetailWindow;
            DataContext = _customerViewModel;
        }

        public void ReloadData(object sender, EventArgs e)
        {
            try
            {
                _customerViewModel.ReadCustomerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        public void ReadCustomerList(object sender, RoutedEventArgs e)
        {
            try
            {
                _customerViewModel.ReadCustomerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        public void ReadCustomerListBySearchKey(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox textBox = (TextBox) sender;
                _customerViewModel.SearchKey = textBox.Text;
                _customerViewModel.ReadCustomerListBySearchKey();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        public void CreateCustomer(object sender, RoutedEventArgs e)
        {
            try
            {
                _customerDetailWindow.Closed += ReloadData;
                _customerDetailWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        public void UpdateCustomer(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedItem != null)
                {
                    Models.Customer customer = (Models.Customer) DataGrid.SelectedItem;
                    _customerDetailWindow.Customer = customer;
                    _customerDetailWindow.Closed += ReloadData;
                    _customerDetailWindow.ShowDialog();
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

        public void DeleteCustomer(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (DataGrid.SelectedItem != null)
                {
                    Models.Customer customer = (Models.Customer) DataGrid.SelectedItem;
                    _customerViewModel.DeleteCustomer(customer);
                    _customerViewModel.ReadCustomerList();
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