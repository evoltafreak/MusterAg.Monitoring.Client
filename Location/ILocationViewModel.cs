using System.Collections.Generic;
using MusterAg.Monitoring.Client.Models;

namespace MusterAg.Monitoring.Client.Repository
{
    public interface ILocationViewModel
    {
        void CreateLocTree(List<LocTree> locTreeList);
        List<LocTreeNode> CreateTree(List<LocTree> locTreeList);
        
        LocTreeNode LocTreeItem { get; set; }
    }
}