using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teammanager.Core;
using System.Collections.ObjectModel;

namespace RWLigamodus.ViewModel
{
    public class TournamentViewModel : BaseViewModel
    {
        private TournamentCompareHelper _helper;
        private bool _playOffNeeded = false;
        private string _homeName;
        private string _visitorName;
        private int _resultHome = 0;
        private int _resultVisitor = 0;
        private ObservableCollection<ExtendedTeamMember> _homeTeam;
        private ObservableCollection<ExtendedTeamMember> _visitorTeam;
        private ObservableCollection<ExtendedTeamMember> _homeTeamPlayOffs;
        private ObservableCollection<ExtendedTeamMember> _visitorTeamPlayOffs;

        public TournamentViewModel(Match actualMatch)
        {
            _helper = new TournamentCompareHelper();
            _homeTeam = new ObservableCollection<ExtendedTeamMember>();
            _visitorTeam = new ObservableCollection<ExtendedTeamMember>();
            _homeTeamPlayOffs = new ObservableCollection<ExtendedTeamMember>();
            _visitorTeamPlayOffs = new ObservableCollection<ExtendedTeamMember>();
            
            try
            {
                if (actualMatch == null)
                {
                    return;
                }

                this.HomeTeamName = actualMatch.HomeTeamName;
                this.VisitorTeamName = actualMatch.VisitorTeamName;

                for (int i = 0; i < actualMatch.HomeTeamMembers.Count; i++)
                {
                    ExtendedTeamMember extendedMember = new ExtendedTeamMember(actualMatch.HomeTeamMembers[i], 2 * i + 1);
                    extendedMember.ResultChanged += new EventHandler(extendedMemberHome_ResultChanged);
                    _homeTeam.Add(extendedMember);
                }
                for (int i = 0; i < actualMatch.VisitorTeamMembers.Count; i++)
                {
                    ExtendedTeamMember extendedMember = new ExtendedTeamMember(actualMatch.VisitorTeamMembers[i], 2 * i + 2);
                    extendedMember.ResultChanged += new EventHandler(extendedMemberVisitor_ResultChanged);
                    _visitorTeam.Add(extendedMember);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }


        #region properties

        // have to be deleted whe datacontext spy works
        public bool TournamentVisibility
        {
            get
            {
                return false;
            }
        }

        public string HomeTeamName
        {
            get
            {
                return _homeName;
            }
            set
            {
                _homeName = value;
                Notify("HomeTeamName");
            }
        }

        public string VisitorTeamName
        {
            get
            {
                return _visitorName;
            }
            set
            {
                _visitorName = value;
                Notify("VisitorTeamName");
            }
        }

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
                return _resultHome;
            }
            set
            {
                _resultHome = value;
                Notify("ResultHome");
            }
        }

        public int ResultVisitor
        {
            get
            {
                return _resultVisitor;
            }
            set
            {
                _resultVisitor = value;
                Notify("ResultVisitor");
            }
        }

        #endregion

        #region eventhandlers

        private void extendedMemberVisitor_ResultChanged(object sender, EventArgs e)
        {
            ExtendedTeamMember etm = sender as ExtendedTeamMember;
            int index = VisitorTeam.IndexOf(etm);
            this.PlayOffNeeded = _helper.compareAndSetResult(VisitorTeam[index], HomeTeam[index]);
            _helper.compareAndSetStatus(VisitorTeam[index], HomeTeam[index]);
            if ((VisitorTeam[index].Result == HomeTeam[index].Result) && (!VisitorTeamPlayOff.Contains(etm)))
            {
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
            this.PlayOffNeeded = _helper.compareAndSetResult(VisitorTeam[index], HomeTeam[index]);
            _helper.compareAndSetStatus(VisitorTeam[index], HomeTeam[index]);
            //check if a playoff is needed
            if ((HomeTeam[index].Result == VisitorTeam[index].Result) && (!HomeTeamPlayOff.Contains(etm)))
            {
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
        #endregion

    }
}
