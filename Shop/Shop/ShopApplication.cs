﻿using System;
using Shop.Models;
using Shop.Interfaces;

namespace Shop
{
    public class ShopApplication 
    {
        //public delegate void Action();
        //public event Action CreateProductIsDone;
        //public event Action PlaceProductIsDone;
        //public event Action EditProductIsDone;
        //public event Action DeleteProductIsDone;
        //public event Action CreateShowcaseIsDone;
        //public event Action EditShowcaseIsDone;
        //public event Action DeleteShowcaseIsDone;
        //public event Action VolumeError;

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
        }
        
        public void Run()
        {
            //CreateProductIsDone += Messages.ProductIsCreate;
            //PlaceProductIsDone += Messages.ProductIsPlace;
            //EditProductIsDone += Messages.ProductIsEdit;
            //DeleteProductIsDone += Messages.ProductIsDelete;
            
            //EditShowcaseIsDone += Messages.ShowcaseIsEdit;
            //DeleteShowcaseIsDone += Messages.ShowcaseIsDelete;
            //VolumeError += Messages.VolumeErrorMessage;


            //ProductService.ProductIsNotfound += Messages.CountIsEmptyInformation;
            //product.SearchProductIdIsNotSuccessful += Messages.IdNotFound;

            //Showcase showcase = new Showcase();

            //ShopHall shopHall = new ShopHall();
            //shopHall.DeleteError += Messages.DeliteShowcaseMessage;
            //shopHall.ChekProductOnShowacse += Messages.ShowNotProductOnShowcase;
            //shopHall.VolumeError += Messages.VolumeErrorMessage;
            //shopHall.SearchShowcaseIdIsNotSuccessful += Messages.IdNotFound;
            //shopHall.CountCheck += Messages.CountIsEmptyInformation;

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
                    NotifyService.RaiseCreateProductIsDone();
                }

                if (command == (int)InputCommands.EditeProduct)
                {
                    ProductServiceHandler.EditProduct();
                    NotifyService.RaiseEditProductIsDone();
                }

                if (command == (int)InputCommands.DeleteProduct)
                {
                    ProductServiceHandler.DeleteProduct();
                    NotifyService.RaiseDeleteProductIsDone();
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
                    NotifyService.RaiseCreateShowcaseIsDone();
                }

                if (command == (int)InputCommands.DeleteShowcase)
                {
                    ShowcaseServiceHandler.DeleteShowcase();
                    NotifyService.RaiseDeleteShowcaseIsDone();
                }

                if (command == (int)InputCommands.PlaceProductOnShowcase)
                {
                    ShowcaseServiceHandler.PlaceProductOnShowcase();
                    
                }

                if (command == (int)InputCommands.DeleteProductOnShowcase)
                {
                    ShowcaseServiceHandler.DeleteProductOnShowcase();
                    NotifyService.RaiseDeleteProductIsDone();
                }

                if (command == (int)InputCommands.EditShowcase)
                {
                    ShowcaseServiceHandler.EditeShowcase();
                    NotifyService.RaiseEditShowcaseIsDone();
                }

                if (command == (int)InputCommands.EditProductOnShowcase)
                {
                    ShowcaseServiceHandler.EditeProductOnShowcase();
                    NotifyService.RaiseEditProductIsDone();
                }

                if (command == (int)InputCommands.EXITApplication)
                {
                    isContinue = false;
                }
            }
        }

        //public void RaiseCreateProductIsDone()
        //{
        //    CreateProductIsDone?.Invoke();
        //}

        //public void RaisePlaceProductIsDone()
        //{
        //    PlaceProductIsDone?.Invoke();
        //}

        //public void RaiseEditProductIsDone()
        //{
        //    EditProductIsDone?.Invoke();
        //}

        //public void RaiseDeleteProductIsDone()
        //{
        //    DeleteProductIsDone?.Invoke();
        //}

        //public void RaiseCreateShowcaseIsDone()
        //{
        //    CreateShowcaseIsDone?.Invoke();
        //}

        //public void RaiseEditShowcaseIsDone()
        //{
        //    EditShowcaseIsDone?.Invoke();
        //}

        //public void RaiseDeleteShowcaseIsDone()
        //{
        //    DeleteShowcaseIsDone?.Invoke();
        //}

        //public void RaiseVolumeErrorMessage()
        //{
        //    VolumeError?.Invoke();
        //}

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
