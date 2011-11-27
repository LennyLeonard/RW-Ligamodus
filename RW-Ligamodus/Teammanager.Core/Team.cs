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

        public Team(TreeViewChildrenViewModel parent, string name) : base (parent, name)
        {
            _commands = new CommandHelper(commandsTeam);
        }


        public void commandsTeam(object parameter)
        {
            switch (parameter as string)
            {
                case "addTeam":
                    break;
                case "addTeamMember":
                    break;
                case "deleteItem":
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
