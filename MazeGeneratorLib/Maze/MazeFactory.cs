using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGeneratorLib
{
    class MazeFactory : IMazeFactory
    {
        public IMaze Create(IRandomGenerator random, MazeType mazeType, int size)
        {
            if (random is null) throw new ArgumentNullException();
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
