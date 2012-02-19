using System;
using System.Collections.Generic;
using System.Text;
using Teammanager.Core;
using System.Collections.ObjectModel;

namespace RWLigamodus.ViewModel
{
    public class RWLigamodusViewModel : BaseViewModel
    {
        private CommandHelper _menuCommands;
        private CommandHelper _toolbarCommands;
        private PersistanceControl _persistance;
        private Match _currentMatch;
        private ObservableCollection<ExtendedTeamMember> _homeTeam;
        private ObservableCollection<ExtendedTeamMember> _visitorTeam;

        public RWLigamodusViewModel()
        {
            _homeTeam = new ObservableCollection<ExtendedTeamMember>();
            _visitorTeam = new ObservableCollection<ExtendedTeamMember>();
            _menuCommands = new CommandHelper(commandHandler);
            _toolbarCommands = new CommandHelper(commandHandler);
            try
            {
                _persistance = new PersistanceControl();
                _currentMatch = _persistance.deserializeMatch();
                //add teams to properties
                for (int i = 0; i < _currentMatch.HomeTeamMembers.Count; i++)
                {
                    ExtendedTeamMember extendedMember = new ExtendedTeamMember(_currentMatch.HomeTeamMembers[i], 2 * i + 1);
                    _homeTeam.Add(extendedMember);
                }
                for (int i = 0; i < _currentMatch.VisitorTeamMembers.Count; i++)
                {
                    ExtendedTeamMember extendedMember = new ExtendedTeamMember(_currentMatch.VisitorTeamMembers[i], 2 * i + 2);
                    _visitorTeam.Add(extendedMember);
                }
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
                    break;
                case "exportResult":
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

        public ObservableCollection<ExtendedTeamMember> HomeTeam
        {
            get
            {
                return _homeTeam;
            }
        }

        public ObservableCollection<ExtendedTeamMember> VisitorTeam
        {
            get
            {
                return _visitorTeam;
            }
        }


        #endregion
    }
}
