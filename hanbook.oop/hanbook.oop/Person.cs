using System;

namespace hanbook.oop
{
    class Person
    {
        public string Name { get; set; }
        public string TelephoneNumber { get; set; }
        public byte Age { get; set; }

        public Person(string name, string telephoneNumber, byte age)
        {
            Name = name;
            TelephoneNumber = telephoneNumber;
            Age = age;
        }

        public void DisplayPersonInformation()
        {
            Console.WriteLine($"Name: {Name} Telephone Number: {TelephoneNumber} Age: {Age}");
        }

    }
}
