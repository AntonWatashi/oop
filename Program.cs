using System;
using System.Threading;
using System.Collections.Generic;
using System.Media;
using System.IO;
using System.Runtime.InteropServices; //for P/Invoke DLLImport

namespace intertion
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            
            //design
            Console.CursorVisible = false;
            Console.CursorVisible = false;
            char trap = '♞';
            char player = '♛';
            char award = '♟';
            char rest = '◴';

            var map1 = new int[,]
            {   {4,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,5},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,1,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,7,7,7,7,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,3,0,0,0,0,0,0,1},
                {1,0,0,0,0,12,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,3,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,2,0,7,7,7,7,0,0,0,0,1},
                {1,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,3,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,12,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1},
                {8,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,6}

        //1 = walls
        //0 = empty
        //2 = awards;
        //3 = traps


            };

            var map = new Map(award, trap); // char award, char trap

           


           
            var design = new Design();


            design.Menu();

            var menu = Console.ReadKey(true);
            if (menu.Key == ConsoleKey.E)
            {
                design.Select(25,8,'☞');
                design.Loading(28, 10);



                //design
                Console.ForegroundColor = ConsoleColor.DarkGreen;


               


                //player creation

                var hero = new Player(5, 5, player);
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(45, 7);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Your Points: " + hero.points);




                // 
                var upd = new Update(hero, trap, player, award, rest, map1);



                map.DrawMap(map1);
                hero.Draw();
                design.Rules(hero, trap, award, rest, player);
                //game
                while (true)
                {
                    
                    if (Console.KeyAvailable)
                    {
                        
                        var key = Console.ReadKey(true);
                        upd.Start(key);



                    }

                   
                   



                }
            }

           
           

        

        }
    }
}
