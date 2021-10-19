using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Interfaces;

namespace Shop
{
    public class ShowcaseServiceHandler : IShowcaseServiceHandler
    {
        public IProductService ProductService { get; }
        public IShowcaseService ShowcaseService { get; }
        public NotifyService NotifyService { get; }
        public ShowcaseServiceHandler(IShowcaseService showcaseService, IProductService productService, NotifyService notifyService)
        {
            ShowcaseService = showcaseService;
            ProductService = productService;
            NotifyService = notifyService;
            notifyService.VolumeError += Messages.VolumeErrorMessage;
        }

        public void CreateShowcase()
        {
            Console.WriteLine("Input name of showcase: ");
            string nameShowcase = Console.ReadLine();
            Console.WriteLine("Input volume of showcase: ");
            double volumeShowcase = CheckCorrectnessVolume();
            var createShowcase = ShowcaseService.Create(nameShowcase, volumeShowcase);
            ShowcaseService.PlaceShowcase(createShowcase);
        }

        public void DeleteProductOnShowcase()
        {
            if (ShowcaseService.CheckShowcaseAvailability())
            {
                int showcaseId = CheckCorrectnessShowcaseId(ShowcaseService);
                if (ShowcaseService.CheckProductOnCurrentShowcase(showcaseId))
                {
                    int productId = CheckCorrectnessProductIdInshowcase(ShowcaseService, showcaseId);
                    ShowcaseService.DeleteProduct(ProductService, productId, showcaseId);
                }
            }
        }

        public void DeleteShowcase()
        {
            if (ShowcaseService.CheckShowcaseAvailability())
            {
                int showcaseId = CheckCorrectnessShowcaseId(ShowcaseService);
                if (ShowcaseService.CheckShowcaseCount(showcaseId) && ShowcaseService.CheckShowcaseAvailability())
                {
                    ShowcaseService.DeleteShowcase(showcaseId);
                }
            }
        }

        public void EditeProductOnShowcase()
        {
            if (ShowcaseService.CheckShowcaseAvailability())
            {
                int showcaseId = CheckCorrectnessShowcaseId(ShowcaseService);

                if (ShowcaseService.CheckProductOnCurrentShowcase(showcaseId))
                {
                    int productId = CheckCorrectnessProductIdInshowcase(ShowcaseService, showcaseId);
                    Console.WriteLine("Input new product name: ");
                    string productName = Console.ReadLine();
                    Console.WriteLine("Input new product volume: ");
                    double productVolume = CheckCorrectnessVolume();
                    if (productVolume <= ShowcaseService.GetShowcaseFreeSpace(showcaseId))
                    {
                        ShowcaseService.EditProduct(productId, showcaseId, productName, productVolume);
                    }
                    else
                    {
                        NotifyService.RaiseVolumeErrorMessage();
                    }
                }
            }
        }

        public void EditeShowcase()
        {
            if (ShowcaseService.CheckShowcaseAvailability())
            {
                int showcaseId = CheckCorrectnessShowcaseId(ShowcaseService);

                if (ShowcaseService.CheckShowcaseCount(showcaseId))
                {
                    Console.WriteLine("Input new showcase name: ");
                    string showcaseName = Console.ReadLine();
                    Console.WriteLine("Input new showcase volume: ");
                    double showcaseVolume = CheckCorrectnessVolume();
                    ShowcaseService.EditShowcase(showcaseId, showcaseName, showcaseVolume);
                }
            }
        }

        public void GetShowcaseInformation()
        {
            if (ShowcaseService.CheckShowcaseAvailability())
            {
                ShowcaseService.GetInformation();
            }
        }

        public void PlaceProductOnShowcase()
        {
            if (ProductService.CheckProductAvailability())
            {
                int productId = CheckCorrectnessProductId();
                int showcaseId = CheckCorrectnessShowcaseId(ShowcaseService);

                if (ShowcaseService.CheckShowcaseVolumeOverflow(showcaseId, productId, ProductService))
                {
                    ShowcaseService.PlaceProduct(ProductService, productId, showcaseId);
                }
            }
        }

        public static double CheckCorrectnessVolume()
        {
            double verifiableVolume;
            bool isContinue = true;

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
                    isContinue = false;
                }
            } while (isContinue);

            return verifiableVolume;
        }

        public int CheckCorrectnessProductId()
        {
            int verifiableId;
            bool isContinue = true;

            do
            {
                Console.WriteLine("Input product Id: ");
                string id = Console.ReadLine();
                bool succses = int.TryParse(id, out verifiableId);
                if (succses == false || ProductService.GetProductsCount() < verifiableId)
                {
                    Messages.SetRedColor("Wrong id!");
                }
                else
                {
                    isContinue = false;
                }
            } while (isContinue);

            return verifiableId;
        }

        public static int CheckCorrectnessShowcaseId(IShowcaseService shopHall)
        {
            int verifiableId;
            bool isContinue = true;

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
                    isContinue = false;
                }
            } while (isContinue);

            return verifiableId;
        }

        public static int CheckCorrectnessProductIdInshowcase(IShowcaseService shopHall, int showcaseId)
        {
            int verifiableProductId;
            bool isContinue = true;

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
                    isContinue = false;
                }
            } while (isContinue);

            return verifiableProductId;
        }
    }
}
