/*  Create an empty queue and enqueue the source cell having a distance 0 from the source (itself) and mark it as visited.
    Loop till queue is empty.
        Dequeue the front node.
        If the popped node is the destination node, then return its distance.
        Otherwise, for each of four adjacent cells of the current cell, enqueue each valid cell with +1 distance and mark them as visited.
    If all the queue nodes are processed, and the destination is not reached, then return false.*/

namespace mazeGenerator
{
    internal class MazeSolver : IMazeSolver
    {
        public IMazeSolver Solve(IMazeStorage maze, Player player)
        {
            //We'll want to find the shortest path from wherever the player current is, to the end
            //  We'll define "end" is lower-right corner.  TODO, maybe: implement another fn for to "solveFromPlayer?"  TBD

            Dictionary<string, CellsAndWalls> dict = maze.GetDict();
            Dictionary<string, bool> visited = new();
            int theNodesDistance = 0;

            //Initialize the 'visited' dictionary to false
            foreach (var k in dict.Keys)
                visited[k] = false;

            Console.WriteLine("In progress: MazeSolver.Solve()\n");
            //
            // "Create an empty queue and enqueue the source cell having a distance 0 from the source (itself) and mark it as visited."
            //
            Queue<CellsAndWalls> q = new();

            string str_Start = $"r{player.startingPoint.row}c{player.startingPoint.col}";
            q.Enqueue(dict[str_Start]);
            visited[str_Start] = true;

            //
            // "Loop till queue is empty."
            //
            while(q.Count > 0)
            {
                //
                // "Dequeue the front node."
                //
                CellsAndWalls theNode = q.Dequeue();
                player.position.row = theNode.cell.row; //Assuming we should update's player's position
                player.position.col = theNode.cell.col;
                
                //
                // "If the popped node is the destination node, then return its distance."
                //
                if(theNode.cell.row == player.goal.row & theNode.cell.col == player.goal.col)
                {
                    theNodesDistance = theNode.distance;
                    break;
                }
                else
                {
                    //
                    // "Otherwise, for each of four adjacent cells of the current cell, enqueue each valid cell with +1 distance and mark them as visited."
                    //
                    string str_up = $"r{theNode.cell.row - 1}c{theNode.cell.col}";
                    string str_down = $"r{theNode.cell.row + 1}c{theNode.cell.col}";
                    string str_left = $"r{theNode.cell.row}c{theNode.cell.col - 1}";
                    string str_right = $"r{theNode.cell.row}c{theNode.cell.col + 1}";

                    if (dict.ContainsKey(str_up))
                    {
                        dict[str_up].distance += 1;
                        q.Enqueue(dict[str_up]);
                        visited[str_up] = true;
                    }
                    if (dict.ContainsKey(str_down))
                    {
                        dict[str_down].distance += 1;
                        q.Enqueue(dict[str_down]);
                        visited[str_down] = true;
                    }
                    if (dict.ContainsKey(str_left))
                    {
                        dict[str_left].distance += 1;
                        q.Enqueue(dict[str_left]);
                        visited[str_left] = true;
                    }
                    if (dict.ContainsKey(str_right))
                    {
                        dict[str_right].distance += 1;
                        q.Enqueue(dict[str_right]);
                        visited[str_right] = true;
                    }
                }//END if/else

            }//END while(q.Count > 0)

            //
            // "If all the queue nodes are processed, and the destination is not reached, then return false."
            //
            if (player.position.row != player.goal.row || player.position.col != player.goal.col)
            {
                theNodesDistance = -1;
            }


            //Wrap-up
            if (theNodesDistance == -1)
            {
                Console.WriteLine("MazeSolver.Solve says: theNodesDistance was -1. :(\n");
            }
            else
            {
                //Everything's fine....right?  TBD
                Console.WriteLine($"MazeSolver.Solve says: theNodesDistance was equal to {theNodesDistance}.\n");
            }

            int visitedTrueCounter = 0;
            foreach (var k in visited.Keys)
            {
                if (visited[k] == true)
                    visitedTrueCounter++;
            }
            Console.WriteLine($"Visited.Count == true: {visitedTrueCounter}\n");

            //So...what exactly do we do with theNodesDistance?  TBD

            return this;
        }
    }
}
