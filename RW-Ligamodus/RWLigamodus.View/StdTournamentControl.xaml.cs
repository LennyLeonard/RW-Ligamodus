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

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(object), typeof(StdTournamentControl),
            new UIPropertyMetadata(null, new PropertyChangedCallback(ViewModelChanged)));

        public object ViewModel
        {
            get
            {
                return (object)GetValue(ViewModelProperty);
            }
            set
            {
                SetValue(ViewModelProperty, value);
            }
        }

        #endregion


        #region dependency property callbacks


        private static void ViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var currentObject = (d as StdTournamentControl);
            if (currentObject == null)
            {
                return;
            }

            var newData = e.NewValue;
            if (newData == null)
            {
                return;
            }
            //connect newData to target
            currentObject.DataContext = newData;
        }

        #endregion
    }
}
