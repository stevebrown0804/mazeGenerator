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
            //  We'll define "end" is lower-right corner

            Dictionary<string, CellsAndWalls> dict = maze.GetDict();

            Queue<CellsAndWalls> queue = new();

            //TODO: implement!

            Console.WriteLine("In progress: MazeSolver.Solve()\n");
            return this;
        }
    }
}
