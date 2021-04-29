using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
    class Forest : IRoom
    {
        public string Description { get; set; } = "You enter a lush forest.";
        public string Behaviour { get; } = "You step on an ant hill, unfortunately inhabited by the CGI ants from Indiana Jones 4.";
        public double BehaviourThreshold { get; set; } = 1 - 0;
    }
}
