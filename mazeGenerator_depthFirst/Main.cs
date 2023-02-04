namespace mazeGenerator
{
    internal class MainClass
    {
        public static void Main()
        {
            //Console.WriteLine("main: MazeStorage_Dictionary -- depth-first -- iterative\n");  //TMP
            Console.WriteLine("main: MazeStorage_Dictionary -- Prim's algorithm\n");

            //First we'll create the starting point for the maze
            IMazeStorage maze = new MazeStorage_Dictionary(15, 15);

            //Next up, we'll create a maze using a specific routine            
            //IMazeCreation mazeCreator = new DepthFirst_Iterative();
            IMazeCreation mazeCreator = new Prims();
            maze = maze.CreateMaze(mazeCreator);

            //We'll create a player object
            Player player = new (maze);
            Console.WriteLine($"Starting point: ({player.goal.startingPoint.row}, {player.goal.startingPoint.col})");
            Console.WriteLine($"Current player position: ({player.position.row}, {player.position.col})");
            Console.WriteLine($"Goal point: ({player.goal.endPoint.row}, {player.goal.endPoint.col})");

            //..and then render it
            IMazeRenderer renderTarget = new RenderDictionaryToConsole();
            //IMazeRenderer renderTarget = new RenderDictionaryToFile();
            maze.Render(renderTarget);
        }
    }
}
