using System;
using System.Windows;
using LinqToDB.Data;
using MusterAg.Monitoring.Client.Config;
using MusterAg.Monitoring.Client.Customer;
using MusterAg.Monitoring.Client.Models;
using MusterAg.Monitoring.Client.View;

namespace MusterAg.Monitoring.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel mainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            DataConnection.DefaultSettings = new DbConfig();
            mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            try
            {
                mainViewModel.ReadLogList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        private void ClearLog(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedItem != null)
                {
                    VLogentries log = (VLogentries) DataGrid.SelectedItem;
                    mainViewModel.ClearLog(log.Id);
                    mainViewModel.ReadLogList();
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

        private void AddLog(object sender, RoutedEventArgs e)
        {
            try
            {
                LogWindow logWindow = new LogWindow();
                logWindow.Closed += ReloadData;
                logWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        private void ReloadData(object sender, EventArgs e)
        {
            try
            {
                mainViewModel.ReadLogList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        private void FindDuplicates(object sender, RoutedEventArgs e)
        {
            try
            {
                if (mainViewModel.LogList != null)
                {
                    string message = mainViewModel.FindDuplicates();
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

        private void ShowAllLocation(object sender, RoutedEventArgs e)
        {
            try
            {
                string message = mainViewModel.ShowAllLocation();
                MessageBox.Show(message, "Standorte");
            } catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        private void ShowKunden(object sender, RoutedEventArgs e)
        {
            try
            {
                CustomerWindow customerWindow = new CustomerWindow();
                customerWindow.Closed += ReloadData;
                customerWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }
        
    }
}