using System;
using System.Windows;
using System.Windows.Controls;
using MusterAg.Monitoring.Client.Models;

namespace MusterAg.Monitoring.Client.View
{
    public partial class LogWindow : Window
    {
        public LogViewModel LogViewModel { get; set; }
        
        public LogWindow()
        {
            InitializeComponent();
            LogViewModel = new LogViewModel();
            DataContext = LogViewModel;
        }

        public void AddLog(object sender, RoutedEventArgs routedEventArgs)
        {
            try
            {
                if (LogViewModel.Log.Message != null &&
                    LogViewModel.Log.Id != 0 &&
                    LogViewModel.Log.Severity != "NOT_SET")
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
                    LogViewModel.Log.Id = ((Pod) selectionChangedEventArgs.AddedItems[0]).IdPod;
                }
                else if (cmb.Name == "CmbSeverityList")
                {
                    LogViewModel.Log.Severity = ((Severity) selectionChangedEventArgs.AddedItems[0]).Severity1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }
    }
}