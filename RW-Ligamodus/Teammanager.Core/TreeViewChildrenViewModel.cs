using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Serialization;

namespace Teammanager.Core
{
    [XmlInclude(typeof(Team))]
    [XmlRoot("TreeElement")]
    public class TreeViewChildrenViewModel : BaseViewModel
    {
        private string _Name;
        private ObservableCollection<TeamMember> _Children;
        private bool _isSelected;
        private bool _renameCommand;

        internal protected TreeViewChildrenViewModel(TreeViewChildrenViewModel parent, string name)
        {
            Parent = parent;
            _Name = name;

        }

        public TreeViewChildrenViewModel()
        {
        }

        public TreeViewChildrenViewModel Parent { get; set; }
        
        [XmlElement("Name")]
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

        [XmlIgnore]
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

        [XmlArray("Children")]
        public ObservableCollection<TeamMember> Children
        {
            get
            {
                return _Children ?? (_Children = new ObservableCollection<TeamMember>());
            }
        }

        [XmlIgnore]
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
    }
}
