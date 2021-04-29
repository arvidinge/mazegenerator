using System;

namespace MazeGenerator
{
    public class MazeIntegration : IMazeIntegration
    {
        public void BuildMaze(int size)
        {
            if (size < 2) throw new InvalidMazeSizeException($"Maze dimension must be 2 or greater.");
            MazeHandler.NewMaze(MazeType.VerySimpleMaze, size);
        }

        public bool CausesInjury(int roomId)
        {
            if (!Util.IndexInMazeRange(roomId, MazeHandler.Maze.Size)) 
                throw new IndexOutOfRangeException($"Invalid roomId {roomId} for maze of size {MazeHandler.Maze.Size}.");

            return MazeHandler.TrapCheck(new RandomGenerator(), roomId);
        }

        public string GetDescription(int roomId)
        {
            if (!Util.IndexInMazeRange(roomId, MazeHandler.Maze.Size))
                throw new IndexOutOfRangeException($"Invalid roomId {roomId} for maze of size {MazeHandler.Maze.Size}.");

            return MazeHandler.Maze.Rooms[roomId].Description;
        }

        public int GetEntranceRoom()
        {
            return MazeHandler.Maze.StartIndex;
        }

        public int? GetRoom(int roomId, char direction)
        {
            if (!Util.IndexInMazeRange(roomId, MazeHandler.Maze.Size))
                throw new IndexOutOfRangeException($"Invalid roomId {roomId} for maze of size {MazeHandler.Maze.Size}.");

            return MazeHandler.TraverseMaze(roomId, direction);
        }

        public bool HasTreasure(int roomId)
        {
            if (!Util.IndexInMazeRange(roomId, MazeHandler.Maze.Size))
                throw new IndexOutOfRangeException($"Invalid roomId {roomId} for maze of size {MazeHandler.Maze.Size}.");

            return roomId == MazeHandler.Maze.EndIndex ? true : false;
        }
    }
}
