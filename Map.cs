using System;
using static System.Console;

namespace intertion 
{
    public class Map
    {

        static Cell[] mapObjects = new Cell[] {Cell.HWALL,Cell.VWALL,Cell.ARROW,Cell.AWARD,
            Cell.TRAP,Cell.BLC,Cell.BRC,Cell.TRC,Cell.TLC,Cell.SHIELD,Cell.TP};

        public static void DrawMap(Cell[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    
                    for (int k = 0; k < mapObjects.Length; k++)
                    {
                        if (mapObjects[k].number == map[i, j].number)
                        {
                            Console.ForegroundColor = mapObjects[k].color;
                            Console.SetCursorPosition(j, i);
                            Console.Write(mapObjects[k].sym);

                        }

                    }

                }
            }


        }
    }
}
