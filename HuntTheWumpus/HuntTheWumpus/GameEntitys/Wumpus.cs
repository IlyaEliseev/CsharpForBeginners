using System;

namespace HuntTheWumpus.GameEntitys
{
    class Wumpus : GameEntity
    {                
        public bool IsAlive(bool isAliveWumpus)
        {
            return isAliveWumpus;
        }

        public Wumpus(Random random) : base(new Coordinates(random.Next(0, GameSettings.MAP_SIZE_COORDINATE_X), 
                                                            random.Next(0, GameSettings.MAP_SIZE_COORDINATE_Y)), "[W]")
        {

        }

        public void GetFeelWumpus()
        {
            Console.WriteLine("You have a stench and a thirst for blood");
        }       
    }
}
