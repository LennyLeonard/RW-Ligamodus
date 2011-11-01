using System.Collections.ObjectModel;

namespace Teammanager.Core
{
    public class TeamManagerViewModel : BaseViewModel
    {
        private CommandHelper _menuHelper;
        private CommandHelper _menuBarHelper;
        private CommandHelper _treeViewHelper;
        private ObservableCollection<TreeViewChildrenViewModel> _tree;

        public TeamManagerViewModel()
        {
            _menuHelper = new CommandHelper(commandMenu);
            _menuBarHelper = new CommandHelper(commandMenuBar);
            _treeViewHelper = new CommandHelper(commandTreeView);
            _tree = new ObservableCollection<TreeViewChildrenViewModel>();

        }



        public void commandMenu(object parameter)
        {
            switch (parameter as string)
            {
                case "addTeam":
                    Tree.Add(new Team(null, "The A Team"));
                    break;
            }
        }

        public void commandMenuBar(object parameter)
        {
            switch (parameter as string)
            {

            }
        }

        public void commandTreeView(object parameter)
        {
            switch (parameter as string)
            {

            }
        }


        #region properties

        public CommandHelper MenuCommands
        {
            get
            {
                return _menuHelper;
            }
            set
            {
                _menuHelper = value;
                Notify("MenuCommands");
            }
        }

        public CommandHelper MenuBarCommands
        {
            get
            {
                return _menuBarHelper;
            }
            set
            {
                _menuBarHelper = value;
                Notify("MenuBarCommands");
            }
        }

        public CommandHelper TreeViewCommands
        {
            get
            {
                return _treeViewHelper;
            }
            set
            {
                _treeViewHelper = value;
                Notify("TreeViewCommands");
            }
        }

        public ObservableCollection<TreeViewChildrenViewModel> Tree
        {
            get
            {
                return _tree;
            }
            set
            {
                _tree = value;
                Notify("Tree");
            }
        }

        #endregion
    }
}
