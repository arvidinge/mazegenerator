using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
    internal static class MazeHandler
    {
        public static IMaze Maze { get; private set; }

        internal static bool TrapCheck(IRandomGenerator random, int roomId)
        {
            bool injured = random.Generate() < Maze.Rooms[roomId].BehaviourThreshold;

            if (injured) Maze.Rooms[roomId].Description += $" {Maze.Rooms[roomId].Behaviour}";
            return injured;
        }

        /// <summary>
        /// Generates a new maze with a random layout.
        /// </summary>
        /// <param name="mazeType">Type of maze to generate.</param>
        /// <param name="size">Width and height of maze dimensions.</param>
        public static void NewMaze(MazeType mazeType, int size)
        {
            Maze = MazeFactory.Create(new RandomGenerator(), mazeType, size);
        }

        /// <summary>
        /// Gets the index of the adjacent room in the specified <paramref name="direction"/>, starting from <paramref name="currentIndex"/>.
        /// </summary>
        /// <param name="currentIndex">Index of the current room.</param>
        /// <param name="direction">Cardinal direction to move in; 'N', 'E', 'S' or 'W'.</param>
        /// <returns>NULL if edge of the maze traversed, index of the adjacent room otherwise.</returns>
        public static int? TraverseMaze(int currentIndex, char direction)
        {
            switch (direction.ToString().ToUpper())
            {
                case "N":
                    return MoveNorth(currentIndex);
                case "E":
                    return MoveEast(currentIndex);
                case "S":
                    return MoveSouth(currentIndex);
                case "W":
                    return MoveWest(currentIndex);
                default:
                    throw new InvalidDirectionException($"{direction} is not a valid cardinal direction, expected 'N', 'E', 'S' or 'W'.");
            }
        }

        private static int? MoveNorth(int currentIndex)
        {
            if (currentIndex < Maze.Size) return null;
            else return (currentIndex - Maze.Size);
        }

        private static int? MoveEast(int currentIndex)
        {
            if (currentIndex % Maze.Size == Maze.Size - 1) return null;
            else return (currentIndex + 1);
        }
        private static int? MoveSouth(int currentIndex)
        {
            if (currentIndex >= Maze.Size * (Maze.Size - 1)) return null;
            else return (currentIndex + Maze.Size);
        }

        private static int? MoveWest(int currentIndex)
        {
            if (currentIndex % Maze.Size == 0) return null;
            else return (currentIndex - 1);
        }
    }
}
