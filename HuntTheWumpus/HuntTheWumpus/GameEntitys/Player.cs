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
        internal void InteractionWithGameEntitys1(GameEntity gameEntity, Coordinates[] _coordinates)
        {
            gameEntity.Coordinates = _coordinates[0];
            if (_coordinates[0] == _coordinates[1])
            {
                gameEntity.GetVoice();
            }
        }
        internal void InteractionWithGameEntitys(GameEntity gameEntity, string[,] map)
        {            
            int _entityCoordinateX = gameEntity.Coordinates.X;
            int _entityCoordinateY = gameEntity.Coordinates.Y;

            if (Coordinates.Y + GameSettings.PLAEYER_RANGE_VISION < map.GetLength(1) &&
                map[Coordinates.X, Coordinates.Y + GameSettings.PLAEYER_RANGE_VISION] == map[_entityCoordinateX, _entityCoordinateY])
            {
                gameEntity.GetVoice();                
            }

            if (Coordinates.Y + GameSettings.PLAEYER_RANGE_VISION == map.GetLength(1))
            {
                Coordinates = new Coordinates(Coordinates.X, map.GetLength(1) - GameSettings.PLAEYER_RANGE_VISION);
            }

            if (Coordinates.Y - GameSettings.PLAEYER_RANGE_VISION >= 0 &&
                map[Coordinates.X, Coordinates.Y - GameSettings.PLAEYER_RANGE_VISION] == map[_entityCoordinateX, _entityCoordinateY])
            {
                gameEntity.GetVoice();
            }

            if (Coordinates.Y == -1)
            {
                Coordinates = new Coordinates(Coordinates.X, 0);
            }

            if (Coordinates.X - GameSettings.PLAEYER_RANGE_VISION >= 0 &&
                map[Coordinates.X - GameSettings.PLAEYER_RANGE_VISION, Coordinates.Y] == map[_entityCoordinateX, _entityCoordinateY])
            {
                gameEntity.GetVoice();
            }

            if (Coordinates.X == -1)
            {
                Coordinates = new Coordinates(0, Coordinates.Y);
            }

            if (Coordinates.X + GameSettings.PLAEYER_RANGE_VISION < map.GetLength(0) &&
                map[Coordinates.X + GameSettings.PLAEYER_RANGE_VISION, Coordinates.Y] == map[_entityCoordinateX, _entityCoordinateY])
            {
                gameEntity.GetVoice();
            }

            if (Coordinates.X == map.GetLength(0))
            {
                Coordinates = new Coordinates(map.GetLength(0) - GameSettings.PLAEYER_RANGE_VISION, Coordinates.Y);
            }
        }



    }
}
