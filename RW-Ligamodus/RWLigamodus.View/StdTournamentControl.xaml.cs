using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using RWLigamodus.ViewModel;

namespace RWLigamodus.View
{
    /// <summary>
    /// Interaktionslogik für StdTournamentControl.xaml
    /// </summary>
    public partial class StdTournamentControl : UserControl
    {
        public StdTournamentControl()
        {
            InitializeComponent();
        }


        #region dependency properties

        public static readonly DependencyProperty HomeTeamTableProperty =
            DependencyProperty.Register("HomeTable", typeof(ObservableCollection<ExtendedTeamMember>), typeof(StdTournamentControl),
            new UIPropertyMetadata(new ObservableCollection<ExtendedTeamMember>(), new PropertyChangedCallback(HomeTeamTableChanged)));

        public static readonly DependencyProperty VisitorTeamTableProperty =
            DependencyProperty.Register("VisitorTable", typeof(ObservableCollection<ExtendedTeamMember>), typeof(StdTournamentControl),
            new UIPropertyMetadata(new ObservableCollection<ExtendedTeamMember>(), new PropertyChangedCallback(VisitorTeamTableChanged)));

        #endregion



        #region dependency property callbacks

        private static void HomeTeamTableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var currentObject = (d as StdTournamentControl);
            if (currentObject == null)
            {
                return;
            }

            var newData = (e.NewValue as ObservableCollection<ExtendedTeamMember>);
            if (newData == null)
            {
                return;
            }
            //connect newData to target
            currentObject.TeamListHome.ItemsSource = newData;
        }

        private static void VisitorTeamTableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var currentObject = (d as StdTournamentControl);
            if (currentObject == null)
            {
                return;
            }

            var newData = (e.NewValue as ObservableCollection<ExtendedTeamMember>);
            if (newData == null)
            {
                return;
            }
            //connect newData to target
            currentObject.TeamListVisitors.ItemsSource = newData;
        }

        public ObservableCollection<ExtendedTeamMember> HomeTable
        {
            get
            {
                return (ObservableCollection<ExtendedTeamMember>)GetValue(HomeTeamTableProperty);
            }
            set
            {
                SetValue(HomeTeamTableProperty, value);
                
            }
        }

        public ObservableCollection<ExtendedTeamMember> VisitorTable
        {
            get
            {
                return (ObservableCollection<ExtendedTeamMember>)GetValue(VisitorTeamTableProperty);
            }
            set
            {
                SetValue(VisitorTeamTableProperty, value);

            }
        }

        #endregion
    }
}
