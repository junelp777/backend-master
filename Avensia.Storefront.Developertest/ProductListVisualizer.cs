using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace Avensia.Storefront.Developertest
{
    public class ProductListVisualizer
    {

        #region "OutputAllProduct..."
        public void OutputAllProduct(string strJson)
        {
            //Check memory cache if exist or not
            strJson = Globalmemorycache.Pushtocache(strJson, "Products");

            //Manage Json file : From Interface to Class, cant Parse ProductDto as List.. Need to, to access Properties value in json.
            var products = JsonConvert.DeserializeObject<List<ProductDto>>(strJson);

            int cntr = 1;
            foreach (var prod in products)
            { 
                Console.WriteLine($"\n\n{cntr})ProductID: {prod.Id}\t\tProduct Name:{prod.ProductName}\tCategory ID:{prod.CategoryId}\t  Price:{Formatcurrencyprice(prod.Price)}\nProperties:");
                foreach (var prop in prod.Properties)
                {
                    Console.WriteLine($"\tKeyName: {prop.KeyName}\t\tValue: {prop.Value}");
                }
                cntr++;
            }
            // end Managing json file

        }
        public string Formatcurrencyprice(decimal price)
        {

            string value = string.Empty;

            if (CurrencyRate.SelectedCurrency == Currencyname.name.SEK.ToString())
            {
                value = (price * CurrencyRate.SEK).ToString() + " kr";
            }
            else if (CurrencyRate.SelectedCurrency == Currencyname.name.GBP.ToString())
            {
                value = "£" + (price * CurrencyRate.GBP).ToString();
            }
            else if (CurrencyRate.SelectedCurrency == Currencyname.name.DKK.ToString())
            {
                value = (price * CurrencyRate.DKK).ToString() + " Kr.";
            }
            else
            {
                value = "$" + price;
            }

            return value;
        }
        #endregion

        #region "OutputPaginatedProducts..."
        public void OutputPaginatedProducts(string strJson,int numberofpages)
        {
            //Check memory cache if exist or not
            strJson = Globalmemorycache.Pushtocache(strJson, "Products");
            //Manage Json file : 
            var products = JsonConvert.DeserializeObject<List<ProductDto>>(strJson);

            decimal maxpage = products.Count/numberofpages;
            int selectedpage = 1;
            int endingpage = 0;
           
        Executepage:
            int cntr = 0;
            endingpage = selectedpage * (int)maxpage;
            Console.WriteLine("\nPage 1 : " +selectedpage);
            foreach (var prod in products)
            {
              

                if (cntr>=(endingpage -5) && cntr < endingpage)
                {
                    Console.WriteLine($"\nProductID: {prod.Id}\nProduct Name: {prod.ProductName}\nCategory ID: {prod.CategoryId}\nPrice: {Formatcurrencyprice(prod.Price)}\nProperties:");
                    foreach (var prop in prod.Properties)
                    {
                        Console.WriteLine($"\tKeyName: {prop.KeyName}\t\tValue: {prop.Value}");
                    }

                    if (cntr == endingpage - 1)
                    {
                        break;
                    }
                }
                cntr++;
            }
            Console.WriteLine("\n\t\tEND OF PAGE: " + selectedpage);
            // end Managing json file


            //console key
            Console.Write("\n\n  BACK [<<]   [>>] NEXT \n");
            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (selectedpage > 1)
                    {
                        selectedpage--;
                        Console.Write($"\n\n\n\n\t\t\tYou are in Page #: {selectedpage}\n");
                        goto Executepage;
                    }
                   
                    break;
                case ConsoleKey.RightArrow:

                    if (selectedpage < maxpage)
                    {
                        selectedpage++;
                        Console.Write($"\n\n\n\n\t\t\tYou are in Page #: {selectedpage}\n");
                        goto Executepage;
                    }
                  

                    break;

                case ConsoleKey.Q:

                    break;
                default:
                    Console.WriteLine("\nInvalid option!");
                 break;
            }

            Console.WriteLine();

        }

      

        #endregion
        
        #region  "OutputProductGroupedByPriceSegment..."
        public void OutputProductGroupedByPriceSegment(string strJson)
        {
            // by 100 

            //Check memory cache if exist or not
            strJson = Globalmemorycache.Pushtocache(strJson, "Products");
            //Manage Json file : From Interface to Class, cant Parse ProductDto as List.. Need to, to access Properties value in json.
            var products = JsonConvert.DeserializeObject<List<ProductDto>>(strJson);

            SorfbyPrice sortbyprice = new SorfbyPrice();
            products.Sort(sortbyprice);

            int CurrentHeaderFrmValue = -1;
            foreach (var prod in products)
            {
                int HeaderFromValue, HeaderToValue = 0;
                SetCurrencyValue(prod.Price);  // check / Get the selected price on  current currency selected
                HeaderFromValue = GetWholenumber(CurrencyInfo.SelectedCurrencyPrice) * 100; //frm
                HeaderToValue = HeaderFromValue + 100; // to

                if (CurrentHeaderFrmValue != HeaderFromValue)
                {
                    //display
                    Console.WriteLine($"\n\n{HeaderFromValue} - {GetformatHeader(HeaderToValue)}");

                    //child
                    var currentcurrencyvalue = Formatcurrencyprice(prod.Price); //with value sign
                    Console.WriteLine($"\t{prod.ProductName}\t{currentcurrencyvalue}");
                    CurrentHeaderFrmValue = HeaderFromValue;
                   }
                else
                {  //child
                    var currentcurrencyvalue = Formatcurrencyprice(prod.Price); //with value sign
                    Console.WriteLine($"\t{prod.ProductName}\t{currentcurrencyvalue}");
                }
                
            }
          
        }


        private void SetCurrencyValue(decimal price)
        {
            if (CurrencyRate.SelectedCurrency == Currencyname.name.SEK.ToString())
            {
                CurrencyInfo.SelectedCurrencyPrice = (price * CurrencyRate.SEK);
            }
            else if (CurrencyRate.SelectedCurrency == Currencyname.name.GBP.ToString())
            {
                CurrencyInfo.SelectedCurrencyPrice = (price * CurrencyRate.GBP);
            }
            else if (CurrencyRate.SelectedCurrency == Currencyname.name.DKK.ToString())
            {
                CurrencyInfo.SelectedCurrencyPrice = (price * CurrencyRate.DKK);
            }
            else
            {
                CurrencyInfo.SelectedCurrencyPrice = price;
            }
          }


        private int GetWholenumber(decimal Price)
        {
            string value = (Price / 100).ToString();
            string[] splitvalue = value.Split('.');
            return Convert.ToInt32(splitvalue.GetValue(0));
        }
        private string GetformatHeader(int HeaderToValue)
        {

            string value = string.Empty;
            if (CurrencyRate.SelectedCurrency == Currencyname.name.SEK.ToString())
            {
                value = HeaderToValue + " kr";
            }
            else if (CurrencyRate.SelectedCurrency == Currencyname.name.GBP.ToString())
            {
                value = "£" + HeaderToValue;
            }
            else if (CurrencyRate.SelectedCurrency == Currencyname.name.DKK.ToString())
            {
                value = HeaderToValue + " Kr.";
            }
            else
            {
                value = "$" + HeaderToValue;
            }
            return value;
        }
        #endregion



    }
}