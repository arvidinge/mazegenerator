using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
    static class Util
    {
        public static bool IndexInMazeRange(int index, int size)
        {
            return index < 0 || index >= (MazeHandler.Maze.Size * MazeHandler.Maze.Size) ? false : true;
        }
    }
}
