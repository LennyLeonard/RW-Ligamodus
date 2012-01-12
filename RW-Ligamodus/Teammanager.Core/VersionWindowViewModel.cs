using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teammanager.Core
{
    public class VersionWindowViewModel : BaseViewModel
    {
        private string _currentVersion;

        public VersionWindowViewModel()
        {
            VersionInfoText = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        #region properties

        public string VersionInfoText
        {
            get
            {
                return _currentVersion;
            }
            set
            {
                _currentVersion = value;
                Notify("VersionInfoText");
            }
        }

        #endregion
    }
}
