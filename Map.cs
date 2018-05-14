using System;
using static System.Console;

namespace intertion
{
    public class Map
    {
        char award;
        char trap;


        public Map(char award, char trap)
        {
            this.award = award;
            this.trap = trap;
        }

        public void DrawMap(int[,] map)
        {
            int[] num = new int[] { 1, 7, 4, 8, 6, 2, 3, 5, 10, 11, 12 };
            char[] sym = new char[] { '║', '═', '╔', '╚', '╝', award, trap, '╗', '↟', '↝', '◎'  };
            ConsoleColor[] colors = new ConsoleColor[] {ConsoleColor.Green,
                ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green,
                ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red,
                ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green};

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {

                    for (int k = 0; k < num.Length  ; k++)
                    {
                        if (num[k] == map[i, j])
                        {
                            Console.ForegroundColor = colors[k];
                            Console.SetCursorPosition(j, i);
                            Console.Write(sym[k]);
                        }
                    }
                        
                }

            }
        }


    }
};
