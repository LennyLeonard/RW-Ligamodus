using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teammanager.Core
{
    public class ItemSelectHelper : BaseViewModel
    {
        private object obj;

        public object CurrentObject
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
                Notify("CurrentObject");
            }
        }
    }
}
