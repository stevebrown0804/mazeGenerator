﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGenerator
{
    internal class RenderDictionaryToConsole : IMazeRenderer
    {
        public void Render(IMaze maze)
        {
            Dictionary<string, CellsAndWalls> dict = maze.GetDict();
            (int rows, int cols) = maze.GetRowsAndColumns();

             for (int i = 1; i <= rows; i++)
            {
                for( int j = 1; j <= cols; j++)
                {
                    string str = $"r{i}c{j}";
                    if(dict[str].cell != null)
                        Console.Write("  *  ");
                    if (dict[str].wallToTheRight != null)
                        Console.Write("|");

                }
                Console.WriteLine();
                for (int j = 1; j <= cols; j++)
                {
                    string str = $"r{i}c{j}";
                    if (dict[str].wallBelow != null)
                        Console.Write(" ___  ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
