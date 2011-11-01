using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teammanager.Core
{
    public class TeamMember
    {
        private string _name;

        public TeamMember(string Name)
        {
            MemberName = Name;
        }


        #region properties

        public string MemberName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        #endregion
    }
}
