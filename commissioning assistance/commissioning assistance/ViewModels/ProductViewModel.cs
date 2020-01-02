using Caliburn.Micro;
using commissioning_assistance.Models;
using commissioning_assistance.Models.Commission;
using commissioning_assistance.Models.DataAccess;
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
            set 
            { 
                _Commissions = value;
                NotifyOfPropertyChange(() => Commissions);
            }
        }

        public ProductViewModel()
        {
            Commissions = new BindableCollection<IBaseCommission>();

            Task.Run(LoadData);
        }

        private async Task LoadData()
        {
            MainViewModelSingleton singleton = MainViewModelSingleton.Instance;
            singleton.Item.LoadingScreenStatus(true);

            using var unitOfWork = new UnitOfWork(new DatabaseDbContext());
            Commissions.AddRange(unitOfWork.Commissions.GetFullCommissions());
                
            singleton.Item.LoadingScreenStatus(false);
        }

        public void ProductClicked(IBaseCommission commission)
        {
            ActivateItem(new EditCommissionViewModel(commission as InstagramCommission));
        }

        public override void DeactivateItem(object item, bool close)
        {
            NotifyOfPropertyChange(() => Commissions);
            base.DeactivateItem(item, close);
        }
    }
}
