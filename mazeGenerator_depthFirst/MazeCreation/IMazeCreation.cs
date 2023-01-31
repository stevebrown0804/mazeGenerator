using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Frequently implemented with a stack, this approach is one of the simplest 
 * ways to generate a cells using a computer. Consider the space for a cells 
 * being a large grid of cells (like a large chess board), each cell starting 
 * with four walls. Starting from a random cell, the computer then selects a 
 * random neighbouring cell that has not yet been visited. The computer 
 * removes the wall between the two cells and marks the new cell as visited, 
 * and adds it to the stack to facilitate backtracking. The computer continues 
 * this process, with a cell that has no unvisited neighbours being considered 
 * a dead-end. When at a dead-end it backtracks through the path until it 
 * reaches a cell with an unvisited neighbour, continuing the path generation 
 * by visiting this new, unvisited cell(creating a new junction). This process 
 * continues until every cell has been visited, causing the computer to 
 * backtrack all the way back to the beginning cell. We can be sure every cell 
 * is visited.*/

/*As given above this algorithm involves deep recursion which may cause stack 
 * overflow issues on some computer architectures. The algorithm can be 
 * rearranged into a loop by storing backtracking information in the cells 
 * itself. This also provides a quick way to display a solution, by starting 
 * at any given point and backtracking to the beginning.*/

/*Recursive implementation
The depth-first search algorithm of cells generation is frequently implemented 
using backtracking. This can be described with a following recursive routine:

    Given a current cell as a parameter
    Mark the current cell as visited
    While the current cell has any unvisited neighbour cells
        Choose one of the unvisited neighbours
        Remove the wall between the current cell and the chosen cell
        Invoke the routine recursively for the chosen cell which is invoked 
         once for any initial cell in the area.
*/


/*Iterative implementation
A disadvantage of the first approach is a large depth of recursion – in the 
worst case, the routine may need to recur on every cell of the area being 
processed, which may exceed the maximum recursion stack depth in many 
environments. As a solution, the same backtracking method can be implemented 
with an explicit stack, which is usually allowed to grow much bigger with no 
harm.

    Choose the initial cell, mark it as visited and push it to the stack
    While the stack is not empty
        Pop a cell from the stack and make it a current cell
        If the current cell has any neighbours which have not been visited
            Push the current cell to the stack
            Choose one of the unvisited neighbours
            Remove the wall between the current cell and the chosen cell
            Mark the chosen cell as visited and push it to the stack
*/

namespace mazeGenerator
{
    internal interface IMazeCreation
    {
        IMaze CreateMaze(int rows, int cols);
    }
}
