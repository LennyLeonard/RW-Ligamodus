using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Teammanager.Core
{
    [Serializable]
    public class TeamMember : BaseViewModel
    {
        private CommandHelper _commands;
        private TeamManagerViewModel _vm;
        private TreeViewChildrenViewModel _parent;
        private string _name;
        private bool _renameCommand;
        private bool _isSelected;

        public TeamMember(TeamManagerViewModel vm, TreeViewChildrenViewModel parent, string name)
        {
            _commands = new CommandHelper(commandsTeamMember);
            _parent = parent;
            _name = name;
            _vm = vm;
        }

        public TeamMember()
        {
            _commands = new CommandHelper(commandsTeamMember);
        }

        public void commandsTeamMember(object parameter)
        {
            switch (parameter as string)
            {
                case "toPos1":
                    _vm.addToPosition(1, this);
                    break;
                case "toPos2":
                    _vm.addToPosition(2, this);
                    break;
                case "toPos3":
                    _vm.addToPosition(3, this);
                    break;
                case "toPos4":
                    _vm.addToPosition(4, this);
                    break;
                case "toPos5":
                    _vm.addToPosition(5, this);
                    break;
                case "toPos6":
                    _vm.addToPosition(6, this);
                    break;
                case "toPos7":
                    _vm.addToPosition(7, this);
                    break;
                case "toPos8":
                    _vm.addToPosition(8, this);
                    break;
                case "toPos9":
                    _vm.addToPosition(9, this);
                    break;
                case "toPos10":
                    _vm.addToPosition(10, this);
                    break;
                case "up":
                    (Parent as Team).moveTeamMemberOneUpInTree(this);
                    break;
                case "down":
                    (Parent as Team).moveTeamMemberOneDownInTree(this);
                    break;
                case "rename":
                    IsEditing = true;
                    break;
                case "deleteItem":
                    _vm.deleteItem(this);
                    break;
            }
        }

        public void setMainViewModelContext(TeamManagerViewModel viewModel)
        {
            _vm = viewModel;
        }



        #region properties

        [XmlIgnore]
        public CommandHelper TreeCommands
        {
            get
            {
                return _commands;
            }
            set
            {
                _commands = value;
                Notify("TreeCommands");
            }
        }

        [XmlElement("Name")]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                IsEditing = false;
                Notify("Name");
            }
        }

        [XmlIgnore]
        public TreeViewChildrenViewModel Parent { get; set; }

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

        #endregion
    }
}
