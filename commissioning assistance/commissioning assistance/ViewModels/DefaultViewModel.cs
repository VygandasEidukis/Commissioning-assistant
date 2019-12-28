using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.ViewModels
{
    class DefaultViewModel : Conductor<object>
    {
        public void HomeButton()
        {
            ActivateItem(new HomeViewModel());
        }

        public void CreateButton()
        {
            ActivateItem(new CreateCommissionViewModel());
        }

        public void ListButton()
        {
            ActivateItem(new ListCommissionViewModel());
        }

        public void CalendarButton()
        {
            ActivateItem(new CalendarViewModel());
        }

        public void StatisticsButton()
        {
            ActivateItem(new StatisticsViewModel());
        }
    }
}
