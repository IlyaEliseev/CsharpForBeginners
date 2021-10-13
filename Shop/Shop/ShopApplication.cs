using System;
using Shop.Models;

namespace Shop
{
    internal class ShopApplication 
    {
        public delegate void Action();
        public event Action CreateProductIsDone;
        public event Action PlaceProductIsDone;
        public event Action EditProductIsDone;
        public event Action DeleteProductIsDone;
        public event Action CreateShowcaseIsDone;
        public event Action EditShowcaseIsDone;
        public event Action DeleteShowcaseIsDone;

        public void Run()
        {
            CreateProductIsDone += Messages.ProductIsCreate;
            PlaceProductIsDone += Messages.ProductIsPlace;
            EditProductIsDone += Messages.ProductIsEdit;
            DeleteProductIsDone += Messages.ProductIsDelete;
            CreateShowcaseIsDone += Messages.ShowcaseIsCreate;
            EditShowcaseIsDone += Messages.ShowcaseIsEdit;
            DeleteShowcaseIsDone+= Messages.ShowcaseIsDelete;

            Product product = new Product();
            product.ProductIsNotfound += Messages.CountIsEmptyInformation;
            product.SearchProductIdIsNotSuccessful += Messages.IdNotFound;

            Showcase showcase = new Showcase();

            ShopHall shopHall = new ShopHall();
            shopHall.DeleteError += Messages.DeliteShowcaseMessage;
            shopHall.ChekProductOnShowacse += Messages.ShowNotProductOnShowcase;
            shopHall.VolumeError += Messages.VolumeErrorMessage;
            shopHall.SearchShowcaseIdIsNotSuccessful += Messages.IdNotFound;
            shopHall.CountCheck += Messages.CountIsEmptyInformation;

            bool IsContinue = true;

            while (IsContinue)
            {
                ShopApplication.ShowUserMenu();
                Console.WriteLine();
                Console.WriteLine("Input command: ");

                string input = Console.ReadLine();
                bool succses = int.TryParse(input, out int command);

                if (succses == false || command > Enum.GetNames(typeof(InputCommands)).Length)
                {
                    Messages.SetRedColor("Wrong command!");
                }

                if (command == (int)InputCommands.CreateProduct)
                {
                    Console.WriteLine("Input name of product: ");
                    string nameProduct = Console.ReadLine();
                    Console.WriteLine("Input volume of product: ");
                    double volumeProduct = CheckCorrectnessVolume();
                    product.Create(nameProduct, volumeProduct);
                    RaiseCreateProductIsDone();
                }

                if (command == (int)InputCommands.EditeProduct)
                {
                    if (product.CheckProductAvailability())
                    {
                        int productId = CheckCorrectnessProductId(product);
                        Console.WriteLine("Input product name: ");
                        string productName = Console.ReadLine();
                        Console.WriteLine("Input product volume: ");
                        double productVolume = CheckCorrectnessVolume();
                        product.Edit(productId, productName, productVolume);
                        RaiseEditProductIsDone();
                    }
                }

                if (command == (int)InputCommands.DeleteProduct)
                {
                    if (product.CheckProductAvailability())
                    {
                        Console.WriteLine("Input product id: ");
                        int productId = Int32.Parse(Console.ReadLine());
                        product.Delete(productId);
                        RaiseDeleteProductIsDone();
                    }
                }

                if (command == (int)InputCommands.GetProductInformation)
                {
                    if (product.CheckProductAvailability())
                    {
                        product.GetInformation();
                    }
                }

                if (command == (int)InputCommands.ShowAllShowcases)
                {
                    if (shopHall.CheckShowcaseAvailability())
                    {
                        shopHall.GetInformation();
                    }
                }

                if (command == (int)InputCommands.CreateShowcase)
                {
                    Console.WriteLine("Input name of showcase: ");
                    string nameShowcase = Console.ReadLine();
                    Console.WriteLine("Input volume of showcase: ");
                    double volumeShowcase = CheckCorrectnessVolume();
                    var creatShowcase = showcase.Create(nameShowcase, volumeShowcase);
                    shopHall.PlaceShowcase(creatShowcase);
                    RaiseCreateShowcaseIsDone();
                }

                if (command == (int)InputCommands.DeleteShowcase)
                {
                    if (shopHall.CheckShowcaseAvailability())
                    {
                        int showcaseId = CheckCorrectnessShowcaseId(shopHall);
                        if (shopHall.CheckShowcaseCount(showcaseId) && shopHall.CheckShowcaseAvailability())
                        {
                            shopHall.DeleteShowcase(showcaseId);
                            RaiseDeleteShowcaseIsDone();
                        }
                    }
                }

                if (command == (int)InputCommands.PlaceProductOnShowcase)
                {
                    if (product.CheckProductAvailability())
                    {
                        int productId = CheckCorrectnessProductId(product);
                        int showcaseId = CheckCorrectnessShowcaseId(shopHall);

                        if (shopHall.CheckShowcaseVolumeOverflow(showcaseId, productId, product))
                        {
                            shopHall.PlaceProduct(product, productId, showcaseId);
                            RaisePlaceProductIsDone();
                        }
                    }
                }

                if (command == (int)InputCommands.DeleteProductOnShowcase)
                {
                    if (shopHall.CheckShowcaseAvailability())
                    {
                        int showcaseId = CheckCorrectnessShowcaseId(shopHall);
                        if (shopHall.CheckProductOnCurrentShowcase(showcaseId))
                        {
                            int productId = CheckCorrectnessProductIdInshowcase(shopHall, showcaseId);
                            shopHall.DeleteProduct(product, productId, showcaseId);
                            RaiseDeleteProductIsDone();
                        }
                    }
                }

                if (command == (int)InputCommands.EditShowcase)
                {
                    if (shopHall.CheckShowcaseAvailability())
                    {
                        int showcaseId = CheckCorrectnessShowcaseId(shopHall);

                        if (shopHall.CheckShowcaseCount(showcaseId))
                        {
                            Console.WriteLine("Input new showcase name: ");
                            string showcaseName = Console.ReadLine();
                            Console.WriteLine("Input new showcase volume: ");
                            double showcaseVolume = CheckCorrectnessVolume();
                            shopHall.EditShowcase(showcaseId, showcaseName, showcaseVolume);
                            RaiseEditShowcaseIsDone();
                        }
                    }
                }

                if (command == (int)InputCommands.EditProductOnShowcase)
                {
                    if (shopHall.CheckShowcaseAvailability())
                    {
                        int showcaseId = CheckCorrectnessShowcaseId(shopHall);
                        
                        if (shopHall.CheckProductOnCurrentShowcase(showcaseId))
                        {
                            int productId = CheckCorrectnessProductIdInshowcase(shopHall, showcaseId);
                            Console.WriteLine("Input new product name: ");
                            string productName = Console.ReadLine();
                            Console.WriteLine("Input new product volume: ");
                            double productVolume = CheckCorrectnessVolume();
                            shopHall.EditProduct(productId, showcaseId, productName, productVolume);
                            RaiseEditProductIsDone();
                        }
                    }
                }

                if (command == (int)InputCommands.EXITApplication)
                {
                    IsContinue = false;
                }
            }
        }

