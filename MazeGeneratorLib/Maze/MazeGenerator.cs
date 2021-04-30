﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MazeGeneratorLib
{
    static class MazeGenerator
    {

        /// <summary>
        /// Generates a random layout of rooms in a square grid, and selects start and treasure room indexes.
        /// </summary>
        /// <param name="size">Width and height of maze dimensions.</param>
        /// <returns>The grid of rooms, the start room index, the end (treasure) room index.</returns>
        internal static (IRoom[], int, int) GenerateMaze(IRandomGenerator random, int gridsize)
        {
            IRoom[] rooms = new IRoom[gridsize * gridsize];

            var (startIndex, endIndex) = GetStartAndEndIndexes(random, gridsize);
            rooms[startIndex] = RoomFactory.Create(GetRandomSafeRoomType(random)); 
            rooms[endIndex] = RoomFactory.Create(GetRandomSafeRoomType(random));

            // List of all roomtypes.
            RoomType[] roomTypes = (RoomType[])Enum.GetValues(typeof(RoomType));

            for (int i = 0; i < rooms.Length; i++)
            {
                if (i == startIndex || i == endIndex) continue;
                rooms[i] = RoomFactory.Create(roomTypes[random.Generate(0, roomTypes.Length)]); // Place a room of random type on the index.
            }

            return (rooms, startIndex, endIndex);
        }

        /// <summary>
        /// Given a grid size, select a start and end index at random. <br/>
        /// The start index falls along the grid's edge, and the end index is anywhere but the start index.
        /// </summary>
        /// <param name="gridsize">Width and height of grid dimensions.</param>
        /// <returns>The start and end indexes.</returns>
        internal static (int, int) GetStartAndEndIndexes(IRandomGenerator random, int gridsize)
        {
            List<int> edgeIndexes = GetGridEdgeIndexes(gridsize);
            int startIndex = edgeIndexes[random.Generate(0, edgeIndexes.Count)]; // Select a random index on the EDGE of the maze as the start room.
            int endIndex = random.Generate(0, gridsize * gridsize); // Select a random index anywhere in the maze as the end room.

            if (startIndex == endIndex)
            {
                endIndex = (endIndex + 1) % (gridsize * gridsize); // Move end index up by 1, with overflow protection
            }

            return (startIndex, endIndex);
        }

        /// <summary>
        /// Selects a random <see cref="RoomType"/> which has a BehaviourThreshold of 1 (has no traps).
        /// </summary>
        /// <returns>A safe <see cref="RoomType"/>.</returns>
        internal static RoomType GetRandomSafeRoomType(IRandomGenerator random)
        {
            RoomType[] roomTypes = (RoomType[])Enum.GetValues(typeof(RoomType));
            List<RoomType> safeTypes = new List<RoomType>();

            foreach (var type in roomTypes)
            {
                var room = RoomFactory.Create(type);
                if (room.BehaviourThreshold == 1) safeTypes.Add(type);
            }

            return safeTypes[random.Generate(0, safeTypes.Count)];

        }

        /// <summary>
        /// Given a grid size, return all indexes that fall on an edge of the grid.
        /// </summary>
        /// <param name="gridsize">Width and height of grid dimensions.</param>
        /// <returns>A list of indexes.</returns>
        internal static List<int> GetGridEdgeIndexes(int gridsize)
        {
            List<int> edgeIndexes = new List<int>();

            // Add indexes of top and bottom grid edges
            for (int i = 0; i < gridsize; i++)
            {
                edgeIndexes.Add(i); // Top edge
                edgeIndexes.Add(gridsize * (gridsize - 1) + i); // Bottom edge
            }

            // Add indexes of left and right grid edges, excluding corner indexes.
            for (int i = 1; i < (gridsize-1); i++)
            {
                edgeIndexes.Add(gridsize * i); // Left edge
                edgeIndexes.Add(gridsize * i + (gridsize - 1)); // Right edge
            }

            return edgeIndexes;
        }
    }
}
