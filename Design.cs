using System;
using System.Threading;
using System.IO;
namespace intertion
{
    public struct Design 
    {
        public   void Loading(int x, int y)
        {
            Console.Clear();
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(x + 8, y);
                Console.Write("Loading.");
                Thread.Sleep(120);

                Console.Clear();
                Console.SetCursorPosition(x + 8, y);
                Console.Write("Loading..");
                Thread.Sleep(120);
                Console.Clear();
                Console.SetCursorPosition(x + 8, y);
                Console.Write("Loading...");
                Thread.Sleep(120);
                Console.Clear();

            }
            Console.Clear();

        }
        public void getName(Player hero)
        {
            Console.Clear();
            Console.SetCursorPosition(20, 7);
            Console.Write("Enter your nickname (LESS THEN 6 SYMBOLS):");
            Console.SetCursorPosition(24, 10);
            Console.CursorVisible = true;
            var name = Console.ReadLine();
            if (name.Length < 6)
                hero.name = name;
            else
                hero.name = "Yours";
            Console.CursorVisible = false;
        }
        public static void hud(Player hero)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45, 9);
            Console.Write("{0} Points: " + hero.points, hero.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45, 7);
            Console.Write("{0} HeatPoints: ", hero.name);
            Console.Write("        ");
            Console.SetCursorPosition(62, 7);
            for (int i = 0; i < hero.hp; i++)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('❤');
                Console.Write(' ');
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45, 9);
            Console.Write("{0} Points: " + hero.points, hero.name);
        }
        

        public void Select(int x, int y, char pointer)
        {
            string[] menu = new string[] { "Start", "ScoreBoard", "About", "Quit" };
            int click = 5;
            Console.Clear();
            int temp = y;
            int _temp = y;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < menu.Length; i++)
            {
                Console.SetCursorPosition(x + 10, _temp);
                Console.Write(menu[i]);
                _temp++;
            }
            while (true)
            {

                Console.SetCursorPosition(x + 5, y);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(pointer);

                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.DownArrow && click > 2)
                {
                    click -= 1;

                    y++;
                    Console.SetCursorPosition(x + 5, y - 1);
                    Console.Write(' ');
                    Console.SetCursorPosition(x + 5, y);

                }


                if (key.Key == ConsoleKey.UpArrow && click < 5)
                {
                    click += 1;

                    y--;
                    Console.SetCursorPosition(x + 5, y + 1);
                    Console.Write(' ');
                    Console.SetCursorPosition(x + 5, y);



                }
                if (key.Key == ConsoleKey.Enter)
                {
                    if (y == temp + 1)
                    {
                        Console.Clear(); Console.Clear();
                        var top = File.ReadAllLines("Score.txt");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(x, y);
                        for (int i = 0; i < 10; i += 2)
                        {
                            Console.SetCursorPosition(x, y + i);
                            if (top[i].Length > 1)
                            {
                                Console.Write("{0} — {1}",top[i],top[i + 1]);
                            }
                                
                            else
                                Console.Write("Empty");
                        }
                        Console.ReadKey(true);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Select(25, 8, '☞');
                    }
                    if (y == temp + 2)
                    {
                        Console.Clear();
                        Console.WriteLine("About");
                    }
                    if (y == temp + 3)
                        Environment.Exit(0);
                    Thread.Sleep(300);
                    break;
                }



            }
           
        
        }

        public void Rules(Player hero, Cell trap, Cell award, Cell rest, char player)
        {
          
            Console.SetCursorPosition(40, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0} - You are ", player);
            Console.SetCursorPosition(40, 3);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} — Traps", trap.sym);
            Console.SetCursorPosition(40, 4);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} — Awards", award.sym);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(40, 5);
            Console.WriteLine("{0} — Teleports", rest.sym);

        }

    }
}
