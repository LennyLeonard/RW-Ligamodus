using System.Globalization;
using System.Windows;
using Teammanager.View.Properties;

namespace Teammanager.View
{
    /// <summary>
    /// interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Teammanager.Core.TeamManagerViewModel teamManagerViewModel;
        private License license = null;
        private VersionWindow versionWindow = null;

        public MainWindow()
        {
            InitializeComponent();
            //get current cultureinfo for language texts
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            Teammanager.View.Properties.Resources.Culture =cultureInfo;
            this.tree.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(tree_SelectedItemChanged);
            this.closeMenuItem.Click += new RoutedEventHandler(closeMenuItem_Click);
            this.licenceMenuItem.Click += new RoutedEventHandler(licenceMenuItem_Click);
            this.versionMenuItem.Click += new RoutedEventHandler(versionMenuItem_Click);
            this.Closing +=new System.ComponentModel.CancelEventHandler(MainWindow_Closing);
            teamManagerViewModel = new Core.TeamManagerViewModel();
            this.DataContext = teamManagerViewModel;
            
        }

        //minimal logic to handle some low-level functionality
        void tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            teamManagerViewModel.SelectedTreeObject = e.NewValue;
        }

        void closeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (versionWindow != null)
            {
                versionWindow.Close();
            }
            if (license != null)
            {
                license.Close();
            }
        }

        void licenceMenuItem_Click(object sender, RoutedEventArgs e)
        {
            license = new License();
            license.Owner = this;
            license.Show();
        }

        void versionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            versionWindow = new VersionWindow();
            versionWindow.Owner = this;
            versionWindow.Show();
        }
    }
}
