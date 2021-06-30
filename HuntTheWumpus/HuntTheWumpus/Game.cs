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
            Player player = new Player(new Coordinates(random.Next(0, GameSettings.MAP_SIZE_COORDINATE_X), random.Next(0, GameSettings.MAP_SIZE_COORDINATE_Y)));
           
            //Wumpus wumpus = new Wumpus(new Coordinates(random.Next(0, GameSettings.MAP_SIZE_COORDINATE_X), random.Next(0, GameSettings.MAP_SIZE_COORDINATE_Y)));
            Bat firstBat = new Bat(new Coordinates(random.Next(0, 6), random.Next(0, 6)));
            Bat secondBat = new Bat(new Coordinates(random.Next(0, 6), random.Next(0, 6)));
            
            map.AddGameEntity(new Pit(new Coordinates(random.Next(0, 6), random.Next(0, 6))));
            map.AddGameEntity(new Pit(new Coordinates(random.Next(0, 6), random.Next(0, 6))));
            map.AddGameEntity(player);
            //map.CheckMapUniqCoordinateGameEntity(player, firstBat, secondBat, firstPit, secondPit);            

            bool _playerIsAlive = true;
            bool _wumpusISAlive = true;
            
            while (_playerIsAlive && _wumpusISAlive)
            {                
                Console.Clear();
                PrintGameRules();
                Wumpus wumpus = new Wumpus(new Coordinates(random.Next(0, GameSettings.MAP_SIZE_COORDINATE_X), random.Next(0, GameSettings.MAP_SIZE_COORDINATE_Y)));
                //map.AddGameEntity(new Wumpus(new Coordinates(random.Next(0, GameSettings.MAP_SIZE_COORDINATE_X), random.Next(0, GameSettings.MAP_SIZE_COORDINATE_Y))));
                // Wumpus newWumpus = new Wumpus(random);                

                //map.AddGameEntity(firstPit);
                //map.AddGameEntity(secondPit);                
                map.AddGameEntity(wumpus);

                PrintMap(map.GetMap());                
                PrintGameMessage();

                map.InteractionPlayerWithBut(player, firstBat);                
                //_playerIsAlive = player.InteractionPlayerWithPit(pit, map.GetMap());
                map.DeliteEntity(player);               

                ConsoleKeyInfo userInput = Console.ReadKey(true);                
                 
                switch (userInput.Key)
                {
                    case ConsoleKey.UpArrow:                        
                        player.MoveUp();
                        map.AddGameEntity(player);
                        map.DeliteEntity(wumpus);                 
                        break;

                    case ConsoleKey.DownArrow:                        
                        player.MoveDown(map.GetMap());
                        map.DeliteEntity(wumpus);
                        map.AddGameEntity(player);
                        break;

                    case ConsoleKey.LeftArrow:                        
                        player.MoveLeft();
                        map.DeliteEntity(wumpus);
                        map.AddGameEntity(player);
                        break;

                    case ConsoleKey.RightArrow:                        
                        player.MoveRight(map.GetMap());
                        map.DeliteEntity(wumpus);
                        map.AddGameEntity(player);
                        break;

                    case ConsoleKey.W:
                        
                        map.TakeAShot(player, wumpus);
                        map.DeliteEntity(wumpus);
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
