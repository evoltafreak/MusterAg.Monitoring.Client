using System;
using System.Windows;
using Autofac;
using LinqToDB.Data;
using MusterAg.Monitoring.Client.Config;
using MusterAg.Monitoring.Client.Customer;
using MusterAg.Monitoring.Client.Models;
using MusterAg.Monitoring.Client.Repository;
using MusterAg.Monitoring.Client.View;

namespace MusterAg.Monitoring.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private IContainer _container;
        private readonly IMainViewModel _mainViewModel;
        private readonly CustomerWindow _customerWindow;
        private readonly LogWindow _logWindow;
        private readonly LocationTreeWindow _locationTreeWindow;

        public MainWindow()
        {
            InitializeComponent();
            DataConnection.DefaultSettings = new DbConfig();
            _container = ContainerConfig.BuildAutofacContainer();
            using (var container = _container.BeginLifetimeScope())
            {
                _mainViewModel = container.Resolve<IMainViewModel>();
                _customerWindow = container.Resolve<CustomerWindow>();
                _logWindow = container.Resolve<LogWindow>();
                _locationTreeWindow = container.Resolve<LocationTreeWindow>();
                DataContext = _mainViewModel;
            }
        }


        public void LoadData(object sender, RoutedEventArgs e)
        {
            try
            {
                _mainViewModel.ReadLogList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        public void ClearLog(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedItem != null)
                {
                    VLogentries log = (VLogentries) DataGrid.SelectedItem;
                    _mainViewModel.ClearLog(log.Id);
                    _mainViewModel.ReadLogList();
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

        public void AddLog(object sender, RoutedEventArgs e)
        {
            try
            {
                _logWindow.Closed += ReloadData;
                _logWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        public void ReloadData(object sender, EventArgs e)
        {
            try
            {
                _mainViewModel.ReadLogList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        public void FindDuplicates(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_mainViewModel.LogList != null)
                {
                    string message = _mainViewModel.FindDuplicates();
                    MessageBox.Show(message, "Duplikate");
                }
                else
                {
                    MessageBox.Show("Laden Sie zuerst die Daten.", "Daten laden");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        public void ShowAllLocation(object sender, RoutedEventArgs e)
        {
            try
            {
                string message = _mainViewModel.ShowAllLocation();
                MessageBox.Show(message, "Standorte");
            } catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        public void ShowKunden(object sender, RoutedEventArgs e)
        {
            try
            {
                _customerWindow.Closed += ReloadData;
                _customerWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        public void ShowLocationTree(object sender, RoutedEventArgs e)
        {
            try
            {
                _locationTreeWindow.Closed += ReloadData;
                _locationTreeWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }
        
    }
}