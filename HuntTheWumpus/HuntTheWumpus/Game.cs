using System;
using HuntTheWumpus.GameEntitys;

namespace HuntTheWumpus
{
    
    
    public class Game
    {
        public void StartGame()
        {
            Random random = new Random();
            Map map = new Map(GameSettings.MAP_SIZE_COORDINATE_X, GameSettings.MAP_SIZE_COORDINATE_Y);
            Player player = new Player(new Coordinates(random.Next(0, GameSettings.MAP_SIZE_COORDINATE_X), random.Next(0, GameSettings.MAP_SIZE_COORDINATE_Y)));            
            Bat firstBat = new Bat(new Coordinates(random.Next(0, 6), random.Next(0, 6)));
            Bat secondBat = new Bat(new Coordinates(random.Next(0, 6), random.Next(0, 6)));            
            Pit firstPit = new Pit(new Coordinates(random.Next(0, 6), random.Next(0, 6)));
            Pit secondPit = new Pit(new Coordinates(random.Next(0, 6), random.Next(0, 6)));
            map.AddGameEntity(player);           

            bool _playerIsAlive = true;
            bool _wumpusISAlive = true;

            while (_playerIsAlive && _wumpusISAlive)
            {
                Console.Clear();
                PrintGameRules();
                Wumpus wumpus = new Wumpus(new Coordinates(random.Next(0, GameSettings.MAP_SIZE_COORDINATE_X), random.Next(0, GameSettings.MAP_SIZE_COORDINATE_Y)));
                map.AddGameEntity(firstBat);
                map.AddGameEntity(player);
                map.AddGameEntity(secondBat);
                map.AddGameEntity(firstPit);
                map.AddGameEntity(secondPit);
                map.AddGameEntity(wumpus);
                
                PrintMap(map.GetMap());
                PrintGameMessage();
                player.InteractionWithGameEntitys(wumpus, map.GetMap());
                player.InteractionWithGameEntitys(firstBat, map.GetMap());
                player.InteractionWithGameEntitys(firstPit, map.GetMap());                              
                map.DeliteEntity(player);
                map.DeliteEntity(wumpus);

                ConsoleKeyInfo userInput = Console.ReadKey(true);

                switch (userInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        player.MoveUp();
                        //map.AddGameEntity(player);                        
                        break;

                    case ConsoleKey.DownArrow:
                        player.MoveDown(map.GetMap());                        
                        //map.AddGameEntity(player);
                        break;

                    case ConsoleKey.LeftArrow:
                        player.MoveLeft();                        
                        //map.AddGameEntity(player);
                        break;

                    case ConsoleKey.RightArrow:
                        player.MoveRight(map.GetMap());                        
                        //map.AddGameEntity(player);
                        break;

                    case ConsoleKey.W:

                        map.TakeAShot(player, wumpus);
                        
                        
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
