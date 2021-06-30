using System;

namespace HuntTheWumpus.GameEntitys
{
    class Player : GameEntity
    {
        
        private int _playerCoordinateX = 0;
        private int _pLayerCoordinateY = 0;

        public bool IsAlive(bool isAlive)
        {            
            return isAlive;
        }

        public Player(Coordinates coordinates) : base(coordinates, "[@]")
        {            

        }    
        
        internal void MoveUp()
        {            
            if (Coordinates.Y >= 0)
            {
                _playerCoordinateX = Coordinates.X;
                _pLayerCoordinateY = Coordinates.Y - GameSettings.PLAEYER_RANGE_MOVE;
                Coordinates = new Coordinates(_playerCoordinateX, _pLayerCoordinateY);
            }

            if (Coordinates.Y == -1)
            {
                Coordinates = new Coordinates(_playerCoordinateX, 0);
            }
        }

        internal void MoveDown(string[,] map)
        {                       
            if (Coordinates.Y < map.GetLength(1))
            {                
                _playerCoordinateX = Coordinates.X;
                _pLayerCoordinateY = Coordinates.Y + GameSettings.PLAEYER_RANGE_MOVE;
                Coordinates = new Coordinates(_playerCoordinateX, _pLayerCoordinateY);
            }

            if (Coordinates.Y == map.GetLength(1))
            {
                Coordinates = new Coordinates(_playerCoordinateX, map.GetLength(1) - GameSettings.PLAEYER_RANGE_MOVE);
            }
        }

        internal void MoveLeft()
        {
            if (Coordinates.X >= 0)
            {
                _playerCoordinateX = Coordinates.X - GameSettings.PLAEYER_RANGE_MOVE;
                _pLayerCoordinateY = Coordinates.Y ;
                Coordinates = new Coordinates(_playerCoordinateX , _pLayerCoordinateY);
            }

            if (Coordinates.X == -1)
            {
                Coordinates = new Coordinates(0, Coordinates.Y);
            }
        }

        internal void MoveRight(string[,] map)
        {
            if (Coordinates.X <= map.GetLength(0))
            {
                _playerCoordinateX = Coordinates.X + GameSettings.PLAEYER_RANGE_MOVE;
                _pLayerCoordinateY = Coordinates.Y;
                Coordinates = new Coordinates(_playerCoordinateX, _pLayerCoordinateY);
            }

            if (Coordinates.X == map.GetLength(0))
            {
                Coordinates = new Coordinates(map.GetLength(0) - GameSettings.PLAEYER_RANGE_MOVE, Coordinates.Y);
            }
        }

        internal bool InteractionPlayerWithPit(Pit pit, string[,] _map)
        {
            if (_map[Coordinates.X, Coordinates.Y] == _map[pit.Coordinates.X, pit.Coordinates.Y])
            {
                Console.WriteLine("You fell into a pit. You lose");
                return false;
            }
            return true;
        }



    }
}
