using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGenerator
{
    class Cell
    {
        //public int x, y;
        public int row, col;

         internal Cell(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
}
