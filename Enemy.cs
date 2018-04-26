using System;
using System.Threading;
namespace intertion
{
    public struct Enemy 
    {
        int x;
        int y;
        char sym;
        char temp;

        public Enemy(int x, int y, char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
            this.temp = sym;
        }

        private void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
            sym = temp;

        }
        private void Clear()
        {
            sym = ' ';
            Thread.Sleep(100);
            Draw();

        }
        public void Move ()
        {
          

                
        }
    }
}
