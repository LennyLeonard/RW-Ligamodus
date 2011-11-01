using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Teammanager.Core
{
    public class Team : TreeViewChildrenViewModel
    {
        private string _emblemPath;

        public Team(TreeViewChildrenViewModel parent, string name) : base (parent, name)
        {

        }

        #region properties

        public string EmblemPath
        {
            get
            {
                return _emblemPath;
            }
            set
            {
                _emblemPath = value;
                Notify("EmblemPath");
            }
        }

        #endregion
    }
}
