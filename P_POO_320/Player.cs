///ETML
///Auteur : Meron Essayas
///Date : 17.01.2025
///Description: 

using System;
using System.Numerics;

namespace P_POO_320
{
    internal class Player : IUpdateable, IDamageable
    {
        public ConsoleColor PlayerColor { get; set; }
        public Vector2 PlayerPosition { get; set; } 
        public string[] Person {  get; set; } =
        {
            @" O ",
            @"/|\",
            @"/ \"
        };

        public Player(int x, int y, ConsoleColor PlayerColor)
        {
            PlayerPosition = new Vector2(x, y);
            this.PlayerColor = PlayerColor;

            Game.updateable.Add(this);
        }
        public void Display()
        {
            Console.SetCursorPosition((int)PlayerPosition.X, (int)PlayerPosition.Y);

            foreach (string item in Person)
            {
                Console.SetCursorPosition((int)PlayerPosition.X, Console.CursorTop);
                Console.ForegroundColor = PlayerColor;
                Console.WriteLine(item);
                Console.ResetColor();
            }
        }

        public void Damage()
        {

        }
    }
}
