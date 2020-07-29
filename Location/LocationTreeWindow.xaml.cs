using System.Windows;
using MusterAg.Monitoring.Client.Repository;

namespace MusterAg.Monitoring.Client.Repository
{
    public partial class LocationTreeWindow : Window
    {

        private LocationViewModel locationViewModel;

        public LocationTreeWindow()
        {
            InitializeComponent();
            locationViewModel = new LocationViewModel();
            DataContext = locationViewModel;
            trvMenu.Items.Add(locationViewModel.LocTreeItem);
        }

    }
}