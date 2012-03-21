using System;
using System.Collections.Generic;
using System.Text;
using Teammanager.Core;
using System.Collections.ObjectModel;

namespace RWLigamodus.ViewModel
{
    public class RWLigamodusViewModel : BaseViewModel
    {
        private CommandHelper _menuCommands;
        private CommandHelper _toolbarCommands;
        private PersistanceControl _persistance;
        private Match _currentMatch;
        private TournamentViewModel _tnmtViewModel;
        private TournamentSettingsViewModel _tnmtSettViewModel;
        /*
        private ObservableCollection<ExtendedTeamMember> _homeTeam;
        private ObservableCollection<ExtendedTeamMember> _visitorTeam;*/


        public RWLigamodusViewModel()
        {
            _menuCommands = new CommandHelper(commandHandler);
            _toolbarCommands = new CommandHelper(commandHandler);
            try
            {
                _persistance = new PersistanceControl();
                _currentMatch = _persistance.deserializeMatch();
                //add teams to tournamentvm
                _tnmtViewModel = new TournamentViewModel(_currentMatch);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        private void commandHandler(object param)
        {
            switch (param as string)
            {
                case "newTnmt":
                    break;
                case "exportResult":
                    break;
            }
        }

        #region properties

        public CommandHelper MenuCommands
        {
            get
            {
                return _menuCommands;
            }
            set
            {
                _menuCommands = value;
                Notify("MenuCommands");
            }
        }

        public CommandHelper ToolbarCommands
        {
            get
            {
                return _toolbarCommands;
            }
            set
            {
                _toolbarCommands = value;
                Notify("ToolbarCommands");
            }
        }

        public TournamentViewModel TnmtViewModel
        {
            get
            {
                return _tnmtViewModel;
            }
        }

        #endregion
        /*
        public ObservableCollection<ExtendedTeamMember> HomeTeam
        {
            get
            {
                return _homeTeam;
            }
        }

        public ObservableCollection<ExtendedTeamMember> VisitorTeam
        {
            get
            {
                return _visitorTeam;
            }
        }

        public ObservableCollection<ExtendedTeamMember> HomeTeamPlayOff
        {
            get
            {
                return _homeTeamPlayOffs;
            }
            set
            {
                _homeTeamPlayOffs = value;
                Notify("HomeTeamPlayOff");
            }
        }

        public ObservableCollection<ExtendedTeamMember> VisitorTeamPlayOff
        {
            get
            {
                return _visitorTeamPlayOffs;
            }
            set
            {
                _visitorTeamPlayOffs = value;
                Notify("VisitorTeamPlayOff");
            }
        }

        public bool PlayOffNeeded
        {
            get
            {
                return _playOffNeeded;
            }
            set
            {
                _playOffNeeded = value;
                Notify("PlayOffNeeded");
            }
        }

        public int ResultHome
        {
            get
            {
                return 0;
            }
        }

        public int ResultVisitor
        {
            get
            {
                return 0;
            }
        }

        #endregion

        #region eventhandlers

        private void extendedMemberVisitor_ResultChanged(object sender, EventArgs e)
        {
            ExtendedTeamMember etm = sender as ExtendedTeamMember;
            int index = VisitorTeam.IndexOf(etm);
            if ((VisitorTeam[index].Result == HomeTeam[index].Result) && (!VisitorTeamPlayOff.Contains(etm)))
            {
                this.PlayOffNeeded = true;
                VisitorTeamPlayOff.Add(etm);
                HomeTeamPlayOff.Add(HomeTeam[index]);
            }
            else if (VisitorTeam[index].Result != HomeTeam[index].Result)
            {
                if (VisitorTeamPlayOff.Contains(etm))
                {
                    VisitorTeamPlayOff.Remove(etm);
                    HomeTeamPlayOff.Remove(HomeTeam[index]);
                    if (VisitorTeamPlayOff.Count == 0)
                    {
                        this.PlayOffNeeded = false;
                    }
                }
            }
        }

        private void extendedMemberHome_ResultChanged(object sender, EventArgs e)
        {
            ExtendedTeamMember etm = sender as ExtendedTeamMember;
            int index = HomeTeam.IndexOf(etm);
            //check if a playoff is needed
            if ((HomeTeam[index].Result == VisitorTeam[index].Result) && (!HomeTeamPlayOff.Contains(etm)))
            {
                this.PlayOffNeeded = true;
                HomeTeamPlayOff.Add(etm);
                VisitorTeamPlayOff.Add(VisitorTeam[index]);
            }
            else if (HomeTeam[index].Result != VisitorTeam[index].Result)
            {
                if (HomeTeamPlayOff.Contains(etm))
                {
                    HomeTeamPlayOff.Remove(etm);
                    VisitorTeamPlayOff.Remove(VisitorTeam[index]);
                    if (HomeTeam.Count == 0)
                    {
                        this.PlayOffNeeded = false;
                    }
                }
            }
        }
        #endregion*/
    }
}
