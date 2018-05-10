using System;
namespace intertion
{
    public class FS
    {
        public static int[,] ParseLevel(string[] lines)
        {
            int[,] wall = new int[lines.Length, lines[0].Split(',').Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(',');
                for (int j = 0; j < temp.Length; j++)

                    wall[i, j] = Int32.Parse(temp[j]);
            }
            return wall;
        }
    }
}
