using System;

namespace HuntTheWumpus.GameEntitys
{
    class Pit : GameEntity
    {
        public Pit(Coordinates coordinates) : base(coordinates,"[O]")
        {

        }

        public void GetFeelPit()
        {
            Console.WriteLine("You feel a draft");
        }
    }
}
