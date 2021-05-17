using System;
using System.Text;

namespace calculator
{
    class Program
    {
        private static Encoding en;

        static void Main(string[] args)
        {
            
            Console.WriteLine("To add two numbers press +\n" +
                              "To subtract one number from another press + \n" +
                              "To multiply numbers press *\nTo division numbers press /\n" +
                              "To close calculator press stop");
            Console.WriteLine();

            bool stop = false;

            do
            {
                Console.WriteLine("Press to first number");
                decimal firstNumber = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Press to second number");
                decimal secondNumber = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Press input to operation: + - * / stop");
                string operation = Console.ReadLine();

                switch (operation)
                {
                    case "+":
                        Console.WriteLine($"Result: {Sum(firstNumber, secondNumber)}");
                        break;
                    case "-":
                        Console.WriteLine($"Result: {Sub(firstNumber, secondNumber)}");
                        break;
                    case "*":
                        Console.WriteLine($"Result: {Mult(firstNumber, secondNumber)}");
                        break;
                    case "/":
                        Console.WriteLine($"Result: {Div(firstNumber, secondNumber)}");
                        break;
                    case "stop":
                        stop = true;
                        break;
                }

            } while (stop==false);                                                               
        }

        static decimal Sum(decimal firstNumbera, decimal secondNumber) => firstNumbera + secondNumber;
        static decimal Sub(decimal firstNumbera, decimal secondNumber) => firstNumbera - secondNumber;
        static decimal Mult(decimal firstNumbera, decimal secondNumber) => firstNumbera * secondNumber;
        static decimal Div(decimal firstNumbera, decimal secondNumber) => firstNumbera / secondNumber;

    }
}
