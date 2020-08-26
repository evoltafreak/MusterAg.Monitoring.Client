﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
 using System.Linq;
 using MusterAg.Monitoring.Client.Models;

 namespace MusterAg.Monitoring.Client.Repository
{
    public class LocationViewModel : INotifyPropertyChanged, ILocationViewModel
    {
        public LocTreeNode LocTreeItem { get; set; }

        private ILocationRepository _locationRepository;

        public LocationViewModel(ILocationRepository locationRepository)
        {
            LocTreeItem = new LocTreeNode();
            _locationRepository = locationRepository;

            List<LocTree> locTreeList = _locationRepository.ReadLocTree();
            CreateLocTree(locTreeList);
            
            OnPropertyChanged(this, nameof(LocTreeItem));
            
        }

        public void CreateLocTree(List<LocTree> locTreeList)
        {
            LocTreeNode item = new LocTreeNode();
            item.Source = new LocTree { Address = "Locations" };
            item.Children = new ObservableCollection<LocTreeNode>(CreateTree(locTreeList));
            LocTreeItem = item;
        }

        public List<LocTreeNode> CreateTree(List<LocTree> locTreeList)
        {
            Dictionary<int, LocTreeNode> lookup = new Dictionary<int, LocTreeNode>();
            locTreeList.ForEach(x => lookup.Add(x.IdLocation, new LocTreeNode { Source = x }));
            foreach (var item in lookup.Values) {
                LocTreeNode parent;
                if (lookup.TryGetValue(item.Source.Parent, out parent)) {
                    item.Parent = parent;
                    parent.Children.Add(item);
                }
            }
            return lookup.Values.Where(x => x.Parent == null).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(Object sender, string propertyName)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }

    }

}