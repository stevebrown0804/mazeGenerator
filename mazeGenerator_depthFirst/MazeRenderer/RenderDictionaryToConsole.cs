namespace mazeGenerator
{
    internal class RenderDictionaryToConsole : IMazeRenderer
    {
        public void Render(IMazeStorage maze)
        {
            Dictionary<string, CellsAndWalls> dict = maze.GetDict();
            (int rows, int cols) = maze.GetRowsAndColumns();

             for (int i = 1; i <= rows; i++)
            {
                for( int j = 1; j <= cols; j++)
                {
                    string str = $"r{i}c{j}";
                    if(dict[str].cell != null)
                        Console.Write("  *  ");
                    if (dict[str].wallToTheRight != null)
                        Console.Write("|");
                    else
                        Console.Write(" ");

                }
                Console.WriteLine();
                for (int j = 1; j <= cols; j++)
                {
                    string str = $"r{i}c{j}";
                    if (dict[str].wallBelow != null)
                        Console.Write(" ___  ");
                    else
                        Console.Write("      ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
