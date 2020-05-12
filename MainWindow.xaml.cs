using System;
using System.Windows;
using MusterAg.Monitoring.Client.Model;
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
                    Log log = (Log) DataGrid.SelectedItem;
                    mainViewModel.ClearLog(log.IdPod);
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
                LogWindow logWindow = new LogWindow(mainViewModel.ConnectionString);
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
    }
}