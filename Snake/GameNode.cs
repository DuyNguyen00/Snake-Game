using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public enum GridData
    {
        Empty,
        SnakeHead,
        SnakeBody,
        SnakeFood
    }
    public class GameNode
    {
        /// <summary>
        /// y cord for this node
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// x cord for this node
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// information stored at this node
        /// </summary>
        public GridData Data { get; set; }

        /// <summary>
        /// represents a connection in the graph to another GameNode. Used to connect the 
        /// snake pieces on the GameBoard in subsequent order.
        /// </summary>
        public GameNode Edge { get; set; }

        /// <summary>
        /// default constructor that sets the x-y coordinate properties above.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public GameNode(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }


    }
}
