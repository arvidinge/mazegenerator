using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneratorLib.Tests
{
    internal class MockRandomGeneratorMin : IRandomGenerator
    {
        public double Generate()
        {
            return 0.0;
        }

        public int Generate(int min, int max)
        {
            return min;
        }
    }

    internal class MockRandomGeneratorMax : IRandomGenerator
    {
        public double Generate()
        {
            return 1.0;
        }

        public int Generate(int min, int max)
        {
            return max;
        }
    }

    /// <summary>
    /// All rooms in generated maze are marshes (traps with 0.7 threshold)
    /// </summary>
    internal class MockMazeFactoryAllMarshes : IMazeFactory
    {
        public IMaze Create(IRandomGenerator random, MazeType mazeType, int size)
        {
            IRoom[] rooms = new IRoom[size * size];
            for (int i = 0; i < rooms.Length; i++)
            {
                rooms[i] = RoomFactory.Create(RoomType.Marsh);
            }
            return new VerySimpleMaze(size, rooms, 0, rooms.Length - 1);
        }
    }

    /// <summary>
    /// All rooms in generated maze are forests (No traps)
    /// </summary>
    internal class MockMazeFactoryAllForests : IMazeFactory
    {
        public IMaze Create(IRandomGenerator random, MazeType mazeType, int size)
        {
            IRoom[] rooms = new IRoom[size * size];
            for (int i = 0; i < rooms.Length; i++)
            {
                rooms[i] = RoomFactory.Create(RoomType.Marsh);
            }
            return new VerySimpleMaze(size, rooms, 0, rooms.Length - 1);
        }
    }
}
