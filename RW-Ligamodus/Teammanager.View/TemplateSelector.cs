using System.Windows.Controls;
using System.Windows;
using Teammanager.Core;

namespace Teammanager.View
{
    public class TemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var team = item as Team;
            var member = item as TeamMember;

            if((team == null) && (member == null))
            {
                return base.SelectTemplate(item, container);
            }

            if (team != null)
            {
                return TeamTemplate;
            }
            else
            {
                return TeamMemberTemplate;
            }
        }


        #region properties

        public DataTemplate TeamMemberTemplate { get; set; }
        public DataTemplate TeamTemplate { get; set; }

        #endregion

    }
}
