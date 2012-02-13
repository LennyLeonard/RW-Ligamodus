using System;
using System.Collections.Generic;
using System.Text;
using Teammanager.Core;

namespace RWLigamodus.ViewModel
{
    public class RWLigamodusViewModel : BaseViewModel
    {
        private CommandHelper _menuCommands;
        private CommandHelper _toolbarCommands;
        private PersistanceControl _persistance;
        private Match _currentMatch;

        public RWLigamodusViewModel()
        {
            _menuCommands = new CommandHelper(commandHandler);
            _toolbarCommands = new CommandHelper(commandHandler);
            _persistance = new PersistanceControl();
            _currentMatch = _persistance.deserializeMatch();
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

        #endregion
    }
}
