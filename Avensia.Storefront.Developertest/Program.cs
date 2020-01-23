using System;
using StructureMap;
using System.IO;

namespace Avensia.Storefront.Developertest
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(new DefaultRegistry());
            var productListVisualizer = container.GetInstance<ProductListVisualizer>();

            // Load json file and Store to cache
            Console.WriteLine("Loaded Json file and Added to cache.\n");
            var strJson= Globalmemorycache.Pushtocache(GetStrJson(), "Products");

            //Currency Selection
            DisplayCurrenctyOptions();
            CheckSelectedCurrency();
        

            //Product Selection
            DisplayProductOption();
            ProductOption(productListVisualizer, strJson, true);
    

            Console.Write("\n\rPress any key to exit!");
            Console.ReadKey();
        }



        #region "Currency Option Implementation"
        /// <summary>
        /// Getting the currency selection
        /// </summary>
        /// <param name="productListVisualizer"></param>
        /// <param name="shouldRun"></param>
        private static void CheckSelectedCurrency()
        {

            
        ReSelectCurrency:
            Console.Write("Select Currency: ");
                var input = Console.ReadKey();
      
                switch (input.Key)
                {
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("\nYou Choose option 1 - USD");

                    CurrencyRate.SelectedCurrency = "USD";
                        break;
                    case ConsoleKey.NumPad2:
                        // case ConsoleKey.D2:
                        Console.WriteLine("\nYou Choose option 2 - GBP");
                    CurrencyRate.SelectedCurrency = "GBP";
                    // productListVisualizer.OutputPaginatedProducts();
                    break;
                    case ConsoleKey.NumPad3:
                        //case ConsoleKey.D3:
                        Console.WriteLine("\nYou Choose option 3 - SEK");
                    CurrencyRate.SelectedCurrency = "SEK";
                    //  productListVisualizer.OutputProductGroupedByPriceSegment();
                    break;
                    case ConsoleKey.NumPad4:
                        //case ConsoleKey.D3:
                        Console.WriteLine("\nYou Choose option 4 - DKK");
                    CurrencyRate.SelectedCurrency = "DKK";
                    break;
                    case ConsoleKey.Q:
                    
                        break;
                    default:
                        Console.WriteLine("\nInvalid option!");
                    goto ReSelectCurrency;
                    break;
                }

                Console.WriteLine();

          
        }

        /// <summary>
        /// Display the Currency Option
        /// </summary>
        private static void DisplayCurrenctyOptions()
        {
            Console.WriteLine("\nChoose Currency Type:");
            Console.WriteLine("1 - USD");
            Console.WriteLine("2 - GBP");
            Console.WriteLine("3 - SEK");
            Console.WriteLine("4 - DKK");
            Console.WriteLine("q - Quit");
        }
        #endregion




        #region "Product Option Implementation"
        /// <summary>
        /// Getting the Product selection
        /// </summary>
        /// <param name="productListVisualizer"></param>
        /// <param name="shouldRun"></param>
        private static void ProductOption(ProductListVisualizer productListVisualizer, string strJson, bool shouldRun)
        {
            while (shouldRun)
            {
                Console.Write("Enter an option: ");
                var input = Console.ReadKey();
                Console.WriteLine("\n");
                switch (input.Key)
                {
                    case ConsoleKey.NumPad1:
                        //case ConsoleKey.D1:
                        Console.WriteLine("You Choose option 1 - Print all products");
                        productListVisualizer.OutputAllProduct(strJson);

                        //ask again for Currency choices.
                        CheckCurrencyResponse(productListVisualizer);
                        break;
                    case ConsoleKey.NumPad2:
                        // case ConsoleKey.D2:
                        Console.WriteLine("Printing paginated products");
                        productListVisualizer.OutputPaginatedProducts(strJson,4);

                        //ask again for Currency choices.
                        CheckCurrencyResponse(productListVisualizer);
                        break;
                    case ConsoleKey.NumPad3:
                        //case ConsoleKey.D3:
                        Console.WriteLine("Printing products grouped by price");
                        productListVisualizer.OutputProductGroupedByPriceSegment(strJson);

                        //ask again for Currency choices.
                        CheckCurrencyResponse(productListVisualizer);
                        break;
                    case ConsoleKey.Q:
                        shouldRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }

                Console.WriteLine();
                DisplayProductOption();
            }


        }

        /// <summary>
        /// Display Product option
        /// </summary>
        private static void DisplayProductOption()
        {
            Console.WriteLine("\nChoose How Product to Display:");
            Console.WriteLine("1 - Print all products");
            Console.WriteLine("2 - Print paginated products");
            Console.WriteLine("3 - Print products grouped by price");
            Console.WriteLine("q - Quit");
        }

        #endregion



        private static void CheckCurrencyResponse(ProductListVisualizer productListVisualizer)
        {

            ReDo:
            Console.Write("\nSelect Other Currency? [Y]/[N] ");
            var input = Console.ReadKey();
          
            switch (input.Key)
            {
                case ConsoleKey.Y:

                    //Currency Selection
                    DisplayCurrenctyOptions();
                    CheckSelectedCurrency();
                    //end Managing Currency Selection
                    break;
                case ConsoleKey.N:
                    // case ConsoleKey.D2:

                    break;
                
                default:
                    Console.WriteLine("\nInvalid option!");
                    goto ReDo;
                    
            }

        }


        private static string GetStrJson()
        {
               return File.ReadAllText(@"products.json").ToString();
        }
    }
}
