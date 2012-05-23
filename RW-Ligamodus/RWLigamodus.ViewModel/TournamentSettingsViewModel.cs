using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teammanager.Core;
using System.Xml.Serialization;
using System.IO;

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
        XmlSerializer serializer;

        public TournamentSettingsViewModel(RWLigamodusViewModel parent)
        {
            _buttonCommands = new CommandHelper(buttonCommands);
            _parent = parent;
            _currentSettings = new TournamentSettings();
            serializer = new XmlSerializer(typeof(TournamentSettings));

            //load persistent settings
            if ((_actualSettings = this.loadSettings()) == null)
            {
                _actualSettings = new TournamentSettings();
                _actualSettings.setDefaultVaules(this.Leagues[0], this.WeaponTypes[0]);
            }
            this.setCurrent();
        }

        private void buttonCommands(object parameter)
        {
            switch (parameter as string)
            {
                case "cancel":
                    _parent.TournamentVisibility = true;
                    this.setCurrent();
                    break;
                case "ok":
                    _parent.TournamentVisibility = true;
                    this.setActive();
                    this.saveSettings(this.ActiveSettings);
                    break;
            }
        }

        public void setCurrent()
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

        public void setActive()
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

        public bool saveSettings(TournamentSettings settings)
        {
            FileStream file = new FileStream(SETTINGSPATH, FileMode.Create);

            try
            {
                serializer.Serialize(file, settings);
                file.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public TournamentSettings loadSettings()
        {
            TournamentSettings savedSettings;
            FileStream file;

            if (File.Exists(SETTINGSPATH))
            {
                try
                {
                    file = new FileStream(SETTINGSPATH, FileMode.Open);
                    savedSettings = (TournamentSettings)serializer.Deserialize(file);
                    return savedSettings;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
            {
                return null;
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
