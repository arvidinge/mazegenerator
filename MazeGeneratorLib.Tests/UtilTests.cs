using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MazeGeneratorLib.Tests
{
    public class UtilTests
    {
        IMaze maze;
        int mazeSize;

        public UtilTests()
        {
            mazeSize = 2;
            maze = new MockMazeFactoryAllForests().Create(null, MazeType.VerySimpleMaze, mazeSize);
        }

        [Fact]
        public void IndexInMazeRange_IndexInRange_ReturnsTrue()
        {
            bool result = Util.IndexInMazeRange(maze, mazeSize*mazeSize-1);

            Assert.True(result);
        }


        [Fact]
        public void IndexInMazeRange_IndexOutOfRange_ReturnsFalse()
        {
            bool result = Util.IndexInMazeRange(maze, mazeSize*mazeSize);

            Assert.False(result);
        }
    }
}
