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
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(150, 40);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = false;   
            Console.SetCursorPosition(0, 40);
            Console.Write("-----------------------------------------------------------------");


            Game game = new Game();

            game.Projectile.Launch(70f, 5f, game.Player1.PlayerPosition);
            for (int i = 0; i < 70; i++)            
            {               
                foreach (IUpdateable item in Game.updateable)
                {
                    item.Display();

                    if (item is Ball proj)
                    {
                        proj.Update();
                    }
                }
                System.Threading.Thread.Sleep(50);

            }
            Console.WriteLine();
        }
    }
}
