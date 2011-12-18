using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;
using System;

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
        private PersistanceControl pc;

        public TeamManagerViewModel()
        {
            _menuHelper = new CommandHelper(commandMenu);
            _menuBarHelper = new CommandHelper(commandMenuBar);
            _itemSelectHepler = new ItemSelectHelper();
            _tree = new ObservableCollection<TreeViewChildrenViewModel>();
            pc = new PersistanceControl();
            _allPositions = new ObservableCollection<Position>();
            AllPositions.Add(new Position(1));
            AllPositions.Add(new Position(2));
            AllPositions.Add(new Position(3));
            AllPositions.Add(new Position(4));
            AllPositions.Add(new Position(5));
            AllPositions.Add(new Position(6));
            AllPositions.Add(new Position(7));
            AllPositions.Add(new Position(8));
            AllPositions.Add(new Position(9));
            AllPositions.Add(new Position(10));

            //try to load tree objects
            Tree = pc.deserializeTreeObjects();
        }


        public void commandMenu(object parameter)
        {
            switch (parameter as string)
            {
                case "commit":
                    if (pc.serializeMatch(this.createMatch(AllPositions)) != true)
                    {
                        System.Console.WriteLine("Error creating match-file");
                    }
                    break;
                case "save":
                    break;
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
                case "commit":
                    if (pc.serializeMatch(this.createMatch(AllPositions)) != true)
                    {
                        System.Console.WriteLine("Error creating match-file");
                    }
                    break;
                case "save":
                    pc.serializeTreeObjects(Tree);
                    break;
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

        private Match createMatch(ObservableCollection<Position> positions)
        {
            Match match = new Match();
            match.HomeTeamName = SelectedHomeTeam;
            match.VisitorTeamName = SelectedVisitorTeam;
            foreach (Position p in positions)
            {
                if ((p.PositionNumber % 2) != 0)
                {
                    if(p.Member == null)
                    {
                        match.HomeTeamMembers.Add(new TeamMember(this, null, "---"));
                    }
                    else
                    {
                        match.HomeTeamMembers.Add(p.Member);
                    }
                }
                else
                {
                    if (p.Member == null)
                    {
                        match.VisitorTeamMembers.Add(new TeamMember(this, null, "---"));
                    }
                    else
                    {
                        match.VisitorTeamMembers.Add(p.Member);
                    }
                }
            }

            return match;
        }

        public void setAsHomeTeam(Team hometeam)
        {
            SelectedHomeTeam = hometeam.Name;

            int j = 0;
            //set the first five to positions
            try
            {
                for (int i = 0; i < 10; i += 2)
                {
                    AllPositions[i].Member = (hometeam.Children[j] as TeamMember);
                    Notify("Pos" + AllPositions[i].PositionNumber);
                    j++;
                }
            }
            catch (Exception){ }
        }

        public void setAsVisitorTeam(Team visitorteam)
        {
            SelectedVisitorTeam = visitorteam.Name;

            int j = 0;
            //set the first five to positions
            try
            {
                for (int i = 1; i < 10; i += 2)
                {
                    AllPositions[i].Member = (visitorteam.Children[j] as TeamMember);
                    Notify("Pos" + AllPositions[i].PositionNumber);
                    j++;
                }
            }
            catch (Exception) { }
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

        public ObservableCollection<Position> AllPositions
        {
            get
            {
                return _allPositions;
            }
            set
            {
                _allPositions = value;
                Notify("AllPositions");
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
