using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public abstract class User
    {                
        public int Card { get; set; }
        public int UserScore { get; set; }
        public string UserName { get; set; }

        public User(string name)
        {
            UserName = name;
        }

        public abstract int GetToCard(int[] _deck, int сardNumber);

        public int GetToScore()
        {
            UserScore += Card;
            return UserScore;
        }

        public abstract bool Pass();
    }
}

