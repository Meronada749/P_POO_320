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

        public Tower(int height, int width, int x, int y)
        {
            Height = height;
            Width = width;
            Position = new Vector2(x, y);

            Game.updateable.Add(this);
        }
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
        public void Display()
        {
            Console.SetCursorPosition((int)Position.X, (int)Position.Y);

            foreach (string item in GetTowerStructure())
            {
                Console.SetCursorPosition((int)Position.X, --Console.CursorTop);
                Console.Write(item);
            }
        }

        public void Damage()
        {

        }
    }
}
