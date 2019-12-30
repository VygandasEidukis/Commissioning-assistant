using Caliburn.Micro;
using commissioning_assistance.ViewModels.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        private bool _LoadingVisible;

        public bool LoadingVisible
        {
            get { return _LoadingVisible; }
            set { _LoadingVisible = value; NotifyOfPropertyChange(() => LoadingVisible); }
        }


        public MainViewModel()
        {
            MainViewModelSingleton s = MainViewModelSingleton.Instance;
            s.Item = this;
            ActivateItem(new DefaultViewModel());
        }
        
        public void LoadingScreenStatus(bool visible)
        {
            LoadingVisible = visible;
        }

    }
}
