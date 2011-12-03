using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teammanager.Core
{
    public class Position : BaseViewModel
    {
        private ushort _positionNumber;
        private TeamMember _member;

        public Position(ushort posNmbr)
        {
            _positionNumber = posNmbr;
        }

        #region properties

        public TeamMember Member
        {
            get
            {
                return _member;
            }
            set
            {
                _member = value;
                Notify("Member");
            }
        }

        public ushort PositionNumber
        {
            get
            {
                return _positionNumber;
            }
        }

        #endregion
    }
}
