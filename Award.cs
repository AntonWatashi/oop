using System;
namespace intertion
{
    public class Award
    {
        public int x;
        public int y;
        public char sym;

        public Award(int x, int y, char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
    }
}
