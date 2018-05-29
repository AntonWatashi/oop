using System;
using System.Collections.Generic;
using System.Threading;

namespace intertion
{

    public class Update
    {

        public Player hero;

        char trap;
        char player;
        char award;
        char rest;
        Cell[,] map;
        bool check;

        //constructor
        public Update(Player hero, char trap, char player, char award, char rest, Cell[,] map)
        {
            this.hero = hero;
            this.trap = trap;
            this.rest = rest;
            this.player = player;
            this.award = award;
            this.map = map;
            this.check = false;



        }
        //Moving
        public void Start(ConsoleKeyInfo key)
        {
            int awards = 0;
            check = false;

            if (key.Key == ConsoleKey.RightArrow)
            {
                _moveRight();
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {

                _moveLeft();

            }
            else if (key.Key == ConsoleKey.DownArrow)
            {

                _moveDown();
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {

                _moveUp();

            }
            //drawing hero
            Draw();
            if (hero.hp < 1)
            {
                Console.Clear();
                Console.SetCursorPosition(30, 10);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("GAME OVER!");
                Environment.Exit(0);
            }
            else
            {
                foreach (Cell i in map)
                {
                    if (i == Cell.AWARD)
                        awards += 1;
                }
                if (awards == 0)
                {
                    Console.Clear();
                    Console.SetCursorPosition(30, 10);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("YOU WON!");
                    Environment.Exit(0);
                }
            }

        }
        //each 0.040 sec update. Hero drawing and collision checking
        private void upd()
        {
            Draw();
            Collision();
            Thread.Sleep(40);
        }
        //method to draw hero
        private void Draw()
        {
            Console.SetCursorPosition(hero.x, hero.y);
            Console.Write(player);
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

            if (map[hero.y + c, hero.x + z] == Cell.AWARD || map[hero.y + c, hero.x + z] == Cell.TRAP)
            {
                //points 
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
            if (map[hero.y + c, hero.x + z] == Cell.SHIELD)
            {

                shield(hero);

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
                upd();



            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45, 7);
            Console.Write("Your HeatPoints: ");
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
            Console.Write("Your Points: " + hero.points);


        }

        private void shield (Player hero)
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

