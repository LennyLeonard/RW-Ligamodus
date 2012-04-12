using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teammanager.Core;

namespace RWLigamodus.ViewModel
{
    public class TournamentSettingsViewModel : BaseViewModel
    {
        private CommandHelper _buttonCommands;
        private RWLigamodusViewModel _parent;

        public TournamentSettingsViewModel(RWLigamodusViewModel parent)
        {
            _buttonCommands = new CommandHelper(buttonCommands);
            _parent = parent;
        }

        private void buttonCommands(object parameter)
        {
            switch (parameter as string)
            {
                case "cancel":
                    _parent.TournamentVisibility = true;
                    break;
                case "ok":
                    _parent.TournamentVisibility = true;
                    break;
            }
        }

        #region properties

        public CommandHelper ButtonCommands
        {
            get
            {
                return _buttonCommands;
            }
            set
            {
                _buttonCommands = value;
                Notify("ButtonCommands");
            }
        }

        // have to be deleted whe datacontext spy works
        public bool SettingsVisibility
        {
            get
            {
                return false;
            }
        }

        #endregion
    }
}
