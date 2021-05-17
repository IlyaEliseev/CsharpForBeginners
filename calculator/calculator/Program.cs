using System;


namespace calculator
{
    class Program
    {
        
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

        static decimal Sum(decimal firstNumber, decimal secondNumber) => firstNumber + secondNumber;
        static decimal Sub(decimal firstNumber, decimal secondNumber) => firstNumber - secondNumber;
        static decimal Mult(decimal firstNumber, decimal secondNumber) => firstNumber * secondNumber;
        static decimal Div(decimal firstNumber, decimal secondNumber) => firstNumber / secondNumber;

    }
}
