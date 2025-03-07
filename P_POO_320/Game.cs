/// <summary>
/// ETML
/// Author: Meron Essayas
/// Date: 17.01.2025
/// Description: The Game class that coordinates the entire game logic.
/// </summary>

using System.Collections.Generic;
using System.Numerics;

namespace P_POO_320
{
    internal class Game
    {
        /// <summary>
        /// The position of the ground (Y coordinate represents the ground level).
        /// This is where the ball or other objects will be considered to be on the ground.
        /// </summary>
        public static Vector2 GroundPosition { get; private set; } = new Vector2(x: 0, y: 30);

        /// <summary>
        /// The first player (Player1) with its initial position at (x: 5, y: 27) and the color Red.
        /// </summary>
        public Player Player1 = new Player(x: 05, y: 27, PlayerColor: System.ConsoleColor.Red);

        /// <summary>
        /// The second player (Player2) with its initial position at (x: 60, y: 27) and the color Magenta.
        /// </summary>
        public Player Player2 = new Player(x: 60, y: 27, PlayerColor: System.ConsoleColor.Magenta);

        /// <summary>
        /// The first tower (Tower1) with its position at (x: 15, y: 20), height 10, and width 5.
        /// </summary>
        public Tower Tower1 = new Tower(x: 15, y: 20, height: 10, width: 5);

        /// <summary>
        /// The second tower (Tower2) with its position at (x: 50, y: 20), height 10, and width 5.
        /// </summary>
        public Tower Tower2 = new Tower(x: 50, y: 20, height: 10, width: 5);

        /// <summary>
        /// The ball in the game, which can be launched, moved, and collide with objects.
        /// </summary>
        public Ball Ball = new Ball();

        /// <summary>
        /// A list of all objects that need to be updated during the game loop. This includes objects like the ball and towers.
        /// </summary>
        public static List<IUpdateable> updateable = new List<IUpdateable>();
    }
}
