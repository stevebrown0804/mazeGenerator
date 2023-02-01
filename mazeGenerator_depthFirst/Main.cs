﻿using mazeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGenerator
{
    internal class MainClass
    {
        public static void Main()
        {
            Console.WriteLine("main: Maze_Dictionary -- depth-first -- iterative\n");  //TMP

            //First we'll create the starting point for the maze
            IMaze maze = new Maze_Dictionary(15, 15);
            //maze = maze.GenerateMaze();

            //And render it, just to be sure
            /*IMazeRenderer renderToConsole = new RenderDictionaryToConsole();
            maze.Render(renderToConsole);*/

            //Next up, we'll create a maze using a specific routine            
            IMazeCreation depthFirst_Iterative = new DepthFirst_Iterative();
            maze = maze.CreateMaze(depthFirst_Iterative);

            //..and then render it
            IMazeRenderer renderToConsole = new RenderDictionaryToConsole();
            maze.Render(renderToConsole);
        }
    }
}
