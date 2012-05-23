using System;
using System.Collections.Generic;
using System.Text;
using Teammanager.Core;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace RWLigamodus.ViewModel
{
    public class RWLigamodusViewModel : BaseViewModel
    {
        private CommandHelper _menuCommands;
        private CommandHelper _toolbarCommands;
        private PersistanceControl _persistance;
        private Match _currentMatch;
        private TournamentViewModel _tnmtViewModel;
        private TournamentSettingsViewModel _tnmtSettViewModel;
        private bool _TournamentVisibility = true;
        private ProcessStartInfo _teamManagerProcess;
        private Process _processStarted = null;


        public RWLigamodusViewModel()
        {
            _menuCommands = new CommandHelper(commandHandler);
            _toolbarCommands = new CommandHelper(commandHandler);
            _teamManagerProcess = new ProcessStartInfo("Teammanager.View.exe");
            try
            {
                _persistance = new PersistanceControl();
                _currentMatch = _persistance.deserializeMatch();
                //add teams to tournamentvm
                _tnmtViewModel = new TournamentViewModel(_currentMatch);
                _tnmtSettViewModel = new TournamentSettingsViewModel(this);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }


        private void commandHandler(object param)
        {
            switch (param as string)
            {
                case "newTnmt":
                    if (_processStarted == null)
                    {
                        _processStarted = Process.Start(_teamManagerProcess);
                    }
                    break;
                case "exportResult":
                    break;
                case "openSettings":
                    this.TournamentVisibility = false;
                    break;
                case "exit":
                    
                    break;
            }
        }

        #region properties

        public CommandHelper MenuCommands
        {
            get
            {
                return _menuCommands;
            }
            set
            {
                _menuCommands = value;
                Notify("MenuCommands");
            }
        }

        public CommandHelper ToolbarCommands
        {
            get
            {
                return _toolbarCommands;
            }
            set
            {
                _toolbarCommands = value;
                Notify("ToolbarCommands");
            }
        }

        public TournamentViewModel TnmtViewModel
        {
            get
            {
                return _tnmtViewModel;
            }
        }

        public TournamentSettingsViewModel TnmtSettingsViewModel
        {
            get
            {
                return _tnmtSettViewModel;
            }
            set
            {
                _tnmtSettViewModel = value;
                Notify("TnmtSettingsViewModel");
            }
        }

        public bool TournamentVisibility
        {
            get
            {
                return _TournamentVisibility;
            }
            set
            {
                _TournamentVisibility = value;
                Notify("TournamentVisibility");
                Notify("SettingsVisibility");
            }
        }

        public bool SettingsVisibility
        {
            get
            {
                return !this.TournamentVisibility;
            }
        }

        #endregion
    }
}
