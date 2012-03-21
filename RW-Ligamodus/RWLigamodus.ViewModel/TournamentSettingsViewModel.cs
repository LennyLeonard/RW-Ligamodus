using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teammanager.Core;

namespace RWLigamodus.ViewModel
{
    public class TournamentSettingsViewModel : BaseViewModel
    {
        private bool _isTimeControlEnabled;

        public TournamentSettingsViewModel()
        {

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

        #endregion
    }
}
