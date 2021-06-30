using System;

namespace HuntTheWumpus.GameEntitys
{
    class Wumpus : GameEntity
    {                
        public bool IsAlive(bool isAliveWumpus)
        {
            return isAliveWumpus;
        }

        public Wumpus(Coordinates coordinates) : base(coordinates, "[W]")
        {

        }

        public void GetFeelWumpus()
        {
            Console.WriteLine("You have a stench and a thirst for blood");
        }       
    }
}
