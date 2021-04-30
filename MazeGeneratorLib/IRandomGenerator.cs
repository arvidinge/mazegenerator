using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGeneratorLib
{
    interface IRandomGenerator
    {
        double Generate();
        int Generate(int min, int max);
    }
}
