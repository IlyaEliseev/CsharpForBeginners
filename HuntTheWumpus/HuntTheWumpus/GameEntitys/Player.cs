using System;

namespace HuntTheWumpus.GameEntitys
{
    class Player : GameEntity
    {             
        public bool IsAlive(bool isAlive)
        {            
            return isAlive;
        }
        public Player(Random random) : base(new Coordinates(random.Next(0, GameSettings.MAP_SIZE_COORDINATE_X), 
                                                            random.Next(0, GameSettings.MAP_SIZE_COORDINATE_Y)), "[@]")
        {            

        }        
    }
}
