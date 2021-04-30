using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGeneratorLib
{
    internal static class MazeHandler
    {
        /// <summary>
        /// Checks wether the treasure hunter gets injured in a room.
        /// </summary>
        /// <param name="random">A random number generator.</param>
        /// <param name="roomId">ID of the room.</param>
        /// <returns></returns>
        public static bool TrapCheck(IRandomGenerator random, IMaze maze, int roomId)
        {
            bool injured = random.Generate() > maze.Rooms[roomId].BehaviourThreshold;

            if (injured) maze.Rooms[roomId].Description += $" {maze.Rooms[roomId].Behaviour}";
            return injured;
        }

        /// <summary>
        /// Generates a new maze with a random layout.
        /// </summary>
        /// <param name="mazeType">Type of maze to generate.</param>
        /// <param name="size">Width and height of maze dimensions.</param>
        public static IMaze NewMaze(MazeType mazeType, int size)
        {
            return new MazeFactory().Create(new RandomGenerator(), mazeType, size);
        }

        /// <summary>
        /// Gets the index of the adjacent room in the specified <paramref name="direction"/>, starting from <paramref name="currentIndex"/>.
        /// </summary>
        /// <param name="currentIndex">Index of the current room.</param>
        /// <param name="direction">Cardinal direction to move in; 'N', 'E', 'S' or 'W'.</param>
        /// <returns>NULL if edge of the maze traversed, index of the adjacent room otherwise.</returns>
        public static int? TraverseMaze(IMaze maze, int currentIndex, char direction)
        {
            switch (direction.ToString().ToUpper())
            {
                case "N":
                    return MoveNorth(maze, currentIndex);
                case "E":
                    return MoveEast(maze, currentIndex);
                case "S":
                    return MoveSouth(maze, currentIndex);
                case "W":
                    return MoveWest(maze, currentIndex);
                default:
                    throw new InvalidDirectionException($"{direction} is not a valid cardinal direction, expected 'N', 'E', 'S' or 'W'.");
            }
        }

        private static int? MoveNorth(IMaze maze, int currentIndex)
        {
            if (currentIndex < maze.Size) return null;
            else return (currentIndex - maze.Size);
        }

        private static int? MoveEast(IMaze maze, int currentIndex)
        {
            if (currentIndex % maze.Size == maze.Size - 1) return null;
            else return (currentIndex + 1);
        }

        private static int? MoveSouth(IMaze maze, int currentIndex)
        {
            if (currentIndex >= maze.Size * (maze.Size - 1)) return null;
            else return (currentIndex + maze.Size);
        }

        private static int? MoveWest(IMaze maze, int currentIndex)
        {
            if (currentIndex % maze.Size == 0) return null;
            else return (currentIndex - 1);
        }
    }
}
