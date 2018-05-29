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
            var level = FS.ParseLevel(File.ReadAllLines("map1.txt"));

            var map = new Map(); // char award, char trap
            //design
                var design = new Design();
                design.Menu(25, 6);
                design.Select(25, 8, '☞');
                design.Loading(28, 10);

                
                Console.ForegroundColor = ConsoleColor.DarkGreen;

            //player creation

            var hero = new Player(5, 5, player);
                
            //Hud creation ( hp and points)
            Design.hud(hero);

            // update object
            var upd = new Update(hero, trap, player, award, rest, level);

            Map.DrawMap(level);
                //enemy.Draw();
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
}
