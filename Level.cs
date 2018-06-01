using System;
using System.IO;
namespace intertion
{
    public class Level
    {
        int level;
       
        public Level(int level)
        {
            this.level = level;
        }

        void load ()
        {
           var lvl = FS.ParseLevel(File.ReadAllLines("map1.txt"));  
        }
}
