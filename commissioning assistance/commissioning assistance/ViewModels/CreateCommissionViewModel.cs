﻿using Caliburn.Micro;
using commissioning_assistance.Helpers;
using commissioning_assistance.Models;
using commissioning_assistance.Models.Commission;
using commissioning_assistance.Models.DataAccess;
using commissioning_assistance.ViewModels.Singletons;
using System.Linq;
using System.Threading.Tasks;

namespace commissioning_assistance.ViewModels
{
    public class CreateCommissionViewModel : Screen
    {
        public MainViewModel LoadingScreen { get => MainViewModelSingleton.Instance.Item; }

        #region Variables
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

        public CreateCommissionViewModel()
        {
            Commission = new InstagramCommission();
            Currencies = new BindableCollection<string>();
            ProductTypes = new BindableCollection<ProductType>();

            Task.Run(Loaded);
        }

        private async Task Loaded()
        {
            LoadingScreen.LoadingScreenStatus(true);

            //adding currency
            Currencies.AddRange(CultureManager.GetCurrencySymbols());
            Commission.CurrencyType = Currencies.Single(currency => currency.ToString() == CultureManager.GetLocalCurrencySymbol());

            //adding product types
            using var uow = new UnitOfWork(new DatabaseDbContext());

            var items = uow.ProductTypes.GetEntities();
            ProductTypes.AddRange(items);
            Commission.ProductType = ProductTypes.Count > 0 ? ProductTypes[0] : null;
            NotifyOfPropertyChange(() => Commission);


            LoadingScreen.LoadingScreenStatus(false);

           
        }

        public void AddImageButton()
        {
            Commission.References = ImageHelper.GetImages(Commission.References);
            if(Commission.References[0] != null)
            {
                CurrentImage = Commission.References[0];
            }
        }

        public void PreviousButton()
        {
            if(Commission.References.Count > 0)
            {
                int index = ImageHelper.PreviousInCycle(Commission.References, CurrentImage);
                CurrentImage = Commission.References[index];
            }
        }

        public void NextButton()
        {
            if (Commission.References.Count > 0)
            {
                int index = ImageHelper.NextInCycle(Commission.References, CurrentImage);
                CurrentImage = Commission.References[index];
            }
        }

        public void RemoveImageButton()
        {
            if(CurrentImage != null)
            {
                Commission.References.Remove(CurrentImage);
            }
            CurrentImage = null;
            if (Commission.References.Count > 0)
            {
                CurrentImage = Commission.References[0];
            }
            
        }


        public void AddCommissionButton()
        {
            if(Commission.Verify())
            {

                using var unitOfWork = new UnitOfWork(new DatabaseDbContext());
                unitOfWork.Commissions.Add(Commission);
                unitOfWork.Complete();

                (Parent as dynamic).ActivateItem(new ListCommissionViewModel());
            }
        }
    }
}
