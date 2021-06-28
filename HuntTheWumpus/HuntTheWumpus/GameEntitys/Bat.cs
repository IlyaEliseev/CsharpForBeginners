using System;

namespace HuntTheWumpus.GameEntitys
{
    public class Bat : GameEntity 
    {
        public Bat(Coordinates coordinates):base(coordinates, "[B]")
        {

        }

        public void GetVoiceBat()
        {
            Console.WriteLine("You hear a bat squeak");
        }
    }
}
