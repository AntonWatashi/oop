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
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(j, i);
                        Console.Write('║');
                    }
                    if (map[i, j] == 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(j, i);
                        Console.Write('═');
                    }
                    if (map[i, j] == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(j, i);
                        Console.Write('╔');
                    }
                    if (map[i, j] == 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(j, i);
                        Console.Write('╚');
                    }
                    if (map[i, j] == 6)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(j, i);
                        Console.Write('╝');
                    }
                    if (map[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(j, i);
                        Console.Write(award);
                    }
                    if (map[i, j] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(j, i);
                        Console.Write(trap);
                    }

                    if (map[i, j] == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(j, i);
                        Console.Write('╗');
                    }
                    if (map[i, j] == 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(j, i);
                        Console.Write('↟');
                    }
                    if (map[i, j] == 11)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(j, i);
                        Console.Write('⟿');
                    }
                    if (map[i, j] == 12)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(j, i);
                        Console.Write('◎');
                    }

                        
                }

            }
        }


    }
};

