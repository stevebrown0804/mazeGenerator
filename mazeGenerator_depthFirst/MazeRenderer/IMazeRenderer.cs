﻿namespace mazeGenerator
{
    internal interface IMazeRenderer
    {
        void Render(IMazeStorage maze, IMazeSolver? solver = null);
    }
}
