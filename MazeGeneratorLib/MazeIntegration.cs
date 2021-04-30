using System;

namespace MazeGeneratorLib
{
    public class MazeIntegration : IMazeIntegration
    {
        // If subsequent calls related to the same run of the maze aren't necessarily
        // made to the same instance of this class by the consumer, this Maze
        // variable must be made static.
        internal IMaze Maze;

        public void BuildMaze(int size)
        {
            if (size < 2) throw new InvalidMazeSizeException($"Maze dimension must be 2 or greater.");
            Maze = MazeHandler.NewMaze(MazeType.VerySimpleMaze, size);
        }

        public bool CausesInjury(int roomId)
        {
            if (!Util.IndexInMazeRange(Maze, roomId)) 
                throw new IndexOutOfRangeException($"Invalid roomId {roomId} for maze of size {Maze.Size}.");

            return MazeHandler.TrapCheck(new RandomGenerator(), Maze, roomId);
        }

        public string GetDescription(int roomId)
        {
            if (!Util.IndexInMazeRange(Maze, roomId))
                throw new IndexOutOfRangeException($"Invalid roomId {roomId} for maze of size {Maze.Size}.");

            return Maze.Rooms[roomId].Description;
        }

        public int GetEntranceRoom()
        {
            return Maze.StartIndex;
        }

        public int? GetRoom(int roomId, char direction)
        {
            if (!Util.IndexInMazeRange(Maze, roomId))
                throw new IndexOutOfRangeException($"Invalid roomId {roomId} for maze of size {Maze.Size}.");

            return MazeHandler.TraverseMaze(Maze, roomId, direction);
        }

        public bool HasTreasure(int roomId)
        {
            if (!Util.IndexInMazeRange(Maze, roomId))
                throw new IndexOutOfRangeException($"Invalid roomId {roomId} for maze of size {Maze.Size}.");

            return roomId == Maze.EndIndex ? true : false;
        }
    }
}
