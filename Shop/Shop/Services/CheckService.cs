using System;
using Shop.Interfaces;

namespace Shop.Services
{
    public class CheckService
    {

        protected internal int CheckProductId(string id)
        {
            int verifiableId;
            bool isContinue = true;

            do
            {
                bool succses = int.TryParse(id, out verifiableId);
                if (succses == false)
                {
                    Messages.SetRedColor("Id not found!");
                    Console.WriteLine("Input Id: ");
                    id = Console.ReadLine();
                }
                else
                {
                    isContinue = false;
                }
            }while (isContinue);
            
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

        public double CheckVolume(string volume)
        {
            double verifiableVolume;
            bool isContinue = true;

            do
            {
                bool succses = double.TryParse(volume, out verifiableVolume);
                
                if (succses == false)
                {
                    Messages.SetRedColor("Volume is uncorrect!");
                    Console.WriteLine("Input volume: ");
                    volume = Console.ReadLine();
                }
                else
                {
                    isContinue = false;
                }
            } while (isContinue);
            return verifiableVolume;
        }

        public string CheckName(string name)
        {
            bool isContinue = true;

            do
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    Messages.SetRedColor("Name is uncorrect!");
                    Console.WriteLine("Input name:");
                    name = Console.ReadLine();
                }
                else
                {
                    isContinue = false;
                }
            } while (isContinue);
            return name;
        }
    }
}
