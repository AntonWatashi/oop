using System;
namespace intertion
{
    public class Player
    {
       public int x;
       public int y;
        char sym;
        char temp;
        public int points;
        public string direction;

        public Player (int x, int y, char sym) 
        {
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

       
          

    }
}
