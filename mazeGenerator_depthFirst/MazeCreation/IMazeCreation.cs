using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGenerator
{
    internal interface IMazeCreation
    {
        IMaze CreateMaze(int rows, int cols, IMaze maze);
    }
}
