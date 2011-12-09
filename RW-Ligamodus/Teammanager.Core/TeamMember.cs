using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teammanager.Core
{
    public class TeamMember : TreeViewChildrenViewModel
    {
        private CommandHelper _commands;
        private TeamManagerViewModel _vm;

        public TeamMember(TeamManagerViewModel vm, TreeViewChildrenViewModel parent, string name) : base (parent, name)
        {
            _commands = new CommandHelper(commandsTeamMember);
            _vm = vm;
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
                case "rename":
                    IsEditing = true;
                    break;
                case "deleteItem":
                    _vm.deleteItem(this);
                    break;
            }
        }

        #region properties

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

        #endregion
    }
}
