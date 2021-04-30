using System;

namespace MazeGeneratorLib
{
    public class MazeIntegration : IMazeIntegration
    {
        // Ugly to keep state in a library but not sure how to solve it given the interface
        internal static IMaze Maze;

        public void BuildMaze(int size)
        {
            if (size < 2) throw new InvalidMazeSizeException($"Maze dimension must be 2 or greater.");
            Maze = MazeHandler.NewMaze(MazeType.VerySimpleMaze, size);
        }

        public bool CausesInjury(int roomId)
        {
            if (!Util.IndexInMazeRange(Maze, roomId, Maze.Size)) 
                throw new IndexOutOfRangeException($"Invalid roomId {roomId} for maze of size {Maze.Size}.");

            return MazeHandler.TrapCheck(new RandomGenerator(), Maze, roomId);
        }

        public string GetDescription(int roomId)
        {
            if (!Util.IndexInMazeRange(Maze, roomId, Maze.Size))
                throw new IndexOutOfRangeException($"Invalid roomId {roomId} for maze of size {Maze.Size}.");

            return Maze.Rooms[roomId].Description;
        }

        public int GetEntranceRoom()
        {
            return Maze.StartIndex;
        }

        public int? GetRoom(int roomId, char direction)
        {
            if (!Util.IndexInMazeRange(Maze, roomId, Maze.Size))
                throw new IndexOutOfRangeException($"Invalid roomId {roomId} for maze of size {Maze.Size}.");

            return MazeHandler.TraverseMaze(Maze, roomId, direction);
        }

        public bool HasTreasure(int roomId)
        {
            if (!Util.IndexInMazeRange(Maze, roomId, Maze.Size))
                throw new IndexOutOfRangeException($"Invalid roomId {roomId} for maze of size {Maze.Size}.");

            return roomId == Maze.EndIndex ? true : false;
        }
    }
}
