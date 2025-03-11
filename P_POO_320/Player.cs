/// ETML
/// Author: Meron Essayas
/// Date: 17.01.2025

using System;
using System.Numerics;

namespace P_POO_320
{
    /// <summary>
    /// The Player class that represents the players in the game.
    /// </summary>
    internal sealed class Player : IUpdateable
    {
        /// <summary>
        /// field to store the player's position as a Vector2.
        /// </summary>
        private Vector2 _playerposition;

        /// <summary>
        /// property to get or set the player's position, exposes the private field _playerposition for external access and modification.
        /// </summary>
        public Vector2 PlayerPosition
        {
            get { return _playerposition; }
            set { _playerposition = value; }
        }

        /// <summary>
        /// player's color
        /// </summary>
        public ConsoleColor PlayerColor { get; set; }

        /// <summary>
        /// The drawing that represents the player using a simple ASCII art representation.
        /// Ce tableau de chaînes représente le joueur avec un dessin en ASCII.
        /// </summary>
        public string[] Person { get; set; } =
        {
            // The head of the player (represented as "O").
            @" O ",
    
            // The body and arms of the player (represented as "/|\\").
            @"/|\",
    
            // The legs of the player (represented as "/ \\").
            @"/ \"
        };

        /// <summary>
        /// Constructor for creating a new Player object.
        /// Initializes the player's position and color, and adds the player to the updateable list.
        /// </summary>
        /// <param name="x">The X position of the player on the screen.</param>
        /// <param name="y">The Y position of the player on the screen.</param>
        /// <param name="PlayerColor">The color of the player, used for displaying the player.</param>
        public Player(int x, int y, ConsoleColor PlayerColor)
        {
            // Initialize the player's position using the given X and Y coordinates.
            PlayerPosition = new Vector2(x, y);

            // Set the player's color.
            this.PlayerColor = PlayerColor;

            // Add the player to the updateable list in the Game class.
            Game.updateable.Add(this);
        }

        /// <summary>
        /// Displays the player's information at the position specified by PlayerPosition.
        /// The PlayerPosition defines where on the console the player's info will be shown.
        /// </summary>
        public void Display()
        {
            // Set the cursor to the player's position on the console.
            Console.SetCursorPosition((int)PlayerPosition.X, (int)PlayerPosition.Y);

            // Loop through each string in the Person collection and display it.
            foreach (string item in Person)
            {
                // Reset cursor to the player's X position and current Y position
                Console.SetCursorPosition((int)PlayerPosition.X, Console.CursorTop);

                // Set the text color for the player's display.
                Console.ForegroundColor = PlayerColor;

                // Write the current item in the Person collection to the console.
                Console.WriteLine(item);

                // Reset the console text color back to default.
                Console.ResetColor();
            }
        }
    }
}
