using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avensia.Storefront.Developertest
{
   static class CurrencyRate
    {
       
        public static decimal USD=1m;
        public static decimal GBP = 0.71m;
        public static decimal SEK = 8.38m;
        public static decimal DKK = 6.06m;

        public static string SelectedCurrency = string.Empty;
    }

    static class Currencyname
    {
      public enum name { USD, GBP,SEK,DKK};

    }


    static class CurrencyInfo
    {
        public static string CurrentSymbol { get; set; }

        public static decimal SelectedCurrencyPrice { get; set; }


    }
}
