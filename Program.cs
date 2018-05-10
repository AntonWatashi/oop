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
            var map1 = FS.ParseLevel(File.ReadAllLines("map1.txt"));

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
                //Thread sw = new Thread(stopWatch);
                //sw.Start();

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
        //static public void stopWatch()
        //{
        //    int minutes = 0;
        //    int seconds = 0;
        //    Console.SetCursorPosition(42, 12);
        //    Console.Write("Time to end: ");
        //    Console.SetCursorPosition(55, 12);
        //    Console.Write(minutes + ":" + seconds);
        //    while (minutes < 1)
        //    {
        //        Console.SetCursorPosition(55, 12);
        //        Console.Write(minutes + ":" + seconds);
        //        seconds += 1;
        //        if (seconds % 60 == 0)
        //        {
        //            minutes += 1;
        //            seconds -= 60;
        //        }

        //        Thread.Sleep(100);

        //    }
        //    Console.Clear();
        //    Console.Write("You Lost!");

        //    Environment.Exit(0);

        //}
    }
}
