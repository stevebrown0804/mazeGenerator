namespace mazeGenerator
{
    internal class CellsAndWalls
    {
        public Cell cell;

        //RECALL THE DESIGN CHOICE: Walls are to the right of and below cells
        public Wall? wallBelow;
        public Wall? wallToTheRight;

        public int distance;    //Adding this for the shortest-path algorithm

        public CellsAndWalls(Cell cell, Wall? wallBelow, Wall? wallToTheRight)
        {
            this.cell = cell;
            this.wallBelow = wallBelow;
            this.wallToTheRight = wallToTheRight;
            distance = 0;   //REMINDER: recently added
        }
    }
}
