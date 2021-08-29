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
            Console.WriteLine();

            Product product = new Product();
            product.ErrorMessage += DisplayMessage;

            bool IsContinue = true;

            do
            {
                Console.WriteLine("Input command: ");
                string command = Console.ReadLine();

                if (command == "1")
                {
                    Console.WriteLine("Input name of product: ");
                    string _nameProduct = Console.ReadLine();
                    Console.WriteLine("Input volume of product: ");
                    double _volumeProduct = double.Parse(Console.ReadLine());
                    product.Create(_nameProduct, _volumeProduct);
                }

                if (command == "2")
                {
                    if (product.Chek())
                    {
                        product.GetInformation();
                    }
                }

                if (command == "7")
                {
                    if (product.Chek())
                    {
                        Console.WriteLine("Input index of product: ");
                        int _indexProduct = Int32.Parse(Console.ReadLine());
                        product.RemoveProduct(_indexProduct);
                    }
                }
            } while (IsContinue);

        }

        public static void DisplayMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You no create a product!");
            Console.ResetColor();
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
