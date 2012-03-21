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
        private short[] playOffShot = new short[5];
        private bool[] seriesChanged = new bool[4];
        private int result = 0;
        private int status = -1;
        private short point = 0;
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
                    Series1Changed = true;
                }
                Result = 0;//update
                Notify("Series1");
            }
        }

        public bool Series1Changed
        {
            get
            {
                return seriesChanged[0];
            }
            set
            {
                seriesChanged[0] = value;
                Notify("Series1Changed");
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
                    Series2Changed = true;
                }
                Result = 0;//update
                Notify("Series2");
            }
        }

        public bool Series2Changed
        {
            get
            {
                return seriesChanged[1];
            }
            set
            {
                seriesChanged[1] = value;
                Notify("Series2Changed");
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
                    Series3Changed = true;
                }
                Result = 0;//update
                Notify("Series3");
            }
        }

        public bool Series3Changed
        {
            get
            {
                return seriesChanged[2];
            }
            set
            {
                seriesChanged[2] = value;
                Notify("Series3Changed");
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
                    Series4Changed = true;
                }
                Result = 0; //update value
                Notify("Series4");
            }
        }

        public bool Series4Changed
        {
            get
            {
                return seriesChanged[3];
            }
            set
            {
                seriesChanged[3] = value;
                Notify("Series4Changed");
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

        public short Point
        {
            get
            {
                return point;
            }
            set
            {
                point = value;
                Notify("Point");
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

        public short PlayOffShot1
        {
            get
            {
                return playOffShot[0];
            }
            set
            {
                if ((value <= 10) && (value >= 0))
                {
                    playOffShot[0] = value;
                }
                Notify("PlayOffShot1");
            }
        }

        public short PlayOffShot2
        {
            get
            {
                return playOffShot[1];
            }
            set
            {
                if ((value <= 10) && (value >= 0))
                {
                    playOffShot[1] = value;
                }
                Notify("PlayOffShot2");
            }
        }

        public short PlayOffShot3
        {
            get
            {
                return playOffShot[2];
            }
            set
            {
                if ((value <= 10) && (value >= 0))
                {
                    playOffShot[2] = value;
                }
                Notify("PlayOffShot3");
            }
        }

        public short PlayOffShot4
        {
            get
            {
                return playOffShot[3];
            }
            set
            {
                if ((value <= 10) && (value >= 0))
                {
                    playOffShot[3] = value;
                }
                Notify("PlayOffShot4");
            }
        }

        public short PlayOffShot5
        {
            get
            {
                return playOffShot[4];
            }
            set
            {
                if ((value <= 10) && (value >= 0))
                {
                    playOffShot[4] = value;
                }
                Notify("PlayOffShot5");
            }
        }

        /// <summary>
        /// -1 = start status
        ///  0 = not leading status
        ///  1 = leading status
        ///  2 = match win status
        /// </summary>
        public int MemberStatus
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                Notify("MemberStatus");
            }
        }

        #endregion

        #region events

        public event EventHandler ResultChanged;

        #endregion
    }
}
