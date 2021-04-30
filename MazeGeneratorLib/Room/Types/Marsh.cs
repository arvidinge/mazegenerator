using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGeneratorLib
{
    class Marsh : IRoom
    {
        public string Description { get; set; } = "You reach a vast marshland.";
        public string Behaviour { get; } = "Not watching your step, the ground gives under your feet, and you fall into the cold waters below.";
        public double BehaviourThreshold { get; set; } = 1 - 0.3;
    }
}
