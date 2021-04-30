using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MazeGeneratorLib.Tests
{
    public class MazeIntegrationTests
    {
        MazeIntegration mi;
        IMaze maze;
        int mazeSize;

        public MazeIntegrationTests()
        {
            mazeSize = 2;
            mi = new MazeIntegration();
            maze = new MockMazeFactoryAllForests().Create(null, MazeType.VerySimpleMaze, mazeSize);
            mi.Maze = maze;
        }


        [Fact]
        public void HasTreasure_RoomDoesntHaveTreasure_ReturnsFalse()
        {
            bool result = mi.HasTreasure(0);

            Assert.False(result);
        }

        [Fact]
        public void HasTreasure_RoomHasTreasure_ReturnsTrue()
        {
            bool result = mi.HasTreasure(mazeSize * mazeSize - 1);

            Assert.True(result);
        }

        [Fact]
        public void GetDescription_ValidId_ReturnCorrectDescription()
        {
            for (int i = 0; i < mazeSize*mazeSize; i++)
            {
                maze.Rooms[i].Description = i.ToString();
            }

            Assert.Equal("0", mi.GetDescription(0));
            Assert.Equal("1", mi.GetDescription(1));
            Assert.Equal("2", mi.GetDescription(2));
            Assert.Equal("3", mi.GetDescription(3));
        }


        [Fact]
        public void BuildMaze_SizeLessThanTwo_ThrowsException()
        {
            var ex = Record.Exception(() => mi.BuildMaze(1));

            Assert.NotNull(ex);
            Assert.IsType<InvalidMazeSizeException>(ex);
        }
    }
}
