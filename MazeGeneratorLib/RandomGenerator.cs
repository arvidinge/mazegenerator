using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGeneratorLib
{
    class RandomGenerator : IRandomGenerator
    {
        private static Random _random = new Random();

        public double Generate()
        {
            return _random.NextDouble();
        }

        public int Generate(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
