using System;
using Shop.Models;

namespace Shop
{
    public class ShopInterface 
    {
        public void CreateShop()
        {
            

            Product product = new Product();
            product.ProductIsNotfound += Messeges.CountIsEmptyInformation;
            product.SearchProductIdIsNotSuccessful += Messeges.IdNotFound;
            product.CreateProductIsDone += Messeges.ProductIsCreate;
            Showcase showcase = new Showcase();
            showcase.ErrorMessage += Messeges.CountIsEmptyInformation;
            showcase.SearchShowcaseIdIsNotSuccessful += Messeges.IdNotFound;
            showcase.DeleteError += Messeges.DeliteShowcaseMessage;
            showcase.VolumeError += Messeges.VolumeErrorMessage;
            

            ShopHall shopHall = new ShopHall();
            shopHall.ErrorMessage += Messeges.CountIsEmptyInformation;
            shopHall.DeleteError += Messeges.DeliteShowcaseMessage;
            shopHall.ChekProductOnShowacse += Messeges.ShowNotProductOnShowcase;

            bool _isContinue = true;
            
            string _input;
            while (_isContinue) 
            {
                ShopInterface.ShowUserMenu();
                Console.WriteLine();
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
                        int _productId = CheckCorrectnessId(showcase);
                        Console.WriteLine("Input product name: ");
                        string _productName = Console.ReadLine();
                        Console.WriteLine("Input product volume: ");
                        double _productVolume = double.Parse(Console.ReadLine());
                        product.Edit(_productId, _productName, _productVolume);
                    }
                }

                if (_command == (int)InputCommands.DeleteProduct)
                {
                    if (product.CheckProductAvailability())
                    {
                        Console.WriteLine("Input product id: ");
                        int _productId = Int32.Parse(Console.ReadLine());
                        product.Delete(_productId);
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
                    var creatShowcase = showcase.Create(_nameShowcase, _volumeShowcase);
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
                    int productId = CheckCorrectnessId(product);
                    int showcaseId = CheckCorrectnessId(shopHall);
                    showcase.PlaceProduct(product, shopHall, productId, showcaseId);
                }

                if (_command == (int)InputCommands.DeleteProductOnShowcase)
                {
                    
                    int showcaseId = CheckCorrectnessId(shopHall);
                    if (shopHall.CheckProductOnCurrentShowcase(showcaseId))
                    {
                        int productId = CheckCorrectnessId(showcase);
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

        public static int CheckCorrectnessId(Showcase showcase)
        {
            int verifiableId;
            bool IsContinue = true;
            
            do
            {
                Console.WriteLine("Input product Id: ");
                string id = Console.ReadLine();
                bool succses = int.TryParse(id, out verifiableId);
                if (succses == false || showcase.GetProductCount() < verifiableId)
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
        public static int CheckCorrectnessId(ShopHall shopHall)
        {
            int verifiableId;
            bool IsContinue = true;

            do
            {
                Console.WriteLine("Input showcase Id: ");
                string id = Console.ReadLine();
                bool succses = int.TryParse(id, out verifiableId);
                if (succses == false || shopHall.GetShowcaseListCount() < verifiableId)
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
            Console.WriteLine($"Press [{(int)InputCommands.DeleteProductOnShowcase}] to delete product on showcase");
            Console.WriteLine($"Press [{(int)InputCommands.EditShowcase}] to edit showcase");
            Console.WriteLine($"Press [{(int)InputCommands.DeleteShowcase}] to delite showcase");
            Console.WriteLine();
            Console.WriteLine("Product command: ");
            Console.WriteLine($"Press [{(int)InputCommands.CreateProduct}] to create product");
            Console.WriteLine($"Press [{(int)InputCommands.EditeProduct}] to edite product");
            Console.WriteLine($"Press [{(int)InputCommands.DeleteProduct}] to delite product");
            Console.WriteLine($"Press [{(int)InputCommands.GetProductInformation}] to get product information");
            Console.WriteLine();
        }

    }   
}
