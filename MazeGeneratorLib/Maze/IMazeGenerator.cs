using System.Collections.Generic;

namespace MazeGeneratorLib
{
    internal interface IMazeGenerator
    {

        /// <summary>
        /// Generates a random layout of rooms in a square grid, and selects start and treasure room indexes.
        /// </summary>
        /// <param name="size">Width and height of maze dimensions.</param>
        /// <returns>The grid of rooms, the start room index, the end (treasure) room index.</returns>
        (IRoom[], int, int) GenerateMaze(IRandomGenerator random, int gridsize);

        /// <summary>
        /// Given a grid size, select a start and end index at random. <br/>
        /// The start index falls along the grid's edge, and the end index is anywhere but the start index.
        /// </summary>
        /// <param name="gridsize">Width and height of grid dimensions.</param>
        /// <returns>The start and end indexes.</returns>
        (int, int) GetStartAndEndIndexes(IRandomGenerator random, int gridsize);

        /// <summary>
        /// Selects a random <see cref="RoomType"/> with a BehaviourThreshold of 1 (has no traps).
        /// </summary>
        /// <returns>A safe <see cref="RoomType"/>.</returns>
        RoomType GetRandomSafeRoomType(IRandomGenerator random);

        /// <summary>
        /// Given a grid size, return all indexes that fall on an edge of the grid.
        /// </summary>
        /// <param name="gridsize">Width and height of grid dimensions.</param>
        /// <returns>A list of indexes.</returns>
        List<int> GetGridEdgeIndexes(int gridsize);
    }
}