using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Computer : User
    {
        public override int GetToCard(int[] _deck, int сardNumber)
        {            
            Card = _deck[сardNumber + 1]; //computer take the card always second
            return Card;                
        }
        public override bool Pass()
        {
            return false;
        }

        public Computer(string name) : base(name)
        {

        }
    }
}
