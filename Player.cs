using System;
namespace intertion
{
    public class Player
    {
       public int x;
       public int y;
       public char sym;
        char temp;
        public int points;
        public string direction;
        public int hp;
        public string name;
        public int counter = 1;
        public bool win = false;

        public Player (int x, int y, char sym) 
        {
            this.hp = 3;    
            this.x = x;
            this.y = y;
            this.sym = sym;
            this.temp = sym;
            this.points = 0;
            this.direction = " ";
        }
        public void Draw ()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition (x, y);
            Console.Write (sym);
            sym = temp;
        }
        public void Clear () 
        {
            sym = ' ';
            Draw();
        }
        public void Reset ()
        {
            this.points = 0;
            this.hp = 3;
            this.win = false;
            this.x = 5;
            this.y = 5;
        }
    }
}
