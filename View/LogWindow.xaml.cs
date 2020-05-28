using System;
using System.Windows;
using System.Windows.Controls;
using MusterAg.Monitoring.Client.Model;

namespace MusterAg.Monitoring.Client.View
{
    public partial class LogWindow : Window
    {
        public LogViewModel LogViewModel { get; set; }

        public LogWindow(string connectionString, bool isLinq)
        {
            InitializeComponent();
            LogViewModel = new LogViewModel(connectionString, isLinq);
            DataContext = LogViewModel;
        }

        public void AddLog(object sender, RoutedEventArgs routedEventArgs)
        {
            try
            {
                if (LogViewModel.Log.Message != null &&
                    LogViewModel.Log.IdPod != 0 &&
                    LogViewModel.Log.Severity != Severity.NOT_SET)
                {
                    LogViewModel.AddLog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Bitte füllen Sie alle Felder aus.", "Felder ausfüllen");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }

        public void SetLog(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            try
            {
                ComboBox cmb = (ComboBox) sender;
                if (cmb.Name == "CmbPodList")
                {
                    LogViewModel.Log.IdPod = ((Pod) selectionChangedEventArgs.AddedItems[0]).IdPod;
                }
                else if (cmb.Name == "CmbSeverityList")
                {
                    LogViewModel.Log.Severity = (Severity) selectionChangedEventArgs.AddedItems[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }
    }
}