/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/


namespace mazeGenerator
{
    internal interface IMaze
    {
        IMaze CreateMaze(IMazeCreation mazeCreator);

        void Render(IMazeRenderer renderer);

        Dictionary<string, CellsAndWalls> GetDict();

        (int, int) GetRowsAndColumns();
    }
}
