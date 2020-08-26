using System;
using System.Windows;
using System.Windows.Controls;
using MusterAg.Monitoring.Client.Models;

namespace MusterAg.Monitoring.Client.View
{
    public partial class LogWindow : Window
    {
        private readonly ILogViewModel _logViewModel;
        
        public LogWindow(ILogViewModel logViewModel)
        {
            InitializeComponent();
            _logViewModel = logViewModel;
            DataContext = _logViewModel;
        }

        public void AddLog(object sender, RoutedEventArgs routedEventArgs)
        {
            try
            {
                if (_logViewModel.Log.Message != null &&
                    _logViewModel.Log.Id != 0 &&
                    _logViewModel.Log.Severity != "NOT_SET")
                {
                    _logViewModel.AddLog();
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
                    _logViewModel.Log.Id = ((Pod) selectionChangedEventArgs.AddedItems[0]).IdPod;
                }
                else if (cmb.Name == "CmbSeverityList")
                {
                    _logViewModel.Log.Severity = ((Severity) selectionChangedEventArgs.AddedItems[0]).Severity1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: " + ex.Message, "Exception occured");
            }
        }
    }
}