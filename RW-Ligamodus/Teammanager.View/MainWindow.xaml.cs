using System.Globalization;
using System.Windows;
using Teammanager.View.Properties;

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
            //get current cultureinfo for language texts
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            Teammanager.View.Properties.Resources.Culture =cultureInfo;
            this.tree.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(tree_SelectedItemChanged);
            teamManagerViewModel = new Core.TeamManagerViewModel();
            this.DataContext = teamManagerViewModel;
            
        }

        void tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            teamManagerViewModel.SelectedTreeObject = e.NewValue;
        }
    }
}
