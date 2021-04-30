using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int mazesize = 3;
            var hej = new MazeIntegration();

            hej.BuildMaze(mazesize);
            for (int i = 0; i < mazesize * mazesize; i++)
            {
                Console.WriteLine($"{hej.GetDescription(i)}");
            }

            Console.ReadKey();
        }
    }
}
