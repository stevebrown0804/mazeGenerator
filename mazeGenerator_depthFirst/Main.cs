/*using mazeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace mazeGenerator
{
    internal class MainClass
    {
        public static void Main()
        {
            Console.WriteLine("main: Maze_Dictionary -- depth-first -- iterative\n");  //TMP

            //First we'll create the starting point for the maze
            IMaze maze = new Maze_Dictionary(5, 5);

            //Next up, we'll create a maze using a specific routine            
            IMazeCreation mazeCreator = new DepthFirst_Iterative();
            maze = maze.CreateMaze(mazeCreator);

            //..and then render it
            IMazeRenderer renderTarget = new RenderDictionaryToConsole();
            //IMazeRenderer renderTarget = new RenderDictionaryToFile();
            maze.Render(renderTarget);
        }
    }
}
