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
            product.ErrorMessage += ErrorCountMessage;
            product.IndexOutRange += OutOfRangeIndex;
            bool IsContinue = true;

            while (IsContinue) 
            {
                Console.WriteLine("Input command: ");
                int command = Int32.Parse(Console.ReadLine());
                
                if (command == (int)InputCommands.CreateProduct)
                {
                    Console.WriteLine("Input name of product: ");
                    string _nameProduct = Console.ReadLine();
                    Console.WriteLine("Input volume of product: ");
                    double _volumeProduct = double.Parse(Console.ReadLine());
                    product.Create(_nameProduct, _volumeProduct);
                }

                if (command == (int)InputCommands.GetProductInformation)
                {
                    if (product.Chek())
                    {
                        product.GetInformation();
                    }
                }

                if (command == (int)InputCommands.DeliteProduct)
                {
                    if (product.Chek())
                    {
                        Console.WriteLine("Input index of product: ");
                        int _indexProduct = Int32.Parse(Console.ReadLine());
                        product.RemoveProduct(_indexProduct);
                    }
                
                }
            }

        }

        public static void ErrorCountMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Empty!");
            Console.ResetColor();
        }

        public static void OutOfRangeIndex()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Product whith this index not exsist!");
            Console.ResetColor();
        }

        public static void ShowUserMenu()
        {
            Console.WriteLine("Welcom to our shop !");
            Console.WriteLine();
            Console.WriteLine("Showcase command: ");
            Console.WriteLine($"Press [{(int)InputCommands.CreateShowcase}] to create showcase");
            Console.WriteLine($"Press [{(int)InputCommands.ShowAllShowcases}] to show all showcases");
            Console.WriteLine($"Press [{(int)InputCommands.EditShowcase}] to edit showcase");
            Console.WriteLine($"Press [{(int)InputCommands.DeliteShowcase}] to delite showcase");
            Console.WriteLine();
            Console.WriteLine("Product command: ");
            Console.WriteLine($"Press [{(int)InputCommands.CreateProduct}] to create product");
            Console.WriteLine($"Press [{(int)InputCommands.EditeProduct}] to edite product");
            Console.WriteLine($"Press [{(int)InputCommands.DeliteProduct}] to delite product");
            Console.WriteLine($"Press [{(int)InputCommands.GetProductInformation}] to get product information");
            Console.WriteLine();
            Console.WriteLine("Utility command: ");
            Console.WriteLine($"Press [{(int)InputCommands.PlaceProductOnShowcase}] to place the product on the showcase");
            Console.WriteLine();

        }

    }   
}
