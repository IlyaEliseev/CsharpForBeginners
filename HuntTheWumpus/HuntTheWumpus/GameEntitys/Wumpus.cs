using System;

namespace HuntTheWumpus.GameEntitys
{
    class Wumpus : GameEntity, IGameEntitysAction
    {                
        public bool IsAlive(bool isAliveWumpus)
        {
            return isAliveWumpus;
        }

        public Wumpus(Coordinates coordinates) : base(coordinates, "[W]")
        {

        }

        public override void GetVoice()
        {
            Console.WriteLine("You have a stench and a thirst for blood");
        }       
    }
}
