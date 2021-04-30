using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGeneratorLib
{
    class Desert : IRoom
    {
        public string Description { get; set; } = "The sun's merciless heat burns your skin, before you lay endless dunes of sand. You've reached a desert.";
        public string Behaviour { get; } = "You walk for hours, with no shelter in sight. Eventually, you succumb to the heat, too weak from dehydration to carry on.";
        public double BehaviourThreshold { get; set; } = 1 - 0.2;
    }
}
