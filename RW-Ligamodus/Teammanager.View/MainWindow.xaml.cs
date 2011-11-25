using System.Windows;
using Teammanager.Core;

namespace Teammanager.View
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Teammanager.Core.TeamManagerViewModel teamManagerViewModel;

        public MainWindow()
        {
            InitializeComponent();
            this.tree.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(tree_SelectedItemChanged);
            teamManagerViewModel = new Core.TeamManagerViewModel();
            this.DataContext = teamManagerViewModel;
            //teamManagerViewModel.Tree.CollectionChanged +=new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Tree_CollectionChanged);
        }

        void tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            teamManagerViewModel.SelectedTreeObject = e.NewValue;
        }
    }
}
