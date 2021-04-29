using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
    class VerySimpleMaze : IMaze
    {
        public int Size { get; }

        public IRoom[] Rooms { get; set; }

        public int StartIndex { get; set; }

        public int EndIndex { get; set; }

        public string Behaviour { get; } = "Default.";

        public VerySimpleMaze(int size, IRoom[] rooms, int startIndex, int endIndex)
        {
            Size = size;
            Rooms = rooms;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }
    }
}
