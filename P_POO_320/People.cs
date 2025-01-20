using System.Numerics;

namespace P_POO_320
{
    internal class People
    {
        //Properties
        public string Name { get; set; }
        public int Life { get; set; }
        public string[] Person {  get; set; } =
        {
            @" O ",
            @"/|\",
            @"/ \"
        };

        public Vector2 Position { get; set; }


        /*---------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Custom constructor
        /// </summary>
        public People(/*string Name, int Life*/ int x, int y)
        {
            //this.Name = Name;
            //this.Life = Life;
            Position = new Vector2(x,y); 
        }

    }
}
