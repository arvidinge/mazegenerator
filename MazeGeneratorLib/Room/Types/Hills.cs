using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGeneratorLib
{
    class Hills : IRoom
    {
        public string Description { get; set; } = "You see large, green hills before you.";
        public string Behaviour { get; } = "You stumble and hit your head on a rock.";
        public double BehaviourThreshold { get; set; } = 1 - 0;
    }
}
