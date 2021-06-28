using HuntTheWumpus.GameEntitys;
using System;
using System.Linq;

namespace HuntTheWumpus
{
    class Map
    {
        Random random = new Random();
        public int PlayerRangeVision { get; set; }
        private string[,] _map;
        public Map(byte mapSizeX, byte mapSizeY, int playerRangeVision)
        {
            PlayerRangeVision = playerRangeVision;
            _map = new string[mapSizeX, mapSizeY];

            for (int y = 0; y < mapSizeY; y++)
            {
                for (int x = 0; x < mapSizeX; x++)
                {
                    _map[x, y] = "[ ]";
                }
            }
        }

        internal void AddGameEntityAtTheMap(GameEntity gameEntity)
        {
            _map[gameEntity.Coordinates.X, gameEntity.Coordinates.Y] = gameEntity.GameEntityModel;
        }

        internal void DeliteEntityAtTheMap(GameEntity gameEntity)
        {
            _map[gameEntity.Coordinates.X, gameEntity.Coordinates.Y] = "[ ]";
        }

        internal string GetEntityCoordinate(GameEntity gameEntity)
        {
            return _map[gameEntity.Coordinates.X, gameEntity.Coordinates.Y];
        }

        

        internal void MoveEntityUp(GameEntity gameEntity)
        {
            if (gameEntity.Coordinates.Y >= 0)
            {
                gameEntity.Coordinates = new Coordinates(gameEntity.Coordinates.X, gameEntity.Coordinates.Y - PlayerRangeVision);
            }
            if (gameEntity.Coordinates.Y == -1)
            {
                gameEntity.Coordinates = new Coordinates(gameEntity.Coordinates.X, 0);
            }
        }

        internal void MoveEntityDown(GameEntity gameEntity)
        {
            if (gameEntity.Coordinates.Y < _map.GetLength(1))
            {
                gameEntity.Coordinates = new Coordinates(gameEntity.Coordinates.X, gameEntity.Coordinates.Y + PlayerRangeVision);
            }
            if (gameEntity.Coordinates.Y == _map.GetLength(1))
            {
                gameEntity.Coordinates = new Coordinates(gameEntity.Coordinates.X, _map.GetLength(1) - PlayerRangeVision);
            }
        }

        internal void MoveEntityLeft(GameEntity gameEntity)
        {
            if (gameEntity.Coordinates.X >= 0)
            {
                gameEntity.Coordinates = new Coordinates(gameEntity.Coordinates.X - PlayerRangeVision, gameEntity.Coordinates.Y);
            }
            if (gameEntity.Coordinates.X == -1)
            {
                gameEntity.Coordinates = new Coordinates(0, gameEntity.Coordinates.Y);
            }
        }

        internal void MoveEntityRight(GameEntity gameEntity)
        {
            if (gameEntity.Coordinates.X <= _map.GetLength(0))
            {
                gameEntity.Coordinates = new Coordinates(gameEntity.Coordinates.X + PlayerRangeVision, gameEntity.Coordinates.Y);
            }
            if (gameEntity.Coordinates.X == _map.GetLength(0))
            {
                gameEntity.Coordinates = new Coordinates(_map.GetLength(0) - PlayerRangeVision, gameEntity.Coordinates.Y);
            }
        }                   

        internal void InteractionPlayerWithBut(Player player, Bat bat)
        {
            AddGameEntityAtTheMap(bat);

            if (player.Coordinates.Y + PlayerRangeVision < _map.GetLength(1) && 
                _map[player.Coordinates.X, player.Coordinates.Y + PlayerRangeVision] == GetEntityCoordinate(bat))
            {
                bat.GetVoiceBat();
            }

            if (player.Coordinates.Y + PlayerRangeVision == _map.GetLength(1))
            {
                player.Coordinates = new Coordinates(player.Coordinates.X, _map.GetLength(1) - PlayerRangeVision);
            }

            if (player.Coordinates.Y - PlayerRangeVision >= 0 &&
                _map[player.Coordinates.X, player.Coordinates.Y - PlayerRangeVision] == GetEntityCoordinate(bat))
            {
                bat.GetVoiceBat();
            }

            if (player.Coordinates.Y == -1)
            {
                player.Coordinates = new Coordinates(player.Coordinates.X, 0);
            }

            if (GetEntityCoordinate(player) == GetEntityCoordinate(bat))
            {
                player.Coordinates = new Coordinates(random.Next(0, GameSettings.MAP_SIZE_COORDINATE_X), 
                                                     random.Next(0, GameSettings.MAP_SIZE_COORDINATE_Y));
            }
        }

        internal void TakeAShot(Player player, Wumpus wumpus)
        {
            
            if (player.Coordinates.Y + PlayerRangeVision < _map.GetLength(1) && 
                _map[player.Coordinates.X, player.Coordinates.Y + PlayerRangeVision] == GetEntityCoordinate(wumpus))
            {
                
                Console.WriteLine("You hit wumpus!");
                
            }
            else
            {
                Console.WriteLine("You missed");
                
            }
            
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

        internal void CheckMapOutOFRange(Player player)
        {
            if (player.Coordinates.Y == _map.GetLength(1))
            {
                player.Coordinates = new Coordinates(player.Coordinates.X, _map.GetLength(1) - PlayerRangeVision);
            }
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

