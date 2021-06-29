using System;
using HuntTheWumpus.GameEntitys;

namespace HuntTheWumpus
{
    public class Game
    {
        public void StartGame()
        {         
            Random random = new Random();
            Map map = new Map(GameSettings.MAP_SIZE_COORDINATE_X, GameSettings.MAP_SIZE_COORDINATE_Y, GameSettings.MAP_PLAEYER_RANGE_VISION);
            Player player = new Player(random);
            Wumpus wumpus = new Wumpus(random);
            Bat firstBat = new Bat(new Coordinates(random.Next(0, 6), random.Next(0, 6)));
            Bat secondBat = new Bat(new Coordinates(random.Next(0, 6), random.Next(0, 6)));
            Pit firstPit = new Pit(new Coordinates(random.Next(0, 6), random.Next(0, 6)));
            Pit secondPit = new Pit(new Coordinates(random.Next(0, 6), random.Next(0, 6)));
            map.AddGameEntity(player);
            map.CheckMapUniqCoordinateGameEntity(player, firstBat, secondBat, firstPit, secondPit);            

            bool _playerIsAlive = true;
            bool _wumpusISAlive = true;
            
            while (_playerIsAlive && _wumpusISAlive)
            {                
                Console.Clear();
                PrintGameRules();

                Wumpus newWumpus = new Wumpus(random);
                
                //map.AddGameEntityAtTheMap(secondBat);
                //map.AddGameEntityAtTheMap(firstBat);
                map.AddGameEntity(firstPit);
                map.AddGameEntity(secondPit);                
                map.AddGameEntity(newWumpus);
                
                PrintMap(map.GetMap());                
                PrintGameMessage();

                map.InteractionPlayerWithBut(player, firstBat);                
                _playerIsAlive = map.InteractionPlayerWithPit(player, secondPit);
                map.DeliteEntity(player);
                //map.DeliteEntityAtTheMap(firstBat);

                ConsoleKeyInfo InputKeyInfo = Console.ReadKey(true);                
                 
                switch (InputKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        map.MoveEntityUp(player);
                        map.AddGameEntity(player);
                        map.DeliteEntity(newWumpus);
                        

                        break;

                    case ConsoleKey.DownArrow:
                        map.MoveEntityDown(player);
                        map.DeliteEntity(newWumpus);
                        map.AddGameEntity(player);
                        break;

                    case ConsoleKey.LeftArrow:
                       
                        map.MoveEntityLeft(player);
                        map.DeliteEntity(newWumpus);
                        map.AddGameEntity(player);
                        break;

                    case ConsoleKey.RightArrow:
                        map.MoveEntityRight(player);
                        map.DeliteEntity(newWumpus);
                        map.AddGameEntity(player);
                        break;

                    case ConsoleKey.W:
                        
                        map.TakeAShot(player, wumpus);
                        map.DeliteEntity(newWumpus);
                        map.AddGameEntity(player);
                        break;
                }

                
            }
        }            

        public void PrintMap(string[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }

                Console.WriteLine();
            }
        }

        public void PrintGameRules()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("UpArrow    - Move in Up");
            Console.WriteLine("DownArrow  - Move in Down");
            Console.WriteLine("RightArrow - Move in Right");
            Console.WriteLine("LeftArrow  - Move in Left");
            Console.WriteLine();
            Console.WriteLine("W - Shot in Up");
            Console.WriteLine("S - Shot in Down");
            Console.WriteLine("A - Shot in Left");
            Console.WriteLine("D - Shot in Right");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
        }

        public void PrintGameMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Massege label:");
        }         
    }
}
