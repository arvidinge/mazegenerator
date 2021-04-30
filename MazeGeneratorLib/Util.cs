using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGeneratorLib
{
    static class Util
    {
        public static bool IndexInMazeRange(IMaze maze, int index)
        {
            return ( index < 0 || index >= (maze.Size * maze.Size)) ? false : true;
        }
    }
}
