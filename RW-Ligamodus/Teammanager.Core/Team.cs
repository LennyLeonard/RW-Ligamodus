﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Teammanager.Core
{
    [Serializable]
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

        public Team()
        {
            _commands = new CommandHelper(commandsTeam);
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

        public void setMainViewModelContext(TeamManagerViewModel viewModel)
        {
            _vm = viewModel;
        }

        #region properties

        [XmlElement("Emblem")]
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

        #endregion
    }
}