        public static int CheckCorrectnessProductIdInshowcase(ShopHall shopHall, int showcaseId)
        {
            int verifiableProductId;
            bool IsContinue = true;
            
            do
            {
                Console.WriteLine("Input product Id: ");
                string id = Console.ReadLine();
                bool succses = int.TryParse(id, out verifiableProductId);
                if (succses == false || shopHall.GetShowcase(showcaseId).GetProductCount() < verifiableProductId)
                {
                    Messages.SetRedColor("Wrong id!");
                }
                else
                {
                    IsContinue = false;
                }
            } while (IsContinue);
            
            return verifiableProductId;

        }

        public static int CheckCorrectnessProductId(Product product)
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
                    Messages.SetRedColor("Wrong id!");
                }
                else
                {
                    IsContinue = false;
                }
            } while (IsContinue);

            return verifiableId;
        }

        public static int CheckCorrectnessShowcaseId(ShopHall shopHall)
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
                    Messages.SetRedColor("Wrong id!");
                }
                else
                {
                    IsContinue = false;
                }
            } while (IsContinue);

            return verifiableId;
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
                    Messages.SetRedColor("Wronge value!");
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
            Console.WriteLine($"Press [{(int)InputCommands.EditeProduct}] to EDIT product");
            Console.WriteLine($"Press [{(int)InputCommands.DeleteProduct}] to DELETE product");
            Console.WriteLine($"Press [{(int)InputCommands.GetProductInformation}] to GET product information");
            Console.WriteLine($"Press [{(int)InputCommands.EXITApplication}] to EXIT the application");
            Console.WriteLine();
        }
    }   
}
