using Caliburn.Micro;
using commissioning_assistance.Models;
using commissioning_assistance.Models.Commission;
using commissioning_assistance.ViewModels.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.ViewModels
{
    public class ProductViewModel : Conductor<object>
    {
        private BindableCollection<IBaseCommission> _Commissions;

        public BindableCollection<IBaseCommission> Commissions
        {
            get { return _Commissions; }
            set { _Commissions = value; }
        }

        public ProductViewModel()
        {
            Commissions = new BindableCollection<IBaseCommission>();

            LoadData();
        }

        private async void LoadData()
        {
            MainViewModelSingleton singleton = MainViewModelSingleton.Instance;
            singleton.Item.LoadingScreenStatus(true);

            Task t = new Task(() => 
            {
                using var context = new DatabaseDbContext();
                Commissions.AddRange(context.Commissions);
            });

            t.Start();
            await t.ContinueWith((ats) => singleton.Item.LoadingScreenStatus(false));
        }

    }
}
