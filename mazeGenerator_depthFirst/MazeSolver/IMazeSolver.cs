namespace mazeGenerator
{
    internal interface IMazeSolver
    {
        IMazeStorage Solve(IMazeStorage maze);
    }
}
