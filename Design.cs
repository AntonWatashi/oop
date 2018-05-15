using System;
using System.Threading;

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

        public void Menu(int x, int y)
        {
            string[] inertia = new string[]
               {"╔══╦═╗ ╔╦═══╦═══╦════╦══╦═══╗",
                "╚╣╠╣║╚╗║║╔══╣╔═╗║╔╗╔╗╠╣╠╣╔═╗║",
                " ║║║║╚╗║║╔══╣╔╗╔╝ ║║  ║║║╚═╝║",
                "╚══╩╝ ╚═╩═══╩╝╚═╝ ╚╝ ╚══╩╝ ╚╝"};



            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < inertia.Length; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(inertia[i]);
                y++;
            }
            Console.SetCursorPosition(30, y + 2 );
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press E To Continue");
        }

        public void Select(int x, int y, char pointer)
        {
            string[] menu = new string[] { "Start", "Levels", "About", "Quit" };
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

                var key = Console.ReadKey();

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
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(x, y);
                        Console.Write("Level 1");
                        Console.SetCursorPosition(x, y + 1);
                        Console.Write("Level 2");
                        Console.SetCursorPosition(x, y + 2);
                        Console.Write("Level 3");
                        Console.SetCursorPosition(x, y + 3);
                        Console.Write("Level 4");
                        Console.SetCursorPosition(x - 5, y);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine('>');
                        Console.ReadKey(true);
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

        public void Rules(Player hero, char trap, char award, char rest, char player)
        {
          
            Console.SetCursorPosition(40, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0} - You are ", player);
            Console.SetCursorPosition(40, 3);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} — Traps", trap);
            Console.SetCursorPosition(40, 4);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} — Awards", award);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(40, 5);
            Console.WriteLine("{0} — Rest areas", rest);

        }

    }
}
