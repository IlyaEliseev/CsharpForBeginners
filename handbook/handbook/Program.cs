using System;

namespace handbook
{
    class Program
    {
        static void Main()
        {
            byte lengthMassives = 3;
            string[] names = new string[lengthMassives];
            string[] telephoneNambers = new string[lengthMassives];
            byte[] listsAges = new byte[lengthMassives];

            for(int i = 0; i < lengthMassives; i++)
            {
                Console.WriteLine("input name");
                string name = Console.ReadLine();
                names[i] = name;

                Console.WriteLine("input telephone namber");
                string telephoneNumber = Console.ReadLine();
                telephoneNambers[i] = telephoneNumber;

                Console.WriteLine("input age");
                byte age = byte.Parse(Console.ReadLine());
                
            }

            for (int i = 0; i < lengthMassives; i++)
            {
                Console.WriteLine($"name: {names[i]} telephone number: {telephoneNambers[i]} age: {listsAges[i]}");
            }

        }                                        
    }
}
