using System;
using System.Numerics;

namespace P_POO_320
{
    internal class People
    {
        /// <summary>
        /// chris mark
        /// </summary>      
        public Vector2 Position { get; set; }
        public string[] Person {  get; set; } =
        {
            @" O ",
            @"/|\",
            @"/ \"
        };


        /// <summary>
        /// Custom constructor
        /// </summary>
        public People(int x, int y)
        {
            Position = new Vector2(x,y); 
        }

        /// <summary>
        /// 
        /// </summary>
        public void Positions()
        {
            Console.SetCursorPosition((int)Position.X, (int)Position.Y);
            foreach (string s in Person)
            {
                Console.SetCursorPosition((int)Position.X, Console.CursorTop);
                Console.WriteLine(s);
            }
        }

    }
}
