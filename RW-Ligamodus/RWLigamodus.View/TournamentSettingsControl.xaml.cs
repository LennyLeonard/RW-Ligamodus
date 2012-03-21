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

namespace RWLigamodus.View
{
    /// <summary>
    /// Interaktionslogik für TournamentSettingsControl.xaml
    /// </summary>
    public partial class TournamentSettingsControl : UserControl
    {
        public TournamentSettingsControl()
        {
            InitializeComponent();
        }

        #region dependency properties

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(object), typeof(TournamentSettingsControl),
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
            var currentObject = (d as TournamentSettingsControl);
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
