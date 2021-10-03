using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Messeges
    {
        public static void ProductIsCreate()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Product is create!");
            Console.ResetColor();
        }

        public static void CountIsEmptyInformation()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Empty!");
            Console.ResetColor();
        }

        public static void IdNotFound()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Id not found!");
            Console.ResetColor();
        }

        public static void DeliteShowcaseMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Showcase is not empty!");
            Console.ResetColor();
        }

        public static void VolumeErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Showcase not enoph space!");
            Console.ResetColor();
        }

        public static void ShowNotProductOnShowcase()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No product on Showcase!");
            Console.ResetColor();
        }
    }
}
