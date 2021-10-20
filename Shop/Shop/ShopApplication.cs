using System;
using Shop.Models;
using Shop.Interfaces;

namespace Shop
{
    public class ShopApplication 
    {
        public IProductServiceHandler ProductServiceHandler { get; }
        public IShowcaseServiceHandler ShowcaseServiceHandler { get; }
        public NotifyService NotifyService { get; }

        public ShopApplication(IProductServiceHandler productServiceHandler, IShowcaseServiceHandler showcaseServiceHandler, NotifyService notifyService)
        {
            ProductServiceHandler = productServiceHandler;
            ShowcaseServiceHandler = showcaseServiceHandler;
            NotifyService = notifyService;

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
            notifyService.SearchShowcaseIdIsNotSuccessful += Messages.IdNotFound;
            notifyService.PlaceProductIsDone += Messages.ProductIsPlace;
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

                if (command == (int)InputCommands.CreateProduct)
                {
                    ProductServiceHandler.CreateProduct();
                }

                if (command == (int)InputCommands.EditeProduct)
                {
                    ProductServiceHandler.EditProduct();
                }

                if (command == (int)InputCommands.DeleteProduct)
                {
                    ProductServiceHandler.DeleteProduct();
                }

                if (command == (int)InputCommands.GetProductInformation)
                {
                    ProductServiceHandler.GetProductInformation();
                }

                if (command == (int)InputCommands.ShowAllShowcases)
                {
                    ShowcaseServiceHandler.GetShowcaseInformation();
                }

                if (command == (int)InputCommands.CreateShowcase)
                {
                    ShowcaseServiceHandler.CreateShowcase();
                }

                if (command == (int)InputCommands.DeleteShowcase)
                {
                    ShowcaseServiceHandler.DeleteShowcase();
                }

                if (command == (int)InputCommands.PlaceProductOnShowcase)
                {
                    ShowcaseServiceHandler.PlaceProductOnShowcase();
                }

                if (command == (int)InputCommands.DeleteProductOnShowcase)
                {
                    ShowcaseServiceHandler.DeleteProductOnShowcase();
                }

                if (command == (int)InputCommands.EditShowcase)
                {
                    ShowcaseServiceHandler.EditeShowcase();
                }

                if (command == (int)InputCommands.EditProductOnShowcase)
                {
                    ShowcaseServiceHandler.EditeProductOnShowcase();
                }

                if (command == (int)InputCommands.EXITApplication)
                {
                    isContinue = false;
                }
            }
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
