using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Player : User
    {
        public Player(string name) : base(name)
        {

        }

        public override bool Pass()
        {
            return false;
        }

        public override int GetToCard(int[] _deck, int сardNumber)
        {

            Card = _deck[сardNumber];
            return Card;
        }
    }
}