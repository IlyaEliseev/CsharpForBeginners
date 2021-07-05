using HuntTheWumpus.GameEntitys;
using System;
using System.Linq;

namespace HuntTheWumpus
{
    class Map
    {
        Random random = new Random();
        private byte _mapSizeX;
        private byte _mapSizeY;
        Coordinates [] _coordinates = new Coordinates[100];
        private int _gameEntitysCount;
        private string[,] _map;
        public Map(byte mapSizeX, byte mapSizeY)
        {                      
            _map = new string[mapSizeX, mapSizeY];
            _mapSizeX = mapSizeX;
            _mapSizeY = mapSizeY;
            for (int y = 0; y < mapSizeY; y++)
            {
                for (int x = 0; x < mapSizeX; x++)
                {
                    _map[x, y] = "[ ]";
                }
            }
        }

        public string[,] ViewMap()
        {
            for(int y = 0; y < _mapSizeY; y++)
            {
                for (int x = 0; x < _mapSizeX; x++)
                {
                    _map[x, y] = "[ ]";
                }
            }

            return _map;
        }

        internal void AddGameEntity(GameEntity gameEntity)
        {
            _map[gameEntity.Coordinates.X, gameEntity.Coordinates.Y] = gameEntity.GameEntityModel;            
        }

        internal void DeliteEntity(GameEntity gameEntity)
        {
            _map[gameEntity.Coordinates.X, gameEntity.Coordinates.Y] = "[ ]";
        }        

        internal string GetEntityCoordinate(GameEntity gameEntity)
        {
            return _map[gameEntity.Coordinates.X, gameEntity.Coordinates.Y];
        }                                    

        internal bool InteractionPlayerWithPit(Player player, Pit pit)
        {
            if (GetEntityCoordinate(player) == GetEntityCoordinate(pit))
            {
                Console.WriteLine("You fell into a pit. You lose");
                return false;
            }
            return true;
        }
        
        internal void CheckMapUniqCoordinateGameEntity(Player player, Bat firstBat, Bat secondBat, Pit firstPit, Pit secondPit)
        {
            if (GetEntityCoordinate(firstBat) == GetEntityCoordinate(secondBat))
            {
                firstBat.Coordinates = new Coordinates(random.Next(0, GameSettings.MAP_SIZE_COORDINATE_X), 
                                                       random.Next(0, GameSettings.MAP_SIZE_COORDINATE_Y));
            }

            if (GetEntityCoordinate(firstPit) == GetEntityCoordinate(secondPit))
            {
                firstPit.Coordinates = new Coordinates(random.Next(0, GameSettings.MAP_SIZE_COORDINATE_X),
                                                       random.Next(0, GameSettings.MAP_SIZE_COORDINATE_Y));
            }

            if (GetEntityCoordinate(firstBat) == GetEntityCoordinate(firstPit) || GetEntityCoordinate(secondBat) == GetEntityCoordinate(secondPit))
            {
                firstBat.Coordinates = new Coordinates(random.Next(0, GameSettings.MAP_SIZE_COORDINATE_X),
                                                       random.Next(0, GameSettings.MAP_SIZE_COORDINATE_Y));
            }
        }        

        internal string[,] GetMap()
        {
            return _map;
        }
    }  
}

