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
        private string _homeTeamName = string.Empty;
        private string _visitorTeamName = string.Empty;
        private ObservableCollection<Position> _allPositions;

        public TeamManagerViewModel()
        {
            _menuHelper = new CommandHelper(commandMenu);
            _menuBarHelper = new CommandHelper(commandMenuBar);
            _itemSelectHepler = new ItemSelectHelper();
            _tree = new ObservableCollection<TreeViewChildrenViewModel>();
            _allPositions = new ObservableCollection<Position>();
            _allPositions.Add(new Position(1));
            _allPositions.Add(new Position(2));
            _allPositions.Add(new Position(3));
            _allPositions.Add(new Position(4));
            _allPositions.Add(new Position(5));
            _allPositions.Add(new Position(6));
            _allPositions.Add(new Position(7));
            _allPositions.Add(new Position(8));
            _allPositions.Add(new Position(9));
            _allPositions.Add(new Position(10));
        }


        public void commandMenu(object parameter)
        {
            switch (parameter as string)
            {
                case "addTeam":
                    Tree.Add(new Team(this, null, "The A Team"));
                    break;
                case "addTeamMember":
                    Team t = SelectedTreeObject as Team;
                    if (t != null)
                    {
                        t.Children.Add(new TeamMember(this, t, "B.A. Barakuda"));
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
                    Tree.Add(new Team(this, null, "New/Neu"));
                    break;
                case "addTeamMember":
                    Team t = SelectedTreeObject as Team;
                    if (t != null)
                    {
                        t.Children.Add(new TeamMember(this, t, "New/Neu"));
                    }
                    break;
                case "deleteItem":
                    this.deleteCommand();
                    break;
            }
        }

        public void addToPosition(ushort pos, TeamMember tm)
        {
            if (_allPositions[pos-1].PositionNumber == pos)
            {
                //check if member is already set
                foreach (Position p in _allPositions)
                {
                    if (p.Member == tm && p.Member.Parent == tm.Parent)
                    {
                        p.Member = null;
                        Notify("Pos" + p.PositionNumber);
                    }
                }
                _allPositions[pos-1].Member = tm;
                Notify("Pos" + _allPositions[pos-1].PositionNumber);
            }
        }

        public void deleteItem(object element)
        {
            Team team = element as Team;
            if (team != null)
            {
                Tree.Remove(team);
            }
            else
            {
                TeamMember member = element as TeamMember;
                if (member != null)
                {
                    Team t = member.Parent as Team;
                    t.Children.Remove(member);
                }
            }
        }

        private void deleteCommand()
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
                return _homeTeamName;
            }
            set
            {
                _homeTeamName = value;
                Notify("SelectedHomeTeam");
            }
        }

        public string SelectedVisitorTeam
        {
            get
            {
                return _visitorTeamName;
            }
            set
            {
                _visitorTeamName = value;
                Notify("SelectedVisitorTeam");
            }
        }

        #endregion


        #region positions

        public string Pos1
        {
            get
            {
                if (_allPositions[0].Member == null)
                {
                    return "---";
                }
                return _allPositions[0].Member.Name;
            }
            set
            {
                string s = value;
            }
        }

        public string Pos2
        {
            get
            {
                if (_allPositions[1].Member == null)
                {
                    return "---";
                }
                return _allPositions[1].Member.Name;
            }
            set
            {
                string s = value;
            }
        }

        public string Pos3
        {
            get
            {
                if (_allPositions[2].Member == null)
                {
                    return "---";
                }
                return _allPositions[2].Member.Name;
            }
            set
            {
                string s = value;
            }
        }

        public string Pos4
        {
            get
            {
                if (_allPositions[3].Member == null)
                {
                    return "---";
                }
                return _allPositions[3].Member.Name;
            }
            set
            {
                string s = value;
            }
        }

        public string Pos5
        {
            get
            {
                if (_allPositions[4].Member == null)
                {
                    return "---";
                }
                return _allPositions[4].Member.Name;
            }
            set
            {
                string s = value;
            }
        }

        public string Pos6
        {
            get
            {
                if (_allPositions[5].Member == null)
                {
                    return "---";
                }
                return _allPositions[5].Member.Name;
            }
            set
            {
                string s = value;
            }
        }

        public string Pos7
        {
            get
            {
                if (_allPositions[6].Member == null)
                {
                    return "---";
                }
                return _allPositions[6].Member.Name;
            }
            set
            {
                string s = value;
            }
        }

        public string Pos8
        {
            get
            {
                if (_allPositions[7].Member == null)
                {
                    return "---";
                }
                return _allPositions[7].Member.Name;
            }
            set
            {
                string s = value;
            }
        }

        public string Pos9
        {
            get
            {
                if (_allPositions[8].Member == null)
                {
                    return "---";
                }
                return _allPositions[8].Member.Name;
            }
            set
            {
                string s = value;
            }
        }

        public string Pos10
        {
            get
            {
                if (_allPositions[9].Member == null)
                {
                    return "---";
                }
                return _allPositions[9].Member.Name;
            }
            set
            {
                string s = value;
            }
        }

        #endregion
    }
}
