using Caliburn.Micro;

namespace commissioning_assistance.ViewModels
{
    public class ListCommissionViewModel : Conductor<object>
    {
        public ListCommissionViewModel()
        {
            ActivateItem(new ProductViewModel());
        }
    }
}
