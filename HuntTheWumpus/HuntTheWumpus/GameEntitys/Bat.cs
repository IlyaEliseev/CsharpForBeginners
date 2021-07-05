using System;

namespace HuntTheWumpus.GameEntitys
{
    public class Bat : GameEntity, IGameEntitysAction
    {
        public Bat(Coordinates coordinates):base(coordinates, "[ ]")
        {

        }

        public override void GetVoice()
        {
            Console.WriteLine("You hear a bat squeak");
        }
    }
}
