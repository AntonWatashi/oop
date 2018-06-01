using System;
using System.Threading;
namespace intertion
{
    public class Enemy : Player
    {
        new int x;
        new int y;
        new char sym;
        char temp;

        public Enemy(int x, int y, char sym) : base(x, y, sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
            this.temp = sym;
        }
    }
}
