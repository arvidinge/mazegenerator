using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
    interface IRoom
    {
        /// <summary>
        /// A room's general description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Describes the behaviour of the room, may or may not be enabled.
        /// </summary>
        string Behaviour { get; }

        /// <summary>
        /// A double greater than or equal to 0.0, and less than 1.0. <br/>
        /// Consider a room's behaviour enabled if a random double in the same range exceeds this threshold.
        /// </summary>
        double BehaviourThreshold { get; set; }
    }
}
