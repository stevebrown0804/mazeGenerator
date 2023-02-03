namespace mazeGenerator
{
    internal interface IMazeStorage
    {
        IMazeStorage CreateMaze(IMazeCreation mazeCreator);

        void Render(IMazeRenderer renderer);

        Dictionary<string, CellsAndWalls> GetDict();

        (int, int) GetRowsAndColumns();
    }
}
