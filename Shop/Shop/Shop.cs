using System;
using Shop.Models;

namespace Shop
{
    public class Shop 
    {
        public void CreateShop()
        {
            Shop.ShowUserMenu();
            Console.WriteLine();

            Product product = new Product();
            Showcase showCase = new Showcase();
            
            product.ErrorMessage += Messeges.ErrorCountMessage;
            product.IndexOutRange += Messeges.OutOfRangeIndex;
            showCase.ErrorMessage += Messeges.ErrorCountMessage;
            showCase.CountCheck += Messeges.OutOfRangeIndex;
            showCase.DeleteError += Messeges.DeliteShowcaseMessage;
            showCase.VolumeError += Messeges.VolumeErrorMessage;
            showCase.ChekProductOnShowacse += Messeges.ShowNotProductOnShowcase;

            bool IsContinue = true;

            while (IsContinue) 
            {
                Console.WriteLine("Input command: ");
                int command;
                string input = Console.ReadLine();
                bool succses = int.TryParse(input, out command);

                if (succses == false || command > (int)InputCommands.GetProductInformation)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong command!");
                    Console.ResetColor();
                }

                if (command == (int)InputCommands.CreateProduct)
                {
                    Console.WriteLine("Input name of product: ");
                    string _nameProduct = Console.ReadLine();
                    Console.WriteLine("Input volume of product: ");
                    double _volumeProduct = double.Parse(Console.ReadLine());
                    product.Create(_nameProduct, _volumeProduct);
                }

                if (command == (int)InputCommands.EditeProduct)
                {
                    if (product.Chek())
                    {
                        Console.WriteLine("Input product Id: ");
                        int _producyId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Input product name: ");
                        string _productName = Console.ReadLine();
                        Console.WriteLine("Input product volume: ");
                        double _productVolume = double.Parse(Console.ReadLine());
                        product.Edit(_producyId, _productName, _productVolume);
                    }
                }

                if (command == (int)InputCommands.DeleteProduct)
                {
                    if (product.Chek())
                    {
                        Console.WriteLine("Input index of product: ");
                        int _indexProduct = Int32.Parse(Console.ReadLine());
                        product.Delete(_indexProduct);
                    }
                }

                if (command == (int)InputCommands.GetProductInformation)
                {
                    if (product.Chek())
                    {
                        product.GetInformation();
                    }
                }

                if (command == (int)InputCommands.ShowAllShowcases)
                {
                    if (showCase.Check())
                    {
                        showCase.GetInformation();
                    }
                }

                if (command == (int)InputCommands.CreateShowcase)
                {
                    Console.WriteLine("Input name of showcase: ");
                    string _nameShowcase = Console.ReadLine();
                    Console.WriteLine("Input volume of showcase: ");
                    double _volumeShowcase = double.Parse(Console.ReadLine());
                    showCase.Create(_nameShowcase, _volumeShowcase);
                }

                if (command == (int)InputCommands.DeleteShowcase)
                {
                    if (showCase.Check())
                    {
                        Console.WriteLine("Input index of showcase: ");
                        int _indexShowcae = Int32.Parse(Console.ReadLine());
                        showCase.Delete(_indexShowcae);
                    }
                }

                if (command == (int)InputCommands.PlaceProductOnShowcase)
                {
                    Console.WriteLine("Input product id: ");
                    int productId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Input showcase id: ");
                    int showcaseId = int.Parse(Console.ReadLine());
                    showCase.PlaceProduct(product, productId, showcaseId);
                }

                if (command == (int)InputCommands.DeleteProductOnShowcase)
                {
                    if (showCase.Check() && showCase.CheckProduct())
                    {
                        Console.WriteLine("Input product id: ");
                        int productId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Input showcase id: ");
                        int showcaseId = int.Parse(Console.ReadLine());
                        showCase.DeleteProduct(product, productId, showcaseId);
                    }
                }

                if (command == (int)InputCommands.EditShowcase)
                {
                    if (showCase.Check())
                    {
                        Console.WriteLine("Input showcase Id: ");
                        int _showcaseId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Input showcase name: ");
                        string _showcaseName = Console.ReadLine();
                        Console.WriteLine("Input showcase volume: ");
                        double _showcaseVolume = double.Parse(Console.ReadLine());
                        showCase.Edit(_showcaseId, _showcaseName, _showcaseVolume);
                    }
                }
            }
        }

        public static void ShowUserMenu()
        {
            Console.WriteLine("Welcom to our shop !");
            Console.WriteLine();
            Console.WriteLine("Showcase command: ");
            Console.WriteLine($"Press [{(int)InputCommands.CreateShowcase}] to create showcase");
            Console.WriteLine($"Press [{(int)InputCommands.ShowAllShowcases}] to show all showcases");
            Console.WriteLine($"Press [{(int)InputCommands.PlaceProductOnShowcase}] to place product");
            Console.WriteLine($"Press [{(int)InputCommands.DeleteProductOnShowcase}] to delete product");
            Console.WriteLine($"Press [{(int)InputCommands.EditShowcase}] to edit showcase");
            Console.WriteLine($"Press [{(int)InputCommands.DeleteShowcase}] to delite showcase");
            Console.WriteLine();
            Console.WriteLine("Product command: ");
            Console.WriteLine($"Press [{(int)InputCommands.CreateProduct}] to create product");
            Console.WriteLine($"Press [{(int)InputCommands.EditeProduct}] to edite product");
            Console.WriteLine($"Press [{(int)InputCommands.DeleteProduct}] to delite product");
            Console.WriteLine($"Press [{(int)InputCommands.GetProductInformation}] to get product information");
            Console.WriteLine();
            Console.WriteLine("Utility command: ");
            Console.WriteLine($"Press [{(int)InputCommands.PlaceProductOnShowcase}] to place the product on the showcase");
            Console.WriteLine();
        }

    }   
}
