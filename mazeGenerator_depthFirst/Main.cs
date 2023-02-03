
namespace mazeGenerator
{
    internal class MainClass
    {
        public static void Main()
        {
            //Console.WriteLine("main: Maze_Dictionary -- depth-first -- iterative\n");  //TMP
            Console.WriteLine("main: Maze_Dictionary -- Prim's algorithm\n");

            //First we'll create the starting point for the maze
            IMaze maze = new Maze_Dictionary(10, 10);

            //Next up, we'll create a maze using a specific routine            
            //IMazeCreation mazeCreator = new DepthFirst_Iterative();
            IMazeCreation mazeCreator = new Prims();
            maze = maze.CreateMaze(mazeCreator);

            //..and then render it
            IMazeRenderer renderTarget = new RenderDictionaryToConsole();
            //IMazeRenderer renderTarget = new RenderDictionaryToFile();
            maze.Render(renderTarget);
        }
    }
}
