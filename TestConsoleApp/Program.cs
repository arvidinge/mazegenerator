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
            var mi = new MazeIntegration();
            char direction;
            int currentIndex;
            int? selectedRoom;

            mi.BuildMaze(mazesize);
            
            currentIndex = mi.GetEntranceRoom();

            while (true)
            {

                if (mi.HasTreasure(currentIndex))
                {
                    Console.WriteLine($"You found the treasure!");
                    break;
                }
                else if (mi.CausesInjury(currentIndex))
                {
                    Console.WriteLine(mi.GetDescription(currentIndex));
                    Console.WriteLine("Game over!");
                    break;
                }
                else
                {
                    Console.WriteLine($"{mi.GetDescription(currentIndex)}");
                }

                while (true)
                {
                    Console.Write($"Enter a direction: ");
                    direction = Console.ReadKey().KeyChar.ToString().ToUpper()[0];
                    Console.WriteLine();

                    selectedRoom = mi.GetRoom(currentIndex, direction);

                    if (selectedRoom == null)
                    {
                        Console.WriteLine($"You face a wall, select a different direction.");
                        continue;
                    }

                    currentIndex = (int)selectedRoom;
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
