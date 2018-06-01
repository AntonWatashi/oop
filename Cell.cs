using System;
namespace intertion
{
    public class Cell
    {
        public char sym;
        public ConsoleColor color;
        public string name;
        public int number;
        public Cell(char sym, ConsoleColor color, string name, int number)
        {
            this.sym = sym;
            this.color = color;
            this.name = name;
            this.number = number;
        }

        public Cell(string name)
        {
            this.name = name;
        }

        public Cell()
        {

        }

        public static Cell VWALL = new Cell('║', ConsoleColor.Green, "wall", 1);
        public static Cell HWALL = new Cell('═', ConsoleColor.Yellow, "wall", 7);
        public static Cell TRAP = new Cell('♞', ConsoleColor.DarkRed, "trap", 2);
        public static Cell AWARD = new Cell('♟', ConsoleColor.Yellow, "award", 3);
        public static Cell TLC = new Cell('╔', ConsoleColor.Green, "wall", 4);
        public static Cell BLC = new Cell('╚', ConsoleColor.Green, "wall", 8);
        public static Cell TRC = new Cell('╝', ConsoleColor.Green, "wall", 5);
        public static Cell BRC = new Cell('╗', ConsoleColor.Green, "wall", 5);
        public static Cell TP = new Cell('◎', ConsoleColor.Cyan, "tp", 12);
        public static Cell ARROW = new Cell('>', ConsoleColor.Cyan, "arrow", 11);
        public static Cell SHIELD = new Cell('/', ConsoleColor.Cyan, "shield", 10);
        public static Cell GAP = new Cell(' ', ConsoleColor.Cyan, "gap", 0);

    }

}
