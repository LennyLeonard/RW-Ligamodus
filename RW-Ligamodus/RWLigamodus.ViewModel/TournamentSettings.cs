using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teammanager.Core;

namespace RWLigamodus.ViewModel
{
    [Serializable]
    public class TournamentSettings : BaseViewModel
    {
        private bool _isTimeControlEnabled;
        private int _prepTime;
        private int _proofTime;
        private int _tournamentTime;
        private int _timeoutInterval;
        private string _league;
        private string _weapon;
        private string _selectedGeneratorScript = string.Empty;

        public TournamentSettings()
        {
            this.PrepTime = 5;
            this.ProofTime = 10;
            this.TournamentTime = 60;
            this.TimeOutInterval = 30;
        }

        #region properties

        public bool IsTimeControlEnabled
        {
            get
            {
                return _isTimeControlEnabled;
            }
            set
            {
                _isTimeControlEnabled = value;
                Notify("IsTimeControlEnabled");
            }
        }

        public int PrepTime
        {
            get
            {
                return _prepTime;
            }
            set
            {
                _prepTime = value;
                Notify("PrepTime");
            }
        }

        public int ProofTime
        {
            get
            {
                return _proofTime;
            }
            set
            {
                _proofTime = value;
                Notify("ProofTime");
            }
        }

        public int TournamentTime
        {
            get
            {
                return _tournamentTime;
            }
            set
            {
                _tournamentTime = value;
                Notify("TournamentTime");
            }
        }

        public int TimeOutInterval
        {
            get
            {
                return _timeoutInterval;
            }
            set
            {
                _timeoutInterval = value;
                Notify("TimeOutInterval");
            }
        }

        public string League
        {
            get
            {
                return _league;
            }
            set
            {
                _league = value;
                Notify("League");
            }
        }

        public string Weapon
        {
            get
            {
                return _weapon;
            }
            set
            {
                _weapon = value;
                Notify("Weapon");
            }
        }

        public string SelectedGeneratorScript
        {
            get
            {
                return _selectedGeneratorScript;
            }
            set
            {
                _selectedGeneratorScript = value;
                Notify("SelectedGeneratorScript");
            }
        }

        #endregion
    }
}
