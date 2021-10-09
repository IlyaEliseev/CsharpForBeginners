using System;
using Shop.Models;

namespace Shop
{
    public class ShopInterface 
    {
        public delegate void Action();
        public event Action CreateProductIsDone;
        public event Action PlaceProductIsDone;
        public event Action EditProductIsDone;
        public event Action DeleteProductIsDone;
        public event Action CreateShowcaseIsDone;
        public event Action EditShowcaseIsDone;
        public event Action DeleteShowcaseIsDone;

        public void CreateShop()
        {
            CreateProductIsDone += Messeges.ProductIsCreate;
            PlaceProductIsDone += Messeges.ProductIsPlace;
            EditProductIsDone += Messeges.ProductIsEdit;
            DeleteProductIsDone += Messeges.ProductIsDelete;
            CreateShowcaseIsDone += Messeges.ShowcaseIsCreate;
            EditShowcaseIsDone += Messeges.ShowcaseIsEdit;
            DeleteShowcaseIsDone+= Messeges.ShowcaseIsDelete;

            Product product = new Product();
            product.ProductIsNotfound += Messeges.CountIsEmptyInformation;
            product.SearchProductIdIsNotSuccessful += Messeges.IdNotFound;

            Showcase showcase = new Showcase();

            ShopHall shopHall = new ShopHall();
            shopHall.DeleteError += Messeges.DeliteShowcaseMessage;
            shopHall.ChekProductOnShowacse += Messeges.ShowNotProductOnShowcase;
            shopHall.VolumeError += Messeges.VolumeErrorMessage;
            shopHall.SearchShowcaseIdIsNotSuccessful += Messeges.IdNotFound;
            shopHall.CountCheck += Messeges.CountIsEmptyInformation;

            bool _isContinue = true;

            while (_isContinue)
            {
                ShopInterface.ShowUserMenu();
                Console.WriteLine();
                Console.WriteLine("Input command: ");

                string _input = Console.ReadLine();
                bool _succses = int.TryParse(_input, out int _command);

                if (_succses == false || _command > Enum.GetNames(typeof(InputCommands)).Length)
                {
                    Messeges.SetRedColor("Wrong command!");
                }

                if (_command == (int)InputCommands.CreateProduct)
                {
                    Console.WriteLine("Input name of product: ");
                    string _nameProduct = Console.ReadLine();
                    Console.WriteLine("Input volume of product: ");
                    double _volumeProduct = CheckCorrectnessVolume();
                    product.Create(_nameProduct, _volumeProduct);
                    RaiseCreateProductIsDone();
                }

                if (_command == (int)InputCommands.EditeProduct)
                {
                    if (product.CheckProductAvailability())
                    {
                        int _productId = CheckCorrectnessProductId(product);
                        Console.WriteLine("Input product name: ");
                        string _productName = Console.ReadLine();
                        Console.WriteLine("Input product volume: ");
                        double _productVolume = CheckCorrectnessVolume();
                        product.Edit(_productId, _productName, _productVolume);
                        RaiseEditProductIsDone();
                    }
                }

                if (_command == (int)InputCommands.DeleteProduct)
                {
                    if (product.CheckProductAvailability())
                    {
                        Console.WriteLine("Input product id: ");
                        int _productId = Int32.Parse(Console.ReadLine());
                        product.Delete(_productId);
                        RaiseDeleteProductIsDone();
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
                    if (shopHall.CheckShowcaseAvailability())
                    {
                        shopHall.GetInformation();
                    }
                }

                if (_command == (int)InputCommands.CreateShowcase)
                {
                    Console.WriteLine("Input name of showcase: ");
                    string _nameShowcase = Console.ReadLine();
                    Console.WriteLine("Input volume of showcase: ");
                    double _volumeShowcase = CheckCorrectnessVolume();
                    var _creatShowcase = showcase.Create(_nameShowcase, _volumeShowcase);
                    shopHall.PlaceShowcase(_creatShowcase);
                    RaiseCreateShowcaseIsDone();
                }

                if (_command == (int)InputCommands.DeleteShowcase)
                {
                    if (shopHall.CheckShowcaseAvailability())
                    {
                        int _showcaseId = CheckCorrectnessShowcaseId(shopHall);
                        if (shopHall.CheckShowcaseCount(_showcaseId) && shopHall.CheckShowcaseAvailability())
                        {
                            shopHall.DeleteShowcase(_showcaseId);
                            RaiseDeleteShowcaseIsDone();
                        }
                    }
                }

                if (_command == (int)InputCommands.PlaceProductOnShowcase)
                {
                    if (product.CheckProductAvailability())
                    {
                        int _productId = CheckCorrectnessProductId(product);
                        int _showcaseId = CheckCorrectnessShowcaseId(shopHall);

                        if (shopHall.CheckShowcaseVolumeOverflow(_showcaseId, _productId, product))
                        {
                            shopHall.PlaceProduct(product, _productId, _showcaseId);
                            RaisePlaceProductIsDone();
                        }
                    }
                }

                if (_command == (int)InputCommands.DeleteProductOnShowcase)
                {
                    if (shopHall.CheckShowcaseAvailability())
                    {
                        int showcaseId = CheckCorrectnessShowcaseId(shopHall);
                        if (shopHall.CheckProductOnCurrentShowcase(showcaseId))
                        {
                            int _productId = CheckCorrectnessProductIdInshowcase(shopHall, showcaseId);
                            shopHall.DeleteProduct(product, _productId, showcaseId);
                            RaiseDeleteProductIsDone();
                        }
                    }
                }

                if (_command == (int)InputCommands.EditShowcase)
                {
                    if (shopHall.CheckShowcaseAvailability())
                    {
                        int _showcaseId = CheckCorrectnessShowcaseId(shopHall);

                        if (shopHall.CheckShowcaseCount(_showcaseId))
                        {
                            Console.WriteLine("Input new showcase name: ");
                            string _showcaseName = Console.ReadLine();
                            Console.WriteLine("Input new showcase volume: ");
                            double _showcaseVolume = CheckCorrectnessVolume();
                            shopHall.EditShowcase(_showcaseId, _showcaseName, _showcaseVolume);
                            RaiseEditShowcaseIsDone();
                        }
                    }
                }

                if (_command == (int)InputCommands.EditProductOnShowcase)
                {
                    if (shopHall.CheckShowcaseAvailability())
                    {
                        int _showcaseId = CheckCorrectnessShowcaseId(shopHall);
                        
                        if (shopHall.CheckProductOnCurrentShowcase(_showcaseId))
                        {
                            int _productId = CheckCorrectnessProductIdInshowcase(shopHall, _showcaseId);
                            Console.WriteLine("Input new product name: ");
                            string _productName = Console.ReadLine();
                            Console.WriteLine("Input new product volume: ");
                            double _productVolume = CheckCorrectnessVolume();
                            shopHall.EditProduct(_productId, _showcaseId, _productName, _productVolume);
                            RaiseEditProductIsDone();
                        }
                    }
                }
            }
        }

        public static int CheckCorrectnessProductIdInshowcase(ShopHall shopHall, int showcaseId)
        {
            int _verifiableProductId;
            bool _IsContinue = true;
            
            do
            {
                Console.WriteLine("Input product Id: ");
                string id = Console.ReadLine();
                bool _succses = int.TryParse(id, out _verifiableProductId);
                if (_succses == false || shopHall.GetShowcase(showcaseId).GetProductCount() < _verifiableProductId)
                {
                    Messeges.SetRedColor("Wrong id!");
                }
                else
                {
                    _IsContinue = false;
                }
            } while (_IsContinue);
            
            return _verifiableProductId;

        }

        public static int CheckCorrectnessProductId(Product product)
        {
            int _verifiableId;
            bool _IsContinue = true;

            do
            {
                Console.WriteLine("Input product Id: ");
                string _id = Console.ReadLine();
                bool _succses = int.TryParse(_id, out _verifiableId);
                if (_succses == false || product.GetProductsCount() < _verifiableId)
                {
                    Messeges.SetRedColor("Wrong id!");
                }
                else
                {
                    _IsContinue = false;
                }
            } while (_IsContinue);

            return _verifiableId;
        }

        public static int CheckCorrectnessShowcaseId(ShopHall shopHall)
        {
            int _verifiableId;
            bool _IsContinue = true;
            
            do
            {
                Console.WriteLine("Input showcase Id: ");
                string _id = Console.ReadLine();
                bool _succses = int.TryParse(_id, out _verifiableId);
                if (_succses == false || shopHall.GetShowcaseListCount() < _verifiableId)
                {
                    Messeges.SetRedColor("Wrong id!");
                }
                else
                {
                    _IsContinue = false;
                }
            } while (_IsContinue);

            return _verifiableId;
        }
        public static double CheckCorrectnessVolume()
        {
            double verifiableVolume;
            bool IsContinue = true;

            do
            {
                string volume = Console.ReadLine();
                bool succses = double.TryParse(volume, out verifiableVolume);
                if (succses == false)
                {
                    Messeges.SetRedColor("Wronge value!");
                }
                else
                {
                    IsContinue = false;
                }
            } while (IsContinue);

            return verifiableVolume;
        }
        public void RaiseCreateProductIsDone()
        {
            CreateProductIsDone?.Invoke();
        }

        public void RaisePlaceProductIsDone()
        {
            PlaceProductIsDone?.Invoke();
        }

        public void RaiseEditProductIsDone()
        {
            EditProductIsDone?.Invoke();
        }

        public void RaiseDeleteProductIsDone()
        {
            DeleteProductIsDone?.Invoke();
        }

        public void RaiseCreateShowcaseIsDone()
        {
            CreateShowcaseIsDone?.Invoke();
        }

        public void RaiseEditShowcaseIsDone()
        {
            EditShowcaseIsDone?.Invoke();
        }

        public void RaiseDeleteShowcaseIsDone()
        {
            DeleteShowcaseIsDone?.Invoke();
        }

        public static void ShowUserMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Showcase command: ");
            Console.WriteLine($"Press [{(int)InputCommands.CreateShowcase}] to CREATE showcase");
            Console.WriteLine($"Press [{(int)InputCommands.ShowAllShowcases}] to SHOW all showcases");
            Console.WriteLine($"Press [{(int)InputCommands.PlaceProductOnShowcase}] to PLACE product");
            Console.WriteLine($"Press [{(int)InputCommands.EditProductOnShowcase}] to EDIT product on showcase");
            Console.WriteLine($"Press [{(int)InputCommands.DeleteProductOnShowcase}] to DELETE product on showcase");
            Console.WriteLine($"Press [{(int)InputCommands.EditShowcase}] to EDIT showcase");
            Console.WriteLine($"Press [{(int)InputCommands.DeleteShowcase}] to DELETE showcase");
            Console.WriteLine();
            Console.WriteLine("Product command: ");
            Console.WriteLine($"Press [{(int)InputCommands.CreateProduct}] to CREATE product");
            Console.WriteLine($"Press [{(int)InputCommands.EditeProduct}] to edite product");
            Console.WriteLine($"Press [{(int)InputCommands.DeleteProduct}] to EDIT product");
            Console.WriteLine($"Press [{(int)InputCommands.GetProductInformation}] to GET product information");
            Console.WriteLine();
        }
    }   
}
