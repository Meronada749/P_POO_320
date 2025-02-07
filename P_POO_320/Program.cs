///ETML
///Auteur : Meron Essayas
///Date : 17.01.2025
///Description: 

using System;
using System.Text;

namespace P_POO_320
{
    internal class Program
    {
        static void Main(string[]args)
        {
            Game game = new Game();

            Console.OutputEncoding = Encoding.UTF8;

            Console.SetWindowSize(150, 40);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = false;
            Console.SetCursorPosition((int)Game.GroundPosition.X, (int)Game.GroundPosition.Y);
            Console.Write("-----------------------------------------------------------------");

            game.Ball.PressSpaceBar(game.Player1);
             



            Console.ReadLine();
        }

    }
}
