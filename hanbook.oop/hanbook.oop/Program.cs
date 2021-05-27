using System;

namespace hanbook.oop
{
    class Program
    {
        static void Main(string[] args)
        {
            byte lengthHandbook = 3;
            
            Person[] persons = new Person[lengthHandbook];

            for (int i = 0; i < lengthHandbook; i++)
            {
                

                Console.WriteLine("input name");
                string _name = Console.ReadLine();
                
                Console.WriteLine("input telephone namber");
                string _telephoneNumber = Console.ReadLine();
                
                Console.WriteLine("input age");
                byte _age = byte.Parse(Console.ReadLine());

                persons[i] = new Person(_name, _telephoneNumber, _age);
                
            }
            
            for (int i = 0; i < lengthHandbook; i++)
            {
                persons[i].DisplayPersonInformation();
            }
        }
    }
}
