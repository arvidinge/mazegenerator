using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
    internal class MazeFactory
    {
        internal static IMaze Create(IRandomGenerator random, MazeType mazeType, int size)
        {
            switch (mazeType)
            {
                case MazeType.VerySimpleMaze:
                    var (rooms, startIndex, endIndex) = MazeGenerator.GenerateMaze(random, size);
                    return new VerySimpleMaze(size, rooms, startIndex, endIndex);
                default:
                    throw new InvalidMazeTypeException(message: $"Invalid MazeType: {mazeType}");
            }
        }
    }
}
