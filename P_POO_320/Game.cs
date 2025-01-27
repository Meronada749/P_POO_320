using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_POO_320
{
    internal class Game
    {
        public People Player1 = new People(x:3, y:37);
        public People Player2 = new People(x:60, y:37);
        public Tower Tower1 = new Tower(height:5, width:5, x:10, y:35);
        public Tower Tower2 = new Tower(height:5, width:5, x:50, y:35);
        public static List<IUpdateable> updateable = new List<IUpdateable>();
    }
}
