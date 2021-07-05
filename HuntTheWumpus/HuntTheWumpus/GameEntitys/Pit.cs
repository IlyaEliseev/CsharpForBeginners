using System;

namespace HuntTheWumpus.GameEntitys
{
    class Pit : GameEntity, IGameEntitysAction
    {
        public Pit(Coordinates coordinates) : base(coordinates,"[O]")
        {

        }

        public override void GetVoice()
        {
            Console.WriteLine("You feel a draft");
        }
    }
}
