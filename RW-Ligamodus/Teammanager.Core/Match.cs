using System.Collections.ObjectModel;

namespace Teammanager.Core
{
    public class Match : BaseViewModel
    {
        private ObservableCollection<TeamMember> _homeMembers;
        private ObservableCollection<TeamMember> _visitorMembers;
        private string _homeName;
        private string _visitorName;

        public Match()
        {
            _homeMembers = new ObservableCollection<TeamMember>();
            _visitorMembers = new ObservableCollection<TeamMember>();
        }


        #region properties

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

        public ObservableCollection<TeamMember> HomeTeamMembers
        {
            get
            {
                return _homeMembers;
            }
        }

        public ObservableCollection<TeamMember> VisitorTeamMembers
        {
            get
            {
                return _visitorMembers;
            }
        }

        public ObservableCollection<Position> Positions
        {
            get
            {
                return null;
            }
        }

        #endregion
    }
}
