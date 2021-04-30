using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MazeGeneratorLib
{
    internal class MazeGenerator : IMazeGenerator
    {
        public (IRoom[], int, int) GenerateMaze(IRandomGenerator random, int gridsize)
        {
            IRoom[] rooms = new IRoom[gridsize * gridsize];
            IRoomFactory rf = new RoomFactory();

            var (startIndex, endIndex) = GetStartAndEndIndexes(random, gridsize);
            rooms[startIndex] = rf.Create(GetRandomSafeRoomType(random)); 
            rooms[endIndex] = rf.Create(GetRandomSafeRoomType(random));

            // List of all roomtypes.
            RoomType[] roomTypes = (RoomType[])Enum.GetValues(typeof(RoomType));

            for (int i = 0; i < rooms.Length; i++)
            {
                if (i == startIndex || i == endIndex) continue;
                rooms[i] = rf.Create(roomTypes[random.Generate(0, roomTypes.Length)]); // Place a room of random type on each index.
            }

            return (rooms, startIndex, endIndex);
        }

        public (int, int) GetStartAndEndIndexes(IRandomGenerator random, int gridsize)
        {
            List<int> edgeIndexes = GetGridEdgeIndexes(gridsize);
            int startIndex = edgeIndexes[random.Generate(0, edgeIndexes.Count - 1)]; // Select a random index on the EDGE of the maze as the start room.
            int endIndex = random.Generate(0, gridsize * gridsize - 1); // Select a random index anywhere in the maze as the end room.

            if (startIndex == endIndex)
            {
                endIndex = (endIndex + 1) % (gridsize * gridsize); // Move end index up by 1, with overflow protection
            }

            return (startIndex, endIndex);
        }

        public RoomType GetRandomSafeRoomType(IRandomGenerator random)
        {
            IRoomFactory rf = new RoomFactory();
            RoomType[] roomTypes = (RoomType[])Enum.GetValues(typeof(RoomType));
            List<RoomType> safeTypes = new List<RoomType>();

            foreach (var type in roomTypes)
            {
                var room = rf.Create(type);
                if (room.BehaviourThreshold == 1) safeTypes.Add(type);
            }

            return safeTypes[random.Generate(0, safeTypes.Count)];
        }

        public List<int> GetGridEdgeIndexes(int gridsize)
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
