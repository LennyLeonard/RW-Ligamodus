using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teammanager.Core
{
    public class TeamMember : TreeViewChildrenViewModel
    {
        private CommandHelper _commands;

        public TeamMember(TreeViewChildrenViewModel parent, string name) : base (parent, name)
        {
            _commands = new CommandHelper(commandsTeamMember);
        }

        public void commandsTeamMember(object parameter)
        {
            switch (parameter as string)
            {
                case "rename":
                    Name = "Face";
                    break;
                case "deleteItem":
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
