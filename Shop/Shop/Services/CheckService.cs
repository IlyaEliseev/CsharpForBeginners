using System;
using Shop.Interfaces;

namespace Shop.Services
{
    public class CheckService
    {
        protected internal int CheckProductId(IProductService productService)
        {
            int verifiableId;
            bool isContinue = true;

            do
            {
                Console.WriteLine("Input product Id: ");
                string id = Console.ReadLine();
                bool succses = int.TryParse(id, out verifiableId);
                if (succses == false || productService.GetProductsCount() < verifiableId)
                {
                    Messages.SetRedColor("Id not found!");
                }
                else
                {
                    isContinue = false;
                }
            } while (isContinue);

            return verifiableId;
        }

        protected internal int CheckProductIdOnShowcase(IShowcaseService showcaseService, int showcaseId)
        {
            int verifiableId;
            bool isContinue = true;

            do
            {
                Console.WriteLine("Input product Id: ");
                string id = Console.ReadLine();
                bool succses = int.TryParse(id, out verifiableId);
                if (succses == false || showcaseService.GerProductShowcaseCount(showcaseId) < verifiableId)
                {
                    Messages.SetRedColor("Id not found!");
                }
                else
                {
                    isContinue = false;
                }
            } while (isContinue);

            return verifiableId;
        }

        protected internal int CheckShowcaseId(IShowcaseService showcaseService)
        {
            int verifiableId;
            bool isContinue = true;

            do
            {
                Console.WriteLine("Input showcase Id: ");
                string id = Console.ReadLine();
                bool succses = int.TryParse(id, out verifiableId);
                if (succses == false || showcaseService.GetShowcaseListCount() < verifiableId)
                {
                    Messages.SetRedColor("Id not found!");
                }
                else
                {
                    isContinue = false;
                }
            } while (isContinue);

            return verifiableId;
        }

        protected internal int CheckProductIdInArchive(IProductArchiveService productArchiveService)
        {
            int verifiableId;
            bool isContinue = true;

            do
            {
                Console.WriteLine("Input product Id: ");
                string id = Console.ReadLine();
                bool succses = int.TryParse(id, out verifiableId);
                if (succses == false || productArchiveService.GetArchiveProductCount() < verifiableId)
                {
                    Messages.SetRedColor("Id not found!");
                }
                else
                {
                    isContinue = false;
                }
            } while (isContinue);

            return verifiableId;
        }

        protected internal double CheckVolume()
        {
            double verifiableVolume;
            bool isContinue = true;
            
            do
            {
                Console.WriteLine("Input volume: ");
                string volume = Console.ReadLine();
                bool succses = double.TryParse(volume, out verifiableVolume);
                if (succses == false)
                {
                    Messages.SetRedColor("Volume is uncorrect!");
                }
                else
                {
                    isContinue = false;
                }
            } while (isContinue);

            return verifiableVolume;
        }

        protected internal string CheckName()
        {
            bool isContinue = true;
            string verifiableName;

            do
            {
                Console.WriteLine("Input name:");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Messages.SetRedColor("Name is uncorrect!");
                }
                else
                {
                    isContinue = false;
                }
                verifiableName = name;

            } while (isContinue);
            
            return verifiableName;
        }
    }
}
