using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace commissioning_assistance.Models
{
    public static class CultureManager
    {
        public static IEnumerable<string> GetCurrencySymbols()
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

        public static string GetLocalCurrencySymbol()
        {
            return new RegionInfo(CultureInfo.CurrentCulture.LCID).ISOCurrencySymbol.ToString();
        }
    }
}
