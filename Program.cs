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
            char player = '♛';
             
            var hero = new Player(5, 5, player);
            Game(player, hero);
        }

        static void Game (char player, Player hero)
        {
            hero.Reset();
            string lvl = "map" + hero.counter + ".txt";
            var level = FS.ParseLevel(File.ReadAllLines(lvl));

            var map = new Map(); // char award, char trap

           
            var enemy = new Enemy(6, 6, '@');

            //design
            var design = new Design();
            Console.ForegroundColor = ConsoleColor.Red;
            if (hero.counter == 1)
            {
                
                design.Select(25, 8, '☞');
                design.getName(hero);
                design.Loading(28, 10);

            }
            else
            {
                Console.SetCursorPosition(28, 10);
                Console.Write("Pess any key to continue...");
                Console.ReadKey(true);
                design.Loading(28, 10);
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            //player creation


            //Hud creation ( hp and points)
            Design.hud(hero);

            // update object
            var upd = new Update(hero, level);

            Map.DrawMap(level);
            //enemy.Draw();
            hero.Draw();
            design.Rules(hero, Cell.TRAP, Cell.AWARD, Cell.TP, player);
            //Thread sw = new Thread(stopWatch);
            //sw.Start();

            //game
            while (!hero.win)
            {

                if (Console.KeyAvailable)
                {

                    var key = Console.ReadKey(true);
                    upd.Start(key);
                }
            }
            hero.counter++;
            Game(player, hero);
        } 
    }
}
