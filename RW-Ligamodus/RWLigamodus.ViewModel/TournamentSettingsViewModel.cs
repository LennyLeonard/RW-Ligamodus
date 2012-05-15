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
        private const string SETTINGSPATH = @"settings.xml";
        private const string GENERATORPATH = @"./generators/";
        private List<string> _leagues = new List<string>() {"Württemberg-Liga", "Verbandsliga Süd" , "Landesliga Süd", "Bezirksoberliga", "Bezirksliga A", "Bezirksliga B", "Kreisoberliga", "Kreisliga" };
        private List<string> _weaponTypes = new List<string>() { "Luftgewehr", "Luftpistole", "KK-Gewehr" };
        private List<string> _generatorScripts = new List<string>();

        public TournamentSettingsViewModel(RWLigamodusViewModel parent)
        {
            _buttonCommands = new CommandHelper(buttonCommands);
            _parent = parent;
            _currentSettings = new TournamentSettings();
            _actualSettings = new TournamentSettings();
        }

        private void buttonCommands(object parameter)
        {
            switch (parameter as string)
            {
                case "cancel":
                    _parent.TournamentVisibility = true;
                    this.cancelAction();
                    break;
                case "ok":
                    _parent.TournamentVisibility = true;
                    this.okAction();
                    break;
            }
        }

        public void loadSavedSettings()
        {
            // implement xmlserializer
        }

        public void cancelAction()
        {
            this.CurrentSettings.IsTimeControlEnabled = this.ActiveSettings.IsTimeControlEnabled;
            this.CurrentSettings.League = this.ActiveSettings.League;
            this.CurrentSettings.PrepTime = this.ActiveSettings.PrepTime;
            this.CurrentSettings.ProofTime = this.ActiveSettings.ProofTime;
            this.CurrentSettings.SelectedGeneratorScript = this.ActiveSettings.SelectedGeneratorScript;
            this.CurrentSettings.TimeOutInterval = this.ActiveSettings.TimeOutInterval;
            this.CurrentSettings.TournamentTime = this.ActiveSettings.TournamentTime;
            this.CurrentSettings.Weapon = this.ActiveSettings.Weapon;
        }

        public void okAction()
        {
            this.ActiveSettings.IsTimeControlEnabled = this.CurrentSettings.IsTimeControlEnabled;
            this.ActiveSettings.League = this.CurrentSettings.League;
            this.ActiveSettings.PrepTime = this.CurrentSettings.PrepTime;
            this.ActiveSettings.ProofTime = this.CurrentSettings.ProofTime;
            this.ActiveSettings.SelectedGeneratorScript = this.CurrentSettings.SelectedGeneratorScript;
            this.ActiveSettings.TimeOutInterval = this.CurrentSettings.TimeOutInterval;
            this.ActiveSettings.TournamentTime = this.CurrentSettings.TournamentTime;
            this.ActiveSettings.Weapon = this.CurrentSettings.Weapon;
        }

        public List<string> listGeneratorScrips()
        {
            // TODO
            return null;
        }

        private bool saveSettings(TournamentSettings settings)
        {
            // TODO
            return true;
        }

        private TournamentSettings loadSettings()
        {
            // TODO
            return null;
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
        }

        public List<string> Leagues
        {
            get
            {
                return _leagues;
            }
        }

        public List<string> WeaponTypes
        {
            get
            {
                return _weaponTypes;
            }
        }

        public List<string> GeneratorScripts
        {
            get
            {
                return _generatorScripts;
            }
            set
            {
                _generatorScripts = value;
                Notify("GeneratorScripts");
            }
        }
        #endregion
    }
}
