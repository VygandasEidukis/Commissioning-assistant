using Caliburn.Micro;
using commissioning_assistance.Helpers;
using commissioning_assistance.Models;
using commissioning_assistance.Models.Commission;
using commissioning_assistance.Models.DataAccess;
using commissioning_assistance.ViewModels.Singletons;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace commissioning_assistance.ViewModels
{
    class EditCommissionViewModel : Screen
    {
        private UnitOfWork unitOfWork { get; set; }
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

        ~EditCommissionViewModel()
        {
            unitOfWork.Reset();
            unitOfWork.Dispose();
        }

        public EditCommissionViewModel(InstagramCommission commission)
        {
            Commission = commission;
            Currencies = new BindableCollection<string>();
            ProductTypes = new BindableCollection<ProductType>();
            CurrentImage = commission.References[0];
            RemoveReferences = new List<int>();
            AddReferences = new List<ImageModel>();
            unitOfWork = new UnitOfWork(new DatabaseDbContext());

            Task.Run(Loaded);
        }

        private async Task Loaded()
        {
            LoadingScreen.LoadingScreenStatus(true);

            //adding currency
            Currencies.AddRange(CultureManager.GetCurrencySymbols());
            Commission.CurrencyType = Currencies.Single(currency => currency.ToString() == CultureManager.GetLocalCurrencySymbol());

            //adding product types
            var items = unitOfWork.ProductTypes.GetEntities();

            ProductTypes.AddRange(items);
            Commission.ProductType = unitOfWork.ProductTypes.GetEntity(Commission.ProductTypeId);
            NotifyOfPropertyChange(() => Commission);


            LoadingScreen.LoadingScreenStatus(false);
        }

        public void UpdateCommissionButton()
        {
            if(Commission.Verify())
            {
                unitOfWork.Commissions.UpdateCommission(Commission);
                unitOfWork.Complete();
                ((Parent as dynamic).Parent as dynamic).ActivateItem(new ProductViewModel());
            }
        }

        public void AddImageButton()
        {
            var imgs = new List<ImageModel>();
            imgs = ImageHelper.GetImages(imgs);
            if (imgs.Count > 0)
            {
                foreach (var img in imgs)
                {
                    var com = new ImageModel { Path = img.Path, CommissionId = Commission.Id, Commission = Commission };
                    Commission.References.Add(com);
                    unitOfWork.Images.Add(com);
                }
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
                if(CurrentImage.Id == 0)
                {
                    unitOfWork.Images.DeatatchImage(CurrentImage);
                }else
                {
                    unitOfWork.Images.SetRemoveTag(CurrentImage);
                }
                Commission.References.Remove(CurrentImage);
            }
            CurrentImage = null;
            if (Commission.References.Count > 0) CurrentImage = Commission.References[0];
        }
    }
}
