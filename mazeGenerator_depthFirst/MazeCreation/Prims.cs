/*using mazeGenerator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;*/

namespace mazeGenerator
{
    internal class Prims : IMazeCreation
    {

        /*This algorithm is a randomized version of Prim's algorithm.

        Start with a grid full of walls.
        Pick a cell, mark it as part of the maze.Add the walls of the cell to the wall list.
        While there are walls in the list:
            Pick a random wall from the list.If only one of the cells that the wall divides is visited, then:
                Make the wall a passage and mark the unvisited cell as part of the maze.
                Add the neighboring walls of the cell to the wall list.
            Remove the wall from the list.


        Note that simply running classical Prim's on a graph with random edge weights would create mazes stylistically identical to Kruskal's, because they are both minimal spanning tree algorithms. Instead, this algorithm introduces stylistic variation because the edges closer to the starting point have a lower effective weight.

        Modified version
        Although the classical Prim's algorithm keeps a list of edges, for maze generation we could instead maintain a list of adjacent cells. If the randomly chosen cell has multiple edges that connect it to the existing  maze, select one of these edges at random. This will tend to branch slightly more than the edge-based     version above.*/

        bool CheckThatOnlyOneCellThatTheWallDividesHasBeenVisited(Wall wall, 
                                                                  Dictionary<string, CellsAndWalls> dict,
                                                                  Dictionary<string, bool> visit)
        { 
            string str_up = $"r{wall.row - 1}c{wall.col}";
            string str_down = $"r{wall.row + 1}c{wall.col}";
            string str_left = $"r{wall.row}c{wall.col - 1}";
            string str_right = $"r{wall.row}c{wall.col + 1}";

            int cellCounter = 0;
            if (dict.ContainsKey(str_up))
            {   //...and has been visited
                if (visit[str_up])
                    cellCounter++;
            }
            if (dict.ContainsKey(str_down))
            {
                if (visit[str_down])
                    cellCounter++;
            }
            if (dict.ContainsKey(str_left))
            {
                if (visit[str_left])
                    cellCounter++;
            }
            if (dict.ContainsKey(str_right))
            {
                if (visit[str_right])
                    cellCounter++;
            }

            return cellCounter == 1;
        }

        public IMaze CreateMaze(IMaze maze)
        {
            Console.WriteLine("In progress: Prim's algorithm\n");  //TMP

            /*Start with a grid full of walls.
            Pick a cell, mark it as part of the maze. Add the walls of the cell to the wall list.
            While there are walls in the list:
                Pick a random wall from the list. If only one of the cells that the wall divides is visited, then:
                    Make the wall a passage and mark the unvisited cell as part of the maze.
                    Add the neighboring walls of the cell to the wall list.
                Remove the wall from the list.*/

            (int rows, int cols) = maze.GetRowsAndColumns();
            Dictionary<string, CellsAndWalls> mazeDict = maze.GetDict();

            //List<CellsAndWalls> walls = new();
            List<Wall> walls = new();
            //Dictionary<string, CellsAndWalls> newMaze = new();
            Dictionary<string, bool> visited = new();

            //Initialize the 'visited' dictionary to false
            foreach (var k in mazeDict.Keys)
            {
                visited[k] = false;
            }

            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int starting_row = rnd.Next(1, rows + 1);
            int starting_col = rnd.Next(1, cols + 1);
            string str = $"r{starting_row}c{starting_col}";

            // "Pick a cell, mark it as part of the maze..."
            //newMaze[str] = mazeDict[str];
            visited[str] = true;

            //"... and add the walls of the cell to the wall list."
            if (mazeDict[str].wallBelow != null)
                walls.Add(mazeDict[str].wallBelow);
            
            if (mazeDict[str].wallToTheRight != null)
                walls.Add(mazeDict[str].wallToTheRight);

            //  Add the below wall from the cell above this one (if it exists)
            string str_up = $"r{mazeDict[str].cell.row - 1}c{mazeDict[str].cell.col}";  //Below
            if (mazeDict.ContainsKey(str_up))
                if(mazeDict[str_up].wallBelow != null)
                    walls.Add(mazeDict[str_up].wallBelow);

            //  Add the ToTheRight wall from the cell to the left of this one (if it exists)
            string str_left = $"r{mazeDict[str].cell.row}c{mazeDict[str].cell.col - 1}"; //ToTheRight
            if (mazeDict.ContainsKey(str_left))
                if (mazeDict[str_left].wallToTheRight != null)
                    walls.Add(mazeDict[str_left].wallToTheRight);


            // "While there are walls in the list:"
            while (walls.Count > 0)
            {
                // "Pick a random wall from the list."
                int rnd_wall = rnd.Next(0, walls.Count);  //TODO: Move "str_theWall" up here

                bool isOnlyOneVisited = false;
                Wall theWall = null;

                theWall = walls[rnd_wall];
                if (theWall == null)
                    throw new Exception("Prims.CreateMaze says: theWall is null (just after declaration & assignment)");

                isOnlyOneVisited = CheckThatOnlyOneCellThatTheWallDividesHasBeenVisited(theWall, mazeDict, visited);
                    //getting a "theWall is null" exception inside this^ function.
                    //is rnd_wall generating numbers that are beyond the range of walls?
                    //  ...or is walls getting nulls put into it?  TBD


                //"If only one of the cells that the wall divides is visited, then:"
                if (isOnlyOneVisited)
                {
                    //"Make the wall a passage and mark the unvisited cell as part of the maze."
                    string str_theWall = $"r{theWall.row}c{theWall.col}";

                    if (theWall.direction == Wall.WallDirection.horizontal)
                        mazeDict[str_theWall].wallBelow = null;
                    else if (theWall.direction == Wall.WallDirection.vertical)
                        mazeDict[str_theWall].wallToTheRight = null;
                    else
                        throw new Exception("Prims.CreateMaze says: theWall is in an unrecognized direction");

                    
                    visited[str_theWall] = true;        //are we sure this is the correct cell to be marking? TBD


                    //"Add the neighboring walls of the cell to the wall list."
                    if (mazeDict[str_theWall].wallBelow != null)        //should str be str_theWall here?  TBD
                        walls.Add(mazeDict[str_theWall].wallBelow);

                    if (mazeDict[str_theWall].wallToTheRight != null)
                        walls.Add(mazeDict[str_theWall].wallToTheRight);

                    str_up = $"r{mazeDict[str_theWall].cell.row - 1}c{mazeDict[str_theWall].cell.col}";  //Below
                    if (mazeDict.ContainsKey(str_up))
                        if (mazeDict[str_up].wallBelow != null)
                            walls.Add(mazeDict[str_up].wallBelow);

                    str_left = $"r{mazeDict[str_theWall].cell.row}c{mazeDict[str_theWall].cell.col - 1}"; //ToTheRight
                    if (mazeDict.ContainsKey(str_left))
                        if (mazeDict[str_left].wallToTheRight != null)
                            walls.Add(mazeDict[str_left].wallToTheRight);
                
                }//END if (isOnlyOneVisited)

                // Remove the wall (theWall) from the list
                if (theWall == null)
                    throw new Exception("Prims.CreateMaze says: theWall is null");

                walls.Remove(theWall);
            
            }//END while (walls.Count > 0)

            //TMP
            int visitedTrueCounter = 0;
            foreach (var k in visited.Keys)
            {
                if (visited[k] == true)
                    visitedTrueCounter++;
            }
            Console.WriteLine($"Visited.Count == true: {visitedTrueCounter}\n");  
            //END TMP

            return new Maze_Dictionary(rows, cols, mazeDict); //newMaze);
        
        }//END CreateMaze()
    }
}
