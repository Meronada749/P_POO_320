using System;
using System.Collections.Generic;
using System.Numerics;

namespace P_POO_320
{
    internal class Tower : IUpdateable
    {
        public Vector2 Position { get; set; }
        public int Height { get; set; }
        public int Width { get; set; } // width for tower
        private const char WALL_FORM = '*';

        /// <summary>
        /// Custom constructor
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Tower(int height, int width, int x, int y)
        {
            Height = height;
            Width = width;
            Position = new Vector2(x, y);
            Game.updateable.Add(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] GetTowerStructure()
        {
            string[] structure = new string[Height];

            string stars = new string(WALL_FORM, Width);

            for (int i = 0; i < Height; i++)
            {
                structure[i] = stars;
            }

            return structure;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Display()
        {
            Console.SetCursorPosition((int)Position.X, (int)Position.Y);
            foreach (string item in GetTowerStructure())
            {
                Console.SetCursorPosition((int)Position.X, Console.CursorTop);
                Console.WriteLine(item);
            }
        }
    }
}
