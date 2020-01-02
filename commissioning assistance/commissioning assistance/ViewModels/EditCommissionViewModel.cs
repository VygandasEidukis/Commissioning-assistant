using Caliburn.Micro;
using commissioning_assistance.Helpers;
using commissioning_assistance.Models;
using commissioning_assistance.Models.Commission;
using commissioning_assistance.Models.DataAccess;
using commissioning_assistance.ViewModels.Singletons;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.ViewModels
{
    class EditCommissionViewModel : Screen
    {
        public MainViewModel LoadingScreen { get => MainViewModelSingleton.Instance.Item; }

        #region Variables
        public List<int> RemoveReferences { get; set; }
        public List<ImageModel> AddReferences { get; set; }

        private ImageModel _CurrentImage;

        public ImageModel CurrentImage
        {
            get => _CurrentImage;
            set
            {
                _CurrentImage = value;
                NotifyOfPropertyChange(() => CurrentImage);
            }
        }

        private BindableCollection<ProductType> _ProductTypes;

        public BindableCollection<ProductType> ProductTypes
        {
            get { return _ProductTypes; }
            set
            {
                _ProductTypes = value;
                NotifyOfPropertyChange(() => ProductTypes);
            }
        }

        private InstagramCommission _Commission;

        private BindableCollection<string> _Currencies;

        public BindableCollection<string> Currencies
        {
            get { return _Currencies; }
            set
            {
                _Currencies = value;
                NotifyOfPropertyChange(() => Currencies);
            }
        }

        public InstagramCommission Commission
        {
            get => _Commission;
            set
            {
                _Commission = value;
                NotifyOfPropertyChange(() => Commission);
            }
        }

        #endregion

        public EditCommissionViewModel(InstagramCommission commission)
        {
            Commission = commission;
            Currencies = new BindableCollection<string>();
            ProductTypes = new BindableCollection<ProductType>();
            CurrentImage = commission.References[0];
            RemoveReferences = new List<int>();
            AddReferences = new List<ImageModel>();
            
            Task.Run(Loaded);
        }

        private async Task Loaded()
        {
            LoadingScreen.LoadingScreenStatus(true);

            //adding currency
            Currencies.AddRange(GetCurrencies());
            Commission.CurrencyType = Currencies.Single(currency => currency.ToString() == GetCurrentCultureCurrency());

            //adding product types
            using var uow = new UnitOfWork(new DatabaseDbContext());
            var items = uow.ProductTypes.GetEntities();

            ProductTypes.AddRange(items);
            Commission.ProductType = uow.ProductTypes.GetEntity(Commission.ProductTypeId);
            NotifyOfPropertyChange(() => Commission);


            LoadingScreen.LoadingScreenStatus(false);
        }

        public List<string> GetCurrencies()
        {
            var currenciesEnums = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(ci => ci.LCID).Distinct()
                .Select(id => new RegionInfo(id))
                .GroupBy(r => r.ISOCurrencySymbol).ToList();

            List<string> currencies = new List<string>();

            foreach (var currency in currenciesEnums)
            {
                currencies.Add(currency.Key.ToString());
            }

            return currencies;
        }

        public string GetCurrentCultureCurrency()
        {
            return new RegionInfo(CultureInfo.CurrentCulture.LCID).ISOCurrencySymbol.ToString();
        }

        public void UpdateCommissionButton()
        {
            if(Commission.Verify())
            {
                using var unitOfWork = new UnitOfWork(new DatabaseDbContext());
                unitOfWork.Complete();

                //unitOfWork.Commissions.Add(Commission);
                /*
                Commission.Update();
                using DatabaseDbContext context = new DatabaseDbContext();
                
                foreach (int image in RemoveReferences)
                    context.Images.Where(reff => reff.Id == image).Delete();

                context.SaveChanges();
                */
                ((Parent as dynamic).Parent as dynamic).ActivateItem(new ProductViewModel());
            }
        }

        public void AddImageButton()
        {
            Commission.References = ImageHelper.GetImages(Commission.References);
            if (Commission.References[0] != null)
            {
                CurrentImage = Commission.References[0];
            }
        }

        public void PreviousButton()
        {
            if (Commission.References.Count > 0)
            {
                int val = ImageHelper.PreviousInCycle(Commission.References, CurrentImage);
                CurrentImage = Commission.References[val];
            }
        }

        public void NextButton()
        {
            if (Commission.References.Count > 0)
            {
                int val = ImageHelper.NextInCycle(Commission.References, CurrentImage);
                CurrentImage = Commission.References[val];
            }
        }

        public void RemoveImageButton()
        {
            if (CurrentImage != null)
            {
                if(CurrentImage.Id != 0)
                    RemoveReferences.Add(CurrentImage.Id);

                Commission.References.Remove(CurrentImage);
            }
            CurrentImage = null;
            if (Commission.References.Count > 0)
            {
                CurrentImage = Commission.References[0];
            }

        }

    }
}
