namespace mazeGenerator
{
    internal class CellsAndWalls
    {
        public Cell cell;

        //RECALL THE DESIGN CHOICE: Walls are to the right of and below cells
        public Wall? wallBelow;
        public Wall? wallToTheRight;

        //public Cell? whoQueuedMe;    //Adding this for the shortest-path algorithm
                                    //FOLLOW-UP: But moving it to a dictinoary within the MazeSolver class

        public CellsAndWalls(Cell cell, Wall? wallBelow, Wall? wallToTheRight)
        {
            this.cell = cell;
            this.wallBelow = wallBelow;
            this.wallToTheRight = wallToTheRight;
            //whoQueuedMe = new Cell();
        }
    }
}
