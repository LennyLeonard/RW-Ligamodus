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
        private TournamentSettings _currentSettings;
        private TournamentSettings _actualSettings;
        private const string settingspath = @"settings.xml";

        public TournamentSettingsViewModel(RWLigamodusViewModel parent)
        {
            _buttonCommands = new CommandHelper(buttonCommands);
            _parent = parent;
            _currentSettings = new TournamentSettings();
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

        public void loadSavedSettings()
        {

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

        public TournamentSettings CurrentSettings
        {
            get
            {
                return _currentSettings;
            }
            set
            {
                _currentSettings = value;
                Notify("CurrentSettings");
            }
        }

        public TournamentSettings ActiveSettings
        {
            get
            {
                return _actualSettings;
            }
            set
            {
                _actualSettings = value;
                Notify("ActiveSettings");
            }
        }

        #endregion
    }
}
