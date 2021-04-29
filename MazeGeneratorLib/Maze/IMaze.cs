using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
    interface IMaze
    {
        /// <summary>
        /// Width and height of maze dimensions.
        /// </summary>
        int Size { get; }

        /// <summary>
        /// A 1D array representing the 2D arrangement of rooms. <br/>
        /// Example: Indexes in maze of size 3: <br/>
        /// [0][1][2]<br/>
        /// [3][4][5]<br/>
        /// [6][7][8]        
        /// </summary>
        IRoom[] Rooms { get; }

        /// <summary>
        /// Describes behaviour modifier of the room.
        /// </summary>
        string Behaviour { get; }

        /// <summary>
        /// The index of the room the treasure hunter starts in.
        /// </summary>
        int StartIndex { get; }

        /// <summary>
        /// The index of the room in which the treasure resides.
        /// </summary>
        int EndIndex { get; }
    }
}
