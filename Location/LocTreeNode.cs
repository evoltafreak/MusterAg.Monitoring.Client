using System.Collections.ObjectModel;
using MusterAg.Monitoring.Client.Models;

namespace MusterAg.Monitoring.Client.Repository
{
    public class LocTreeNode
    {

        public LocTreeNode()
        {
            Children = new ObservableCollection<LocTreeNode>();
        }
        
        public ObservableCollection<LocTreeNode> Children { get; set; }
        public LocTreeNode Parent { get; set; }
        public LocTree Source { get; set; }

        public string FullAddress
        {
            get
            {
                return Source.Address + " " + Source.AddressNr;
            }
        }
        
    }
}