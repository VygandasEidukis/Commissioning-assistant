using Caliburn.Micro;
using System;

namespace commissioning_assistance.ViewModels
{
    public class DefaultViewModel : Conductor<object>
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
            //collects garbage so if user canceled commission update it restores defaults instantly
            GC.Collect();

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
