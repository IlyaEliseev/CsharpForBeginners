using System;
using Shop.Models;

namespace Shop
{
    public class ShopInterface 
    {
        public void CreateShop()
        {
            ShopInterface.ShowUserMenu();
            Console.WriteLine();

            Product product = new Product();
            product.ErrorMessage += Messeges.ErrorCountMessage;
            product.IndexOutRange += Messeges.OutOfRangeIndex;

            Showcase showCase = new Showcase();
            showCase.ErrorMessage += Messeges.ErrorCountMessage;
            showCase.CountCheck += Messeges.OutOfRangeIndex;
            showCase.DeleteError += Messeges.DeliteShowcaseMessage;
            showCase.VolumeError += Messeges.VolumeErrorMessage;
            

            ShopHall shopHall = new ShopHall();
            shopHall.ErrorMessage += Messeges.ErrorCountMessage;
            shopHall.DeleteError += Messeges.DeliteShowcaseMessage;
            shopHall.ChekProductOnShowacse += Messeges.ShowNotProductOnShowcase;

            bool _isContinue = true;
            
            string _input;
            while (_isContinue) 
            {
                Console.WriteLine("Input command: ");
                
                _input = Console.ReadLine();
                bool succses = int.TryParse(_input, out int _command);

                if (succses == false || _command > (int)InputCommands.GetProductInformation)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong command!");
                    Console.ResetColor();
                }

                if (_command == (int)InputCommands.CreateProduct)
                {
                    Console.WriteLine("Input name of product: ");
                    string _nameProduct = Console.ReadLine();
                    Console.WriteLine("Input volume of product: ");
                    _input = Console.ReadLine();
                   
                    bool succses1 = double.TryParse(_input, out double _volumeProduct);
                    if (succses1 == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong command!");
                        Console.ResetColor();

                    }
                    product.Create(_nameProduct, _volumeProduct);
                }

                if (_command == (int)InputCommands.EditeProduct)
                {
                    if (product.CheckProductAvailability())
                    {
                        //Console.WriteLine("Input product Id: ");
                        int _producyId = CheckCorrectnessId(product);
                        Console.WriteLine("Input product name: ");
                        string _productName = Console.ReadLine();
                        Console.WriteLine("Input product volume: ");
                        double _productVolume = double.Parse(Console.ReadLine());
                        product.Edit(_producyId, _productName, _productVolume);
                    }
                }

                if (_command == (int)InputCommands.DeleteProduct)
                {
                    if (product.CheckProductAvailability())
                    {
                        Console.WriteLine("Input index of product: ");
                        int _indexProduct = Int32.Parse(Console.ReadLine());
                        product.Delete(_indexProduct);
                    }
                }

                if (_command == (int)InputCommands.GetProductInformation)
                {
                    if (product.CheckProductAvailability())
                    {
                        product.GetInformation();
                    }
                }

                if (_command == (int)InputCommands.ShowAllShowcases)
                {
                    
                    shopHall.GetInformation();
                    
                }

                if (_command == (int)InputCommands.CreateShowcase)
                {
                    Console.WriteLine("Input name of showcase: ");
                    string _nameShowcase = Console.ReadLine();
                    Console.WriteLine("Input volume of showcase: ");
                    double _volumeShowcase = double.Parse(Console.ReadLine());
                    var creatShowcase = showCase.Create(_nameShowcase, _volumeShowcase);
                    shopHall.PlaceShowcase(creatShowcase);
                }

                //if (_command == (int)InputCommands.DeleteShowcase)
                //{
                //    if (shopHall.CheckShowcaseCount())
                //    {
                //        Console.WriteLine("Input index of showcase: ");
                //        int _indexShowcae = Int32.Parse(Console.ReadLine());
                //        shopHall.DeleteShowcase(_indexShowcae);
                //    }
                //}

                if (_command == (int)InputCommands.PlaceProductOnShowcase)
                {
                    Console.WriteLine("Input product id: ");
                    int productId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Input showcase id: ");
                    int showcaseId = int.Parse(Console.ReadLine());
                    showCase.PlaceProduct(product, shopHall, productId, showcaseId);
                }

                if (_command == (int)InputCommands.DeleteProductOnShowcase)
                {
                    Console.WriteLine("Input showcase id: ");
                    int showcaseId = int.Parse(Console.ReadLine());
                    if (shopHall.CheckShowcaseCount(showcaseId) || shopHall.CheckProductOnShowcase(showcaseId))
                    {
                        Console.WriteLine("Input product id: ");
                        int productId = int.Parse(Console.ReadLine());
                        shopHall.DeleteProduct(product, productId, showcaseId);
                    }
                }

                if (_command == (int)InputCommands.EditShowcase)
                {
                    Console.WriteLine("Input showcase Id: ");
                    int _showcaseId = int.Parse(Console.ReadLine());

                    if (shopHall.CheckShowcaseCount(_showcaseId))
                    {
                        Console.WriteLine("Input showcase name: ");
                        string _showcaseName = Console.ReadLine();
                        Console.WriteLine("Input showcase volume: ");
                        double _showcaseVolume = double.Parse(Console.ReadLine());
                        shopHall.Edit(_showcaseId, _showcaseName, _showcaseVolume);
                    }
                }
            }
        }

        public static int CheckCorrectnessId(Product product)
        {
            int verifiableId;
            bool IsContinue = true;
            
            do
            {
                Console.WriteLine("Input product Id: ");
                string id = Console.ReadLine();
                bool succses = int.TryParse(id, out verifiableId);
                if (succses == false || product.GetProductsCount() < verifiableId)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong id!");
                    Console.ResetColor();
                }
                else
                {
                    IsContinue = false;
                }
            } while (IsContinue);
            
            return verifiableId;

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
