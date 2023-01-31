using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGenerator
{
    internal class CellsAndWalls
    {
        public Cell cell;
        public Wall wallBelow;
        public Wall wallToTheRight;

        public CellsAndWalls(Cell cell, Wall wallBelow, Wall wallToTheRight)
        {
            this.cell = cell;
            this.wallBelow = wallBelow;
            this.wallToTheRight = wallToTheRight;
        }
    }
}
