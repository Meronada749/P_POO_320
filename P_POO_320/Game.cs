///ETML
///Auteur : Meron Essayas
///Date : 17.01.2025
///Description: 

using System.Collections.Generic;
using System.Numerics;

namespace P_POO_320
{
    internal class Game
    {
        public static Vector2 GroundPosition { get; private set; } = new Vector2(x: 0, y: 40);
        public Player Player1 = new Player(x:3, y:37, PlayerColor:System.ConsoleColor.Red);
        public Player Player2 = new Player(x:60, y:37, PlayerColor:System.ConsoleColor.Magenta);
        public Tower Tower1 = new Tower(height:5, width:5, x:10, y:40);
        public Tower Tower2 = new Tower(height:5, width:5, x:50, y:40);
        public Ball Ball = new Ball();
        public static List<IUpdateable> updateable = new List<IUpdateable>();
    }
}
