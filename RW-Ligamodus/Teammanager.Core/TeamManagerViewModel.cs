using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;

namespace Teammanager.Core
{
    public class TeamManagerViewModel : BaseViewModel
    {
        private CommandHelper _menuHelper;
        private CommandHelper _menuBarHelper;
        private ItemSelectHelper _itemSelectHepler;
        private ObservableCollection<TreeViewChildrenViewModel> _tree;

        public TeamManagerViewModel()
        {
            _menuHelper = new CommandHelper(commandMenu);
            _menuBarHelper = new CommandHelper(commandMenuBar);
            _itemSelectHepler = new ItemSelectHelper();
            _tree = new ObservableCollection<TreeViewChildrenViewModel>();
        }


        public void commandMenu(object parameter)
        {
            switch (parameter as string)
            {
                case "addTeam":
                    Tree.Add(new Team(null, "The A Team"));
                    break;
                case "addTeamMember":
                    Team t = SelectedTreeObject as Team;
                    if (t != null)
                    {
                        t.Children.Add(new TeamMember(t, "B.A. Barakuda"));
                    }
                    break;
                case "deleteItem":
                    this.deleteCommand();
                    break;
            }
        }


        public void commandMenuBar(object parameter)
        {
            switch (parameter as string)
            {
                case "addTeam":
                    Tree.Add(new Team(null, "The A Team"));
                    break;
                case "addTeamMember":
                    Team t = SelectedTreeObject as Team;
                    if (t != null)
                    {
                        t.Children.Add(new TeamMember(t, "B.A. Barakuda"));
                    }
                    break;
                case "deleteItem":
                    this.deleteCommand();
                    break;
            }
        }

        

        internal void deleteCommand()
        {
            Team team = SelectedTreeObject as Team;
            if (team != null)
            {
                Tree.Remove(team);
            }
            else
            {
                TeamMember member = SelectedTreeObject as TeamMember;
                if (member != null)
                {
                    Team t = member.Parent as Team;
                    t.Children.Remove(member);
                }
            }
        }


        #region properties

        public CommandHelper MenuCommands
        {
            get
            {
                return _menuHelper;
            }
            set
            {
                _menuHelper = value;
                Notify("MenuCommands");
            }
        }

        public CommandHelper MenuBarCommands
        {
            get
            {
                return _menuBarHelper;
            }
            set
            {
                _menuBarHelper = value;
                Notify("MenuBarCommands");
            }
        }

        public ObservableCollection<TreeViewChildrenViewModel> Tree
        {
            get
            {
                return _tree;
            }
            set
            {
                _tree = value;
                Notify("Tree");
            }
        }

        public object SelectedTreeObject
        {
            get
            {
                return _itemSelectHepler.CurrentObject;
            }
            set
            {
                _itemSelectHepler.CurrentObject = value;
                Notify("SelectedTreeObject");
            }
        }

        public string SelectedHomeTeam
        {
            get
            {
                return string.Empty;
            }
            set
            {
                Notify("SelectedHomeTeam");
            }
        }

        public string SelectedVisitorTeam
        {
            get
            {
                return string.Empty;
            }
            set
            {
                Notify("SelectedVisitorTeam");
            }
        }

        #endregion
    }
}
