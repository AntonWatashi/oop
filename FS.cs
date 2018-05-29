using System;
namespace intertion
{
    public class FS
    {
        const int VWALL = 1;
        const int HWALL = 7;
        const int TLC = 4;
        const int BLC = 8;
        const int BRC = 6;
        const int TRC = 5;
        const int SHIELD = 10;
        const int ARROW = 11;
        const int TP = 12;
        const int TRAP = 3;
        const int AWARD = 2;
        const int GAP = 0;
        public static Cell[,] ParseLevel(string[] lines)
        {
            
            Cell[,] wall = new Cell[lines.Length, lines[0].Split(',').Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(',');
                for (int j = 0; j < temp.Length; j++)

                    switch (Int32.Parse(temp[j]))
                    {
                           
                        case VWALL:
                            wall[i, j] = Cell.VWALL;
                            break;
                        case TRAP:
                            wall[i, j] = Cell.TRAP;
                            break;
                        case AWARD:
                            wall[i, j] = Cell.AWARD;
                            break;
                        case HWALL:
                            wall[i, j] = Cell.HWALL;
                            break;
                        case TLC:
                            wall[i, j] = Cell.TLC;
                            break;
                        case BLC:
                            wall[i, j] = Cell.BLC;
                            break;
                        case BRC:
                            wall[i, j] = Cell.BRC;
                            break;
                        case TRC:
                            wall[i, j] = Cell.TRC;
                            break;
                        case ARROW:
                            wall[i, j] = Cell.ARROW;
                            break;
                        case TP:
                            wall[i, j] = Cell.TP;
                            break;
                        case SHIELD:
                            wall[i, j] = Cell.SHIELD;
                            break;
                        case  GAP:
                            wall[i, j] = Cell.GAP;
                            break;
                    }
            }
            return wall;
        }
    }
}
