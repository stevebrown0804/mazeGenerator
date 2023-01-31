using mazeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGenerator
{
    class Maze_ListOfLists : IMaze
    {
        public CellsAndWalls? cellsAndWalls;

        public List<List<Cell>> cells;
        public List<List<Wall>> walls;

        public int rows = 0;
        public int cols = 0;


        internal Maze_ListOfLists(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;

            cells = new List<List<Cell>>();

            //Create the data structute that'll hold the cells
            for (int i = 0; i < cols; i++)
            {
                List<Cell> col = new();
                cells.Add(col);
                Console.WriteLine($"cells: Column {i} added");
            }

            //...then populate it with cells
            for (int j = 0; j < rows; j++)
                for (int i = 0; i < cols; i++)
                {
                    Cell cell = new Cell(j, i);
                    //cells[j][i] = cell;
                    cells[j].Add(cell);
                    Console.WriteLine($"Cell r{j}c{i} added to cells");
                }


            //TMP - dumping the data (the check the order)
            /*for (int j = 0; j < rows; j++)
                for (int i = 0; i < cols; i++)
                {
                    Console.WriteLine($"cell: {cells[j][i].x}, {cells[j][i].y} exists");
                }*/

            //next up, create the walls
            //DESIGN CHOICE: walls are to the right of and below cells

            //Again, first we'll create the data structure
            walls = new List<List<Wall>>();
            for (int i = 0; i < cols; i++)
            {
                List<Wall> col = new();
                walls.Add(col);
                Console.WriteLine($"walls: Column {i} added");
            }

            //...then populate it with walls
            for (int j = 0; j < rows; j++)
                for (int i = 0; i < cols; i++)
                {
                    if (i != cols - 1 & j != rows - 1)
                    {
                        //Console.WriteLine($"({i},{j}): j != rows - 1 & i != cols - 1");  //TMP

                        //Add both a horizatal and vertical wall
                        Wall wall_vertical = new Wall(j, i, Wall.WallDirection.vertical);
                        walls[i].Add(wall_vertical);
                        Console.WriteLine($"Wall (r{j}c{i}, {Wall.WallDirection.vertical}) added to walls");

                        Wall wall_horizontal = new Wall(j, i, Wall.WallDirection.horizontal);
                        walls[i].Add(wall_horizontal);
                        Console.WriteLine($"Wall (r{i}c{i}, {Wall.WallDirection.horizontal}) added to walls");
                    }
                    else if (i != cols - 1 & j == rows - 1)
                    {
                        //Console.WriteLine($"({j},{i}):j == rows - 1 & i != cols - 1");  //TMP

                        //Add a horizontal wall but no vertical wall
                        Wall wall_horizontal = new Wall(j, j, Wall.WallDirection.horizontal);
                        walls[i].Add(wall_horizontal);
                        Console.WriteLine($"Wall (r{j}c{i}, {Wall.WallDirection.horizontal}) added to walls");
                    }
                    else if (i == cols - 1 & j != rows - 1)
                    {
                        //Console.WriteLine($"({j},{i}):j != rows - 1 & i == cols - 1");  //TMP

                        //Add a vertical wall but no horizontal wall
                        Wall wall_vertical = new Wall(j, i, Wall.WallDirection.vertical);
                        walls[i].Add(wall_vertical);
                        Console.WriteLine($"Wall (r{j}c{i}, {Wall.WallDirection.vertical}) added to walls");

                    }
                    else if (i == cols - 1 & j == rows - 1)
                    {
                        /*Console.WriteLine($"({i},{j}):j == rows - 1 & i == cols - 1");  //TMP
                        Console.WriteLine("(No Walls forthcoming!)");*/
                        //Don't add either
                    }

                }//END for (inner)
                 //END for (outer)

        }//END Maze_ListOfLists(int rows, int cols) (constructor)

        public IMaze CreateMaze(IMazeCreation mazeCreator)
        {
            throw new NotImplementedException();
        }

        public IMaze GenerateMaze()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, CellsAndWalls> GetDict()
        {
            throw new NotImplementedException();
        }

        public (int, int) GetRowsAndColumns()
        {
            throw new NotImplementedException();
        }

        public void Render(IMazeRenderer renderer)
        {
            throw new NotImplementedException();
        }

        internal void RenderMazeToConsole()
        {
            Console.WriteLine("\nRendering maze...\n");

            List<List<Cell>> cells = this.cells;
            List<List<Wall>> walls = this.walls;

            //TMP
            /*int cellCount = 0;
            int wallCount = 0;
            for (int i = 0; i < cells.Count; i++)
                cellCount += cells[i].Count;
            for (int i = 0; i < walls.Count; i++)
                wallCount += walls[i].Count;
            Console.WriteLine($"Number of cells: {cellCount}; Number of walls: {wallCount}");*/
            //END TMP

            //string four_sp = "    ";

            //Ok, let's see here...
            for (int i = 0; i < this.rows; /*.cols?*/ i++)                               //RESUME HERE
            {
                for (int j = 0; j < this.cols; j++)
                {
                    Console.Write(" * ");  //cell

                    if (walls[i][j].direction == Wall.WallDirection.vertical)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
                for (int j = 0; j < this.cols; j++)
                {

                    if (walls[i][j].direction == Wall.WallDirection.horizontal)
                    {
                        Console.Write(" __ ");
                    }
                }
                Console.WriteLine();
            }

        }//END RenderMazeToConsole()

    }//END Maze_ListOfLists (class)

}//END (namespace)
