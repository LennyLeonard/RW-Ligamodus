using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teammanager.Core;

namespace RWLigamodus.ViewModel
{
    public class ExtendedTeamMember : TeamMember
    {
        private short[] series = new short[4];
        private int result;
        private int position;

        public ExtendedTeamMember(TeamMember member, int pos)
        {
            this.Name = member.Name;
            this.Position = pos;
        }

        #region propeties

        public short Series1
        {
            get
            {
                return series[0];
            }
            set
            {
                if ((value >= 0) && (value <= 100))
                {
                    series[0] = value;
                }
                Result = 0;//update
                Notify("Series1");
            }
        }

        public short Series2
        {
            get
            {
                return series[1];
            }
            set
            {
                if ((value >= 0) && (value <= 100))
                {
                    series[1] = value;
                }
                Result = 0;//update
                Notify("Series2");
            }
        }

        public short Series3
        {
            get
            {
                return series[2];
            }
            set
            {
                if ((value >= 0) && (value <= 100))
                {
                    series[2] = value;
                }
                Result = 0;//update
                Notify("Series3");
            }
        }

        public short Series4
        {
            get
            {
                return series[3];
            }
            set
            {
                if ((value >= 0) && (value <= 100))
                {
                    series[3] = value;
                }
                Result = 0;//update
                Notify("Series4");
            }
        }

        public int Result
        {
            get
            {
                return result;
            }
            set
            {
                result = Series1 + Series2 + Series3 + Series4;
                if (ResultChanged != null)
                {
                    ResultChanged(this, null);
                }
                Notify("Result");
            }
        }

        public int Point
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public int Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                Notify("Position");
            }
        }

        #endregion

        #region events

        public event EventHandler ResultChanged;

        #endregion
    }
}
