///ETML
///Auteur : Meron Essayas
///Date : 17.01.2025
///Description: 

using System;
using System.Numerics;

namespace P_POO_320
{
    internal class Ball  : IUpdateable
    {
        public Vector2 Position { get; set; }

        public Vector2? LastPosition; //nullable

        public Vector2 Velocity;

        private const float TIME_STEP = 0.2f;

        private const float GRAVITY = 0.5f;

        private const char BALL_FORM = '●';

        public Ball() 
        {
            Position = Vector2.Zero;
            Velocity = Vector2.Zero;
            LastPosition = null;

            Game.updateable.Add(this);
        }

        public void Display()
        
        {
            if (LastPosition.HasValue)
            {
                Console.SetCursorPosition((int)LastPosition.Value.X, (int)LastPosition.Value.Y);

                Console.Write(" ");
            }
            Console.SetCursorPosition((int)Position.X, (int)Position.Y);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(BALL_FORM);
            Console.ResetColor();
        }

        public void Launch(float angle, float force, Vector2 startPosition)
        {
            Position = startPosition;
            LastPosition = null;

            float radians = (float)(Math.PI * angle / 180f);

            Velocity = new Vector2(
                (float)(force* Math.Cos(radians)),
                (float)(-force * Math.Sin(radians))
                );
        }

        public void Update()
        {
            LastPosition = Position;

            Position += Velocity * TIME_STEP;

            Velocity = new Vector2(Velocity.X, Velocity.Y + GRAVITY * TIME_STEP);
        }
    }
}
