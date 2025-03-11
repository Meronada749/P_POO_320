/// ETML
/// Author: Meron Essayas
/// Date: 17.01.2025

using System;
using System.Text;

namespace P_POO_320
{
    /// <summary>
    /// Main program that runs the ball game.
    /// </summary>
    internal sealed class Program
    {
        static void Main()
        {
            // Create a new instance of the Game class.
            Game game = new Game();

            // Set the console's output encoding to UTF-8 for proper character display.
            Console.OutputEncoding = Encoding.UTF8;

            // Set the console window size (150 columns and 40 rows).
            Console.SetWindowSize(150, 40);

            // Set the foreground color of the text in the console to green.
            Console.ForegroundColor = ConsoleColor.Green;

            // Hide the cursor while the game is running.
            Console.CursorVisible = false;

            // Set the initial position of the cursor to the ground level.
            Console.SetCursorPosition((int)Game.GroundPosition.X, (int)Game.GroundPosition.Y);

            // Print a separator line for the ground.
            Console.Write("-----------------------------------------------------------------");

            // Main game loop that continuously runs the game.
            while (true)
            {
                // Display all updateable objects (like players, towers, ball).
                foreach (IUpdateable item in Game.updateable)
                {
                    item.Display();
                }

                // Check if the spacebar is pressed and handle the ball's movement.
                game.Ball.PressSpaceBar(game.Player1, game.Tower2);

                // Redraw the screen after processing the ball's movement.
                foreach (IUpdateable item in Game.updateable)
                {
                    item.Display();
                }

                // Wait for the user to press Enter to continue to the next iteration of the game loop.
                // This can be removed for smoother gameplay if not required.
                Console.ReadLine();
            }
        }
    }
}
