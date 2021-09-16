using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Messeges
    {
        public static void ErrorCountMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Empty!");
            Console.ResetColor();
        }

        public static void OutOfRangeIndex()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Index not found!");
            Console.ResetColor();
        }

        public static void DeliteShowcaseMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Showcase is not empty!");
            Console.ResetColor();
        }
    }
}
