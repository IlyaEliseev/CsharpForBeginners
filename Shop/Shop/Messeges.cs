using System;

namespace Shop
{
    class Messeges
    {
        public static void ProductIsCreate()
        {
            SetGreenColor("Product is create!");
        }

        public static void ProductIsPlace()
        {
            SetGreenColor("Product is place on showcase!");
        }

        public static void ProductIsEdit()
        {
            SetGreenColor("Product is edit!");
        }

        public static void ProductIsDelete()
        {
            SetGreenColor("Product is delete!");
        }

        public static void ShowcaseIsCreate()
        {
            SetGreenColor("Showcase is create!");
        }

        public static void ShowcaseIsEdit()
        {
            SetGreenColor("Showcase is edit!");
        }

        public static void ShowcaseIsDelete()
        {
            SetGreenColor("Showcase is delete!");
        }

        public static void CountIsEmptyInformation()
        {
            SetRedColor("Empty!");
        }

        public static void IdNotFound()
        {
            SetRedColor("Id not found!");
        }

        public static void DeliteShowcaseMessage()
        {
            SetRedColor("Showcase is not empty!");
        }

        public static void VolumeErrorMessage()
        {
            SetRedColor("Showcase not enoph space!");
        }

        public static void ShowNotProductOnShowcase()
        {
            SetRedColor("No product on Showcase!");
        }

        public static void SetRedColor(string messege)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{messege}");
            Console.ResetColor();
        }

        public static void SetGreenColor(string messege)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{messege}");
            Console.ResetColor();
        }

    }
}
