///ETML
///Auteur : Meron Essayas
///Date : 17.01.2025
///Description: 
///
using System;

namespace P_POO_320
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Console.SetWindowSize(150, 40);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(0, 40);
            Console.Write("--------------------------------------------------------------");

            Game game = new Game();
            game.Player1.Positions();
            game.Player2.Positions();

            foreach (IUpdateable item in Game.updateable)
            {
                item.Display();
            }

            Console.WriteLine();
        }
    }
}
