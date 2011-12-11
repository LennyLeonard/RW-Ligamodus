using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Teammanager.Core
{
    public class Team : TreeViewChildrenViewModel
    {
        private string _emblemPath;
        private CommandHelper _commands;
        private TeamManagerViewModel _vm;

        public Team(TeamManagerViewModel vm, TreeViewChildrenViewModel parent, string name)
            : base(parent, name)
        {
            _commands = new CommandHelper(commandsTeam);
            _vm = vm;
        }


        public void commandsTeam(object parameter)
        {
            switch (parameter as string)
            {
                case "setAsHome":
                    _vm.setAsHomeTeam(this);
                    break;
                case "setAsVisitor":
                    _vm.setAsVisitorTeam(this);
                    break;
                case "rename":
                    IsEditing = true;
                    break;
                case "addTeamMember":
                    Children.Add(new TeamMember(_vm, this, "New/Neu"));
                    break;
                case "deleteItem":
                    _vm.deleteItem(this);
                    break;
            }
        }


        #region properties

        public string EmblemPath
        {
            get
            {
                return _emblemPath;
            }
            set
            {
                _emblemPath = value;
                Notify("EmblemPath");
            }
        }

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
