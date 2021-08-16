using System;
using Shop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Shop
    {
        public void CreateShop()
        {
            Shop.ShowUserMenu();

            var ShowCaseList = new List<ShowCase>(); 
            var showcase = new ShowCase();

            var product1 = new Product("GTX2080", 12.3);
            var product2 = new Product("GTX3080", 12.6);

            showcase.PlaceProduct(product1);
            showcase.PlaceProduct(product2);

            //showcase.GetInformation();
            ShowCaseList.Add(showcase);

            foreach (var item in ShowCaseList)
            {
                item.GetInformation();
            }

            bool IsContinue = true;

            do
            {

            } while (IsContinue);

        }

        public static void ShowUserMenu()
        {
            Console.WriteLine("Welcom to our shop !");
            Console.WriteLine();
            Console.WriteLine("Showcase command: ");
            Console.WriteLine("Press 1 to create showcase");
            Console.WriteLine("Press 2 to show all showcases");
            Console.WriteLine("Press 3 to edit showcase");
            Console.WriteLine("Press 4 to delite showcase");
            Console.WriteLine();
            Console.WriteLine("Product command: ");
            Console.WriteLine("Press 5 to create product");
            Console.WriteLine("Press 6 to edite product");
            Console.WriteLine("Press 7 to delite product");
            Console.WriteLine();
            Console.WriteLine("Utility command: ");
            Console.WriteLine("Press 8 to place the product on the showcase");
            Console.WriteLine();

        }

    }   
}
