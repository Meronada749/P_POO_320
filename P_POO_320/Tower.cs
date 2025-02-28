///ETML
///Auteur : Meron Essayas
///Date : 17.01.2025
///Description: 

using System;
using System.Numerics;

namespace P_POO_320
{
    internal class Tower : IUpdateable, IDamageable
    {
        public Vector2 Position { get; set; }
        public int Height { get; set; } // Height for Tower
        public int Width { get; set; } // Width for Tower
        private const char WALL_FORM = '*';
        /// <summary>
        /// every cell can be true or false
        /// </summary>
        private bool [,] CellState; 

        public Tower(int height, int width, int x, int y)
        {
            Height = height;
            Width = width;
            Position = new Vector2(x, y);

            CellState = new bool[Height,Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    CellState[i,j] = true;
                }
            }

            Game.updateable.Add(this);

        }
        public void Display()
        {
            Console.SetCursorPosition((int)Position.X, (int)Position.Y);

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(CellState[i, j] ? WALL_FORM.ToString() : " ");
                }

                Console.WriteLine();
                Console.SetCursorPosition((int)Position.X, (int)Position.Y);
                Position = new Vector2(Position.X, Position.Y - 1);
            }
        }
        public void CheckPosition()
        {
            //for (int i = 0; i < Height; i++)
            //{
            //    for (int i = 0; i < length; i++)
            //    {

            //    }
            //}
        }
        public void Damage()
        {
            
        }
    }
}
