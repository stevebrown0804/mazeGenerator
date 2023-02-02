using mazeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGenerator
{
    internal class Prims : IMazeCreation
    {
        public IMaze CreateMaze(IMaze maze)
        {
            Console.WriteLine("In progress: Prim's algorithm");  //TMP

            (int rows, int cols) = maze.GetRowsAndColumns();
            Dictionary<string, CellsAndWalls> mazeDict = maze.GetDict();




            //throw new NotImplementedException();
            return maze;  //TMP
        }
    }
}
