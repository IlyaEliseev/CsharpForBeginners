using System;
using Shop.Controllers;
using Shop.Services;

namespace Shop
{
    public class ShopApplication 
    {
        public IProductController ProductController { get; }
        public IShowcaseController ShowcaseController { get; }
        public IProductArchiveController ProductArchiveController { get; }
        public NotifyService NotifyService { get; }
        public CheckService CheckService { get; }

        public ShopApplication(IProductController productController, NotifyService notifyService, CheckService checkService, 
                               IShowcaseController showcaseController, IProductArchiveController productArchiveController)
        {
            ProductController = productController;
            ProductArchiveController = productArchiveController;
            NotifyService = notifyService;
            CheckService = checkService;
            ShowcaseController = showcaseController;

            notifyService.CreateShowcaseIsDone += Messages.ShowcaseIsCreate;
            notifyService.CreateProductIsDone += Messages.ProductIsCreate;
            notifyService.EditProductIsDone += Messages.ProductIsEdit;
            notifyService.DeleteProductIsDone += Messages.ProductIsDelete;
            notifyService.EditShowcaseIsDone += Messages.ShowcaseIsEdit;
            notifyService.DeleteShowcaseIsDone += Messages.ShowcaseIsDelete;
            notifyService.VolumeError += Messages.VolumeErrorMessage;
            notifyService.ProductIsNotfound += Messages.CountIsEmptyInformation;
            notifyService.SearchProductIdIsNotSuccessful += Messages.IdNotFound;
            notifyService.CountCheck += Messages.CountIsEmptyInformation;
            notifyService.DeleteError += Messages.DeliteShowcaseMessage;
            notifyService.ChekProductOnShowacse += Messages.ShowNotProductOnShowcase;
            notifyService.PlaceProductIsDone += Messages.ProductIsPlace;
            notifyService.ArchivateProductIsDone += Messages.ProductArchivate;
            notifyService.UnArchivateProductIsDone += Messages.ProductUnArchivate;
            notifyService.DeleteArchiveProductIsDone += Messages.ArchiveProductDelete;
            notifyService.ArchiveIsEmpty += Messages.ArchiveEmpty;
        }
        
        public void Run()
        {
            bool isContinue = true;
            while (isContinue)
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

                else
                {
                    if (command == (int)InputCommands.CreateProduct)
                    {
                        string nameProduct = CheckService.CheckName(GetName());
                        double volumeProduct = CheckService.CheckVolume(GetVolume());
                        ProductController.CreateProduct(nameProduct, volumeProduct);
                    }

                    if (command == (int)InputCommands.EditeProduct)
                    {
                        int productId = CheckService.CheckId(GetProductId());
                        string productName = CheckService.CheckName(GetName());
                        double productVolume = CheckService.CheckVolume(GetVolume());
                        ProductController.EditProduct(productId, productName, productVolume);
                    }

                    if (command == (int)InputCommands.DeleteProduct)
                    {
                        int productId = CheckService.CheckId(GetProductId());
                        ProductController.DeleteProduct(productId);
                    }

                    if (command == (int)InputCommands.GetProductInformation)
                    {
                        ProductController.GetProductInformation();
                    }

                    if (command == (int)InputCommands.ShowAllShowcases)
                    {
                        ShowcaseController.GetShowcaseInformation();
                    }

                    if (command == (int)InputCommands.CreateShowcase)
                    {
                        string nameShowcase = CheckService.CheckName(GetName());
                        double volumeShowcase = CheckService.CheckVolume(GetVolume());
                        ShowcaseController.CreateShowcase(nameShowcase, volumeShowcase);
                    }

                    if (command == (int)InputCommands.DeleteShowcase)
                    {
                        int showcaseId = CheckService.CheckId(GetShowcaseId());
                        ShowcaseController.DeleteShowcase(showcaseId);
                    }

                    if (command == (int)InputCommands.PlaceProductOnShowcase)
                    {
                        int showcaseId = CheckService.CheckId(GetShowcaseId());
                        int productId = CheckService.CheckId(GetProductId());
                        ShowcaseController.PlaceProductOnShowcase(productId, showcaseId);
                    }

                    if (command == (int)InputCommands.DeleteProductOnShowcase)
                    {
                        int showcaseId = CheckService.CheckId(GetShowcaseId());
                        int productId = CheckService.CheckId(GetProductId());
                        ShowcaseController.DeleteProductOnShowcase(showcaseId, productId);
                    }

                    if (command == (int)InputCommands.EditShowcase)
                    {
                        int showcaseId = CheckService.CheckId(GetShowcaseId());
                        string showcaseName = CheckService.CheckName(GetName());
                        double showcaseVolume = CheckService.CheckVolume(GetVolume());
                        ShowcaseController.EditeShowcase(showcaseId, showcaseName, showcaseVolume);
                    }

                    if (command == (int)InputCommands.EditProductOnShowcase)
                    {
                        int showcaseId = CheckService.CheckId(GetShowcaseId());
                        int productId = CheckService.CheckId(GetProductId());
                        string productName = CheckService.CheckName(GetName());
                        double productVolume = CheckService.CheckVolume(GetVolume());
                        ShowcaseController.EditeProductOnShowcase(productId, showcaseId, productName, productVolume);
                    }

                    if (command == (int)InputCommands.ArchivateProduct)
                    {
                        var showcaseId = CheckService.CheckId(GetShowcaseId());
                        int productId = CheckService.CheckId(GetProductId());
                        ProductArchiveController.ArchivateProduct(productId, showcaseId);
                    }

                    if (command == (int)InputCommands.UnArchivateProduct)
                    {
                        var productId = CheckService.CheckId(GetProductId());
                        ProductArchiveController.UnArchivateProduct(productId);
                    }

                    if (command == (int)InputCommands.DeleteArchiveProduct)
                    {
                        int productId = CheckService.CheckId(GetProductId());
                        ProductArchiveController.DeleteArchiveProduct(productId);
                    }

                    if (command == (int)InputCommands.GetArchiveInformation)
                    {
                        ProductArchiveController.GetArchiveInformation();
                    }

                    if (command == (int)InputCommands.EXITApplication)
                    {
                        isContinue = false;
                    }
                }
            }
        }

        public static string GetName()
        {
            Console.WriteLine("Input name:");
            string name = Console.ReadLine();
            return name;
        }

        public static string GetVolume()
        {
            Console.WriteLine("Input volume:");
            string volume = Console.ReadLine();
            return volume;
        }

        public static string GetProductId()
        {
            Console.WriteLine("Input product Id: ");
            string Id = Console.ReadLine();
            return Id;
        }

        public static string GetShowcaseId()
        {
            Console.WriteLine("Input showcase Id: ");
            string Id = Console.ReadLine();
            return Id;
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
            Console.WriteLine();
            Console.WriteLine("Archive command: ");
            Console.WriteLine($"Press [{(int)InputCommands.ArchivateProduct}] to ARCHIVATE product");
            Console.WriteLine($"Press [{(int)InputCommands.UnArchivateProduct}] to UNARCHIVATE product");
            Console.WriteLine($"Press [{(int)InputCommands.DeleteArchiveProduct}] to DELETE archive product");
            Console.WriteLine($"Press [{(int)InputCommands.GetArchiveInformation}] to GET archive information");
            Console.WriteLine();
            Console.WriteLine($"Press [{(int)InputCommands.EXITApplication}] to EXIT the application");
            Console.WriteLine();
        }
    }   
}
