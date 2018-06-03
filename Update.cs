using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace intertion
{

    public class Update
    {

        public Player hero;

        Cell[,] map;
        bool check;

        //constructor
        public Update(Player hero, Cell[,] map)
        {
            this.hero = hero;
            this.map = map;
            this.check = false;
        }
        //Moving
        public void Start(ConsoleKeyInfo key)
        {

            check = false;
            //read key
            if (key.Key == ConsoleKey.RightArrow)
                _moveRight();
            else if (key.Key == ConsoleKey.LeftArrow)
                _moveLeft();
            else if (key.Key == ConsoleKey.DownArrow)
                _moveDown();
            else if (key.Key == ConsoleKey.UpArrow)
                _moveUp();

            //drawing hero
            hero.Draw();
            //win or lose check
            WinOrLose();

        }
        //each 0.040 sec update. Hero drawing and collision checking
        private void upd()
        {
            hero.Draw();
            Collision();
            Thread.Sleep(40);
        }

        //method to check collisions
        public void Collision()
        {
            if (hero.direction == "right")
                _collision(1, 0);
            else if (hero.direction == "left")
                _collision(-1, 0);
            else if (hero.direction == "up")
                _collision(0, -1);
            else if (hero.direction == "down")
                _collision(0, 1);
        }
        //if collision == true  then we shold detect with what object our collsion happened

        private void _collision(int z, int c)
        {
            //if collision player hited in award or trap than we REcount points
            if (map[hero.y + c, hero.x + z] == Cell.AWARD || map[hero.y + c, hero.x + z] == Cell.TRAP)
            {
                PointsCounter(z, c);
            }
            if (map[hero.y + c, hero.x + z] == Cell.SHIELD)
            {
                Shield(hero);
            }
            if (map[hero.y + c, hero.x + z] == Cell.ARROW)
            {
                hero.direction = "right";
                _moveRight();
                check = true;
            }
            if (map[hero.y + c, hero.x + z] == Cell.TP)
            {
                check = true;
                bool _check = false;
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    for (int x = 0; x < map.GetLength(1); x++)
                    {

                        if (map[y, x] == Cell.TP && y != hero.y + c && x != hero.x + z)
                        {
                            hero.Clear();
                            hero.x = x + z;
                            hero.y = y + c;
                            _check = true;

                            break;
                        }
                        if (_check) break;
                    }
                }
                check = false;
                switch (hero.direction)
                {
                    case "right":
                        _moveRight();
                        break;
                    case "left":
                        _moveLeft();
                        break;
                    case "down":
                        _moveDown();
                        break;
                    case "up":
                        _moveUp();
                        break;

                }
            }
            //update points and hp
            HudUpd();
        }



        private void WinOrLose()
        {

            if (hero.hp < 1)
            {
                WriteScore();
                Console.Clear();
                Console.SetCursorPosition(30, 10);
                Console.ForegroundColor = ConsoleColor.White;
                if (hero.counter > 1)
                    hero.counter -= 1;
                hero.win = true;
                Console.WriteLine("GAME OVER!");
            }
            else
            {
                int awards = 0;
                foreach (Cell i in map)
                {
                    if (i == Cell.AWARD)
                        awards += 1;
                }
                if (awards == 0)
                {
                    WriteScore();
                    Console.Clear();
                    Console.SetCursorPosition(30, 10);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("YOU WON!");
                    Console.Clear();
                    hero.win = true;
                }
            }
        }
        private void PointsCounter(int z, int c)
        {
            if (map[hero.y + c, hero.x + z] == Cell.TRAP)
                hero.hp -= 1;
            else
                hero.points += 100;
            check = true;
            map[hero.y + c, hero.x + z] = Cell.GAP;
            Console.SetCursorPosition(45, 7);
            Console.Write("                     ");

            //delete object after collision
            Console.SetCursorPosition(hero.x + z, hero.y + c);
            Console.Write(' ');
        }

        private void HudUpd()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45, 7);
            Console.Write("{0} HeatPoints: ", hero.name);
            Console.Write("        ");
            Console.SetCursorPosition(62, 7);
            for (int i = 0; i < hero.hp; i++)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('❤');
                Console.Write(' ');
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45, 9);
            Console.Write("{0} Points: " + hero.points, hero.name);

        }

        private void WriteScore()
        {
            if (File.Exists("Score.txt"))
            {
                string[] res = new string[] { hero.name, hero.points.ToString() };
                var m = File.ReadAllLines("Score.txt");
                File.AppendAllLines("Score.txt", res);
            }
        }
        private void Shield(Player hero)
        {
            if (hero.direction == "up")
            {
                _moveRight();
                check = true;
                return;
            }
            else if (hero.direction == "right")
            {
                _moveUp();
                check = true;
                return;
            }
            else if (hero.direction == "left")
            {
                _moveDown();
                check = true;
                return;
            }
            else if (hero.direction == "down")
            {
                _moveLeft();
                check = true;
                return;
            }
        }
        private void _moveLeft()
        {
            hero.direction = "left";
            while (map[hero.y, hero.x - 1] == Cell.GAP)
            {

                hero.x -= 1;
                Console.SetCursorPosition(hero.x + 1, hero.y);
                Console.Write(' ');
                upd();
                if (check) break;
            }
        }
        private void _moveUp()
        {
            hero.direction = "up";
            while (map[hero.y - 1, hero.x] == Cell.GAP)
            {
                hero.y -= 1;
                Console.SetCursorPosition(hero.x, hero.y + 1);
                Console.Write(' ');
                upd();
                if (check) break;
            }
        }
        private void _moveRight()
        {
            hero.direction = "right";
            while (map[hero.y, hero.x + 1] == Cell.GAP)
            {
                hero.x += 1;
                Console.SetCursorPosition(hero.x - 1, hero.y);
                Console.Write(Cell.GAP.sym);
                upd();
                if (check) break;
            }
        }
        private void _moveDown()
        {
            hero.direction = "down";
            while (map[hero.y + 1, hero.x] == Cell.GAP)
            {
                hero.y += 1;
                Console.SetCursorPosition(hero.x, hero.y - 1);
                Console.Write(' ');
                upd();
                if (check) break;
            }

        }
    }
}

