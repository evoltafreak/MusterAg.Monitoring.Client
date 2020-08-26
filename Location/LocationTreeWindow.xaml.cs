using System.Windows;

namespace MusterAg.Monitoring.Client.Repository
{

    public partial class LocationTreeWindow : Window
    {

        private readonly ILocationViewModel _locationViewModel;

        public LocationTreeWindow(ILocationViewModel locationViewModel)
        {
            InitializeComponent();
            _locationViewModel = locationViewModel;
            DataContext = _locationViewModel;
            trvMenu.Items.Add(_locationViewModel.LocTreeItem);
        }

    }
}