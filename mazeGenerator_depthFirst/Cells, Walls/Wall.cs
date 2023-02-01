using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGenerator
{
    internal class Wall
    {
        //RECALL THE DESIGN CHOICE: Walls are to the right of and below cells
        // That is,the horizontal wall at maze[0][0] will be to the right the cell at maze[0][0]
        //  and the vertical wall at maze[0][0] will be below the cell at maze[0][0]

        public enum WallDirection
        {
            //unset,
            horizontal,
            vertical
        }

        public int x, y;
        public WallDirection direction;

        public Wall(int x, int y, WallDirection direction)
        {
            this.x = x; this.y = y;
            this.direction = direction;
        }
    }
}
