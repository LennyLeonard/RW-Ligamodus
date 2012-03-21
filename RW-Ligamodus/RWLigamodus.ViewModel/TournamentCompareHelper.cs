using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RWLigamodus.ViewModel
{
    public class TournamentCompareHelper
    {
        /// <summary>
        /// Compares the results of the two team-members and sets the points
        /// </summary>
        /// <param name="a">ExtendedTeamMember of team A</param>
        /// <param name="b">ExtendedTeamMember of team B</param>
        /// <returns>PlayOff needed?</returns>
        public bool compareAndSetResult(ExtendedTeamMember a, ExtendedTeamMember b)
        {
            if (a.Series4Changed && b.Series4Changed)
            {
                if (a.Result > b.Result)
                {
                    a.Point = 1;
                }
                else if (a.Result < b.Result)
                {
                    b.Point = 1;
                }
                else
                {
                    //check playoff results 
                    a.Point = 0;
                    b.Point = 0;
                    return true;
                }
            }
            return false;
        }

        public void compareAndSetStatus(ExtendedTeamMember a, ExtendedTeamMember b)
        {
            if (a.Result > b.Result)
            {
                if (a.Series1Changed && a.Series2Changed && a.Series3Changed && b.Series4Changed && b.Series1Changed && b.Series2Changed && b.Series3Changed && b.Series4Changed)
                {
                    a.MemberStatus = 2; //match won
                    b.MemberStatus = 0;
                }
                // first series compared
                else if (a.Series1Changed && b.Series1Changed && !a.Series2Changed && !b.Series2Changed && !a.Series3Changed && !b.Series3Changed && !a.Series4Changed && !b.Series4Changed)
                {
                    a.MemberStatus = 1;
                    b.MemberStatus = 0;
                }
                // second series compared
                else if (a.Series1Changed && b.Series1Changed && a.Series2Changed && b.Series2Changed && !a.Series3Changed && !b.Series3Changed && !a.Series4Changed && !b.Series4Changed)
                {
                    a.MemberStatus = 1;
                    b.MemberStatus = 0;
                }
                //third series comapred
                else if (a.Series1Changed && b.Series1Changed && a.Series2Changed && b.Series2Changed && a.Series3Changed && !b.Series3Changed && a.Series4Changed && !b.Series4Changed)
                {
                    a.MemberStatus = 1;
                    b.MemberStatus = 0;
                }
            }
            else if (a.Result < b.Result)
            {
                //final status
                if (a.Series1Changed && a.Series2Changed && a.Series3Changed && b.Series4Changed && b.Series1Changed && b.Series2Changed && b.Series3Changed && b.Series4Changed)
                {
                    a.MemberStatus = 0;
                    b.MemberStatus = 2; //match won
                }
                // first series compared
                else if (a.Series1Changed && b.Series1Changed && !a.Series2Changed && !b.Series2Changed && !a.Series3Changed && !b.Series3Changed && !a.Series4Changed && !b.Series4Changed)
                {
                    a.MemberStatus = 0;
                    b.MemberStatus = 1;
                }
                // second series compared
                else if (a.Series1Changed && b.Series1Changed && a.Series2Changed && b.Series2Changed && !a.Series3Changed && !b.Series3Changed && !a.Series4Changed && !b.Series4Changed)
                {
                    a.MemberStatus = 0;
                    b.MemberStatus = 1;
                }
                //third series comapred
                else if (a.Series1Changed && b.Series1Changed && a.Series2Changed && b.Series2Changed && a.Series3Changed && !b.Series3Changed && a.Series4Changed && !b.Series4Changed)
                {
                    a.MemberStatus = 0;
                    b.MemberStatus = 1;
                }
            }
        }

    }
}
