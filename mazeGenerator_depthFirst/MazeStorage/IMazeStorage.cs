namespace mazeGenerator
{
    internal interface IMazeStorage
    {
        IMazeStorage CreateMaze(IMazeCreation mazeCreator);

        void Render(IMazeRenderer renderer, IMazeSolver? solver = null);

        Dictionary<string, CellsAndWalls> GetDict();

        (int, int) GetRowsAndColumns();
    }
}
