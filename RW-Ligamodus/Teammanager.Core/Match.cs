using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Teammanager.Core
{
    [XmlRoot("Match")]
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

        [XmlAttribute("Home", DataType = "string")]
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

        [XmlAttribute("Visitor", DataType = "string")]
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

        [XmlArray("HomeMatchMembers")]
        [XmlArrayItem("Member")]
        public ObservableCollection<TeamMember> HomeTeamMembers
        {
            get
            {
                return _homeMembers;
            }
            set
            {
                _homeMembers = value;
                Notify("HomeTeamMembers");
            }
        }

        [XmlArray("VisitorMatchMembers")]
        [XmlArrayItem("Member")]
        public ObservableCollection<TeamMember> VisitorTeamMembers
        {
            get
            {
                return _visitorMembers;
            }
            set
            {
                _visitorMembers = value;
                Notify("VisitorTeamMembers");
            }
        }

        #endregion
    }
}
