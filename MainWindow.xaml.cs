using System;
using System.Collections.Generic;
using System.Windows;
using MusterAg.Monitoring.Client.Model;

namespace MusterAg.Monitoring.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel mainViewModel;
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
                List<Log> logList = mainViewModel.ReadLogList();
                DataGrid.ItemsSource = logList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Es ist ein Fehler aufgetreten: " + ex.Message);
            }
        }

        private void ClearLog(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Log> logList = (List<Log>) DataGrid.ItemsSource;
                // TODO: include selected id
                //mainViewModel.ClearLog(1, logList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Es ist ein Fehler aufgetreten: " + ex.Message);
            }
        }
    }
}