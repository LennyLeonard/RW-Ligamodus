﻿using System.Collections.ObjectModel;

namespace Teammanager.Core
{
    public class TreeViewChildrenViewModel : BaseViewModel
    {
        private string _Name;
        private ObservableCollection<TreeViewChildrenViewModel> _Children;
        private bool _isSelected;
        private bool _renameCommand;

        internal protected TreeViewChildrenViewModel(TreeViewChildrenViewModel parent, string name)
        {
            Parent = parent;
            _Name = name;

        }

        public TreeViewChildrenViewModel Parent { get; private set; }
        

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                IsEditing = false;
                Notify("Name");
            }
        }

        public bool IsEditing
        {
            get
            {
                return _renameCommand;
            }
            set
            {
                _renameCommand = value;
                Notify("IsEditing");
            }
        }

        public ObservableCollection<TreeViewChildrenViewModel> Children
        {
            get
            {
                return _Children ?? (_Children = new ObservableCollection<TreeViewChildrenViewModel>());
            }
        }

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                Notify("IsSelected");
            }
        }

        protected void CheckIfEmpty()
        {
            if (Children.Count == 0)
            {
                Children.Add(new TreeViewChildrenViewModel(this, "(Keine Ergebnisse)"));
            }
        }


    }
}
