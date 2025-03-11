/// ETML
/// Author: Meron Essayas
/// Date: 17.01.2025

using System;
using System.Numerics;

namespace P_POO_320
{
    /// <summary>
    /// Ball class representing a ball object in the game.
    /// </summary>
    internal sealed class Ball : IUpdateable, IDamageable
    {
        /// <summary>
        /// Field to store the ball's position as a Vector2.
        /// </summary>
        private Vector2 _ballposition;

        /// <summary>
        /// Property to get or set the ball's position, exposes the private field _ballposition for external access and modification.
        /// </summary>
        public Vector2 BallPosition
        {
            get { return _ballposition; }
            set { _ballposition = value; }
        }

        /// <summary>
        /// The last recorded position of the ball (nullable to indicate if it has no previous position).
        /// </summary>
        public Vector2? LastBallPosition; // Nullable

        /// <summary>
        /// The velocity of the ball (X and Y components of the velocity).
        /// </summary>
        public Vector2 Velocity;

        /// <summary>
        /// Constant value for the friction applied to the ball's velocity.
        /// </summary>
        private const float TIME_STEP = 0.1f;

        /// <summary>
        /// Constant value for gravity applied to the ball (affects the vertical velocity).
        /// </summary>
        private const float GRAVITY = 0.5f;

        /// <summary>
        /// Constant character used to represent the ball on the screen.
        /// </summary>
        private const char BALL_FORM = '●';

        /// <summary>
        /// Property indicating whether the ball is destroyed (used for collision detection).
        /// </summary>
        public bool IsDestroyed { get; set; }

        /// <summary>
        /// Constructor for creating a new ball object.
        /// Initializes the ball's position, velocity, and state.
        /// </summary>
        public Ball()
        {
            BallPosition = new Vector2 (3, 27);
            Velocity = Vector2.Zero;
            LastBallPosition = null;

            // Adds the ball to the updateable list in the game.
            Game.updateable.Add(this);
        }

        /// <summary>
        /// Displays the ball at its current position on the screen.
        /// Clears the previous position of the ball before updating the display.
        /// </summary>
        public void Display()
        {
            if (!IsDestroyed)
            {
                // Clear the ball's previous position if it exists.
                if (LastBallPosition.HasValue)
                {
                    Console.SetCursorPosition((int)LastBallPosition.Value.X, (int)LastBallPosition.Value.Y);
                    Console.Write(' ');
                }

                // Set the cursor position to the ball's current position and display it.
                Console.SetCursorPosition((int)BallPosition.X, (int)BallPosition.Y);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(BALL_FORM);
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Launches the ball with a specific angle, force, and starting position.
        /// </summary>
        /// <param name="angle">The angle at which the ball is launched (in degrees).</param>
        /// <param name="force">The force applied to the ball, determining the initial velocity.</param>
        /// <param name="startPosition">The starting position of the ball.</param>
        public void LaunchBall(float angle, float force, Vector2 startPosition)
        {
            BallPosition = startPosition;
            LastBallPosition = null;

            // Convert angle to radians for velocity calculations.
            float radians = (float)(Math.PI * angle / 180f);

            // Set the velocity of the ball using trigonometric functions.
            Velocity = new Vector2(
                (float)(force * Math.Cos(radians)),
                (float)(-force * Math.Sin(radians))
            );
        }

        /// <summary>
        /// Updates the ball's position based on its velocity and applies gravity and time_step.
        /// </summary>
        public void UpdateBallPosition()
        {
            // Save the current position before updating.
            LastBallPosition = BallPosition;

            // Update the ball's position based on its velocity, considering friction.
            BallPosition += Velocity * TIME_STEP;

            // Apply gravity to the vertical component of the velocity.
            Velocity = new Vector2(Velocity.X, Velocity.Y + GRAVITY * TIME_STEP);
        }

        /// <summary>
        /// Handles the spacebar press event for launching the ball.
        /// It checks for collision with the tower and updates the ball's position.
        /// </summary>
        /// <param name="currentPlayer">The player who is launching the ball.</param>
        /// <param name="Tower">The tower that the ball can collide with.</param>
        public void PressSpaceBar(Player currentPlayer, Tower Tower)
        {
            bool isBallLaunched = false;

            // Game loop to handle ball launch and collision detection.
            while (!IsDestroyed)
            {
                // Check for collision between the ball and each cell of the tower.
                for (int i = 0; i < Tower.Width; i++)
                {
                    for (int j = 0; j < Tower.Height; j++)
                    {
                        // Check if the ball's position matches a cell in the tower.
                        if (Convert.ToInt32(BallPosition.X) == Convert.ToInt32(Tower.TowerPosition.X) + i && Convert.ToInt32(BallPosition.Y) == Convert.ToInt32(Tower.TowerPosition.Y) + j)
                        {
                            IsDestroyed = true;
                            // Destroy the corresponding block in the tower and update its display.
                            Tower.DestroyBlock((int)(BallPosition.X - Tower.TowerPosition.X), (int)(BallPosition.Y - Tower.TowerPosition.Y));
                            Destroy();
                            Tower.Display();
                        }
                        // If the ball is destroyed, break out of the loop.
                        if (IsDestroyed)
                        {
                            break;
                        }
                    }

                    // Break out of the outer loop if the ball is destroyed.
                    if (IsDestroyed)
                    {
                        break;
                    }
                }

                // Display the ball's updated position on the screen.
                if (!IsDestroyed)
                {
                    Display();
                }
                

                // Detect spacebar press to launch the ball.
                if (!isBallLaunched && Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        LaunchBall(angle: 55f, force: 5f, startPosition: currentPlayer.PlayerPosition);
                        isBallLaunched = true;
                    }
                }

                // End the loop if the ball goes out of bounds.
                if (BallPosition.X < 0 || (int)BallPosition.Y >= Game.GroundPosition.Y)
                {
                    break;
                }

                // If the ball is launched, update its position.
                if (isBallLaunched)
                {
                    UpdateBallPosition();
                }

                // Add a small delay to control the frame rate.
                System.Threading.Thread.Sleep(50);
            }
        }

        /// <summary>
        /// Destroys the ball by marking it as destroyed and clearing its position on the screen.
        /// </summary>
        public void Destroy()
        {
            IsDestroyed = true;
            Console.SetCursorPosition((int)BallPosition.X, (int)BallPosition.Y);
            Console.Write(' ');
        }
    }
}
