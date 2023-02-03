namespace mazeGenerator
{
    internal interface IMaze
    {
        IMaze CreateMaze(IMazeCreation mazeCreator);

        void Render(IMazeRenderer renderer);

        Dictionary<string, CellsAndWalls> GetDict();

        (int, int) GetRowsAndColumns();
    }
}
