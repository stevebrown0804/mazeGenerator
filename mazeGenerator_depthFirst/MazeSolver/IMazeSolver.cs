namespace mazeGenerator
{
    internal interface IMazeSolver
    {
        IMazeSolver Solve(IMazeStorage maze, Player player);
    }
}
