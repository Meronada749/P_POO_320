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

            string window = "The window width is {0}, and the height is {1}.";
            // Step 1: Set the window to 150x40.
            Console.SetWindowSize(150, 40);
            Console.WriteLine(window, Console.WindowWidth, Console.WindowHeight);


            People people1 = new People(5,5);
            Console.SetCursorPosition((int)people1.Position.X, (int)people1.Position.Y);
            foreach (string s in people1.Person)
            {
                Console.SetCursorPosition((int)people1.Position.X, Console.CursorTop);
                Console.WriteLine(s);
            }

            People people2 = new People(100,5);
            Console.SetCursorPosition((int)people2.Position.X,(int)people2.Position.Y);
            foreach (string s in people2.Person)
            {
                Console.SetCursorPosition((int)people2.Position.X, Console.CursorTop);
                Console.WriteLine(s);
            }


        }
    }
}
