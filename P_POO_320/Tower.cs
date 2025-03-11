/// ETML
/// Author: Meron Essayas
/// Date: 17.01.2025

using System;
using System.Numerics;

namespace P_POO_320
{
    /// <summary>
    /// The Tower class that represents the towers in the game.
    /// </summary>
    internal sealed class Tower : IUpdateable
    {
        /// <summary>
        /// Private field to store the position of the tower.
        /// </summary>
        private Vector2 _towerposition;

        /// <summary>
        /// Public property to get or set the position of the tower.
        /// </summary>
        public Vector2 TowerPosition
        {
            get { return _towerposition; }
            set { _towerposition = value; }
        }

        /// <summary>
        /// The height of the tower.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The width of the tower.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Constant character representing the form of the tower (wall).
        /// </summary>
        private const char WALL_FORM = '●';

        /// <summary>
        /// 2D array representing the state of each cell in the tower (true means the cell is intact, false means it is destroyed).
        /// </summary>
        private bool[,] CellState;

        /// <summary>
        /// Constructor to create a new tower with specified height, width, and position.
        /// Initializes the tower's state as intact (all cells set to true).
        /// </summary>
        /// <param name="height">The height of the tower.</param>
        /// <param name="width">The width of the tower.</param>
        /// <param name="x">The X position of the tower.</param>
        /// <param name="y">The Y position of the tower.</param>
        public Tower(int height, int width, int x, int y)
        {
            Height = height;
            Width = width;
            _towerposition = new Vector2(x, y);

            // Initialize the CellState array to all true (indicating the tower is intact).
            CellState = new bool[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    CellState[i, j] = true;
                }
            }

            // Add this tower to the updateable objects in the game.
            Game.updateable.Add(this);
        }

        /// <summary>
        /// Displays the tower on the console.
        /// Each cell of the tower is represented by the WALL_FORM character if intact.
        /// </summary>
        public void Display()
        {
            // Set the cursor position to the tower's position.
            Console.SetCursorPosition((int)_towerposition.X, (int)_towerposition.Y);

            // Loop through each cell in the tower and display it.
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    // If the cell is intact, display the tower form; otherwise, display a space.
                    Console.Write(CellState[i, j] ? WALL_FORM.ToString() : " ");
                }

                // Move to the next line after displaying each row of the tower.
                Console.WriteLine();
                // Reset the cursor to the starting X position for the next row.
                Console.SetCursorPosition((int)_towerposition.X, Console.CursorTop);
            }
        }

        /// <summary>
        /// Destroys the specific cell of the tower at the given (x, y) position.
        /// </summary>
        /// <param name="x">The X coordinate of the cell to destroy.</param>
        /// <param name="y">The Y coordinate of the cell to destroy.</param>
        public void DestroyBlock(int x, int y)
        {
            // Ensure the (x, y) coordinates are within the bounds of the tower.
            if (x >= 0 && x < Width && y >= 0 && y < Height)
                CellState[y, x] = false; // Mark the block as destroyed (set to false).
        }
    }
}
