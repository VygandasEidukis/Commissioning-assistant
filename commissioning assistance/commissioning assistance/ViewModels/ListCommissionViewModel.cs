using Caliburn.Micro;

namespace commissioning_assistance.ViewModels
{
    public class ListCommissionViewModel : Conductor<object>
    {
        public ListCommissionViewModel()
        {

            //TODO: instead of copying, create different view with "EditView" that is conductor that contains another view that will save or update commission
            //TODO: create region class that will give you currencies and gives default localised currency

            ActivateItem(new ProductViewModel());
        }
    }
}
