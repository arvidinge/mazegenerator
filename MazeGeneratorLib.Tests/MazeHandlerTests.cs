using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MazeGeneratorLib.Tests
{
    

    public class MazeHandlerTests
    {
        int mazeSize;
        IMaze maze;

        public MazeHandlerTests()
        {
            mazeSize = 3;
            maze = new MockMazeFactoryAllForests().Create(null, MazeType.VerySimpleMaze, mazeSize);
        }


        [Fact]
        public void TraverseMaze_InvalidDirection_ThrowsException()
        {
            int currentIndex = 0; // On western edge
            char direction = '1';

            var exception = Record.Exception(() => MazeHandler.TraverseMaze(maze, currentIndex, direction));

            Assert.NotNull(exception);
            Assert.IsType<InvalidDirectionException>(exception);
        }


        // NORTH

        [Fact]
        public void TraverseMaze_MovingNorthAtNorthernBorder_ReturnsNull()
        {
            int currentIndex = 0; // On first row
            char direction = 'N';

            int? result = MazeHandler.TraverseMaze(maze, currentIndex, direction);

            Assert.Null(result);
        }

        [Fact]
        public void TraverseMaze_MovingNorthNotAtNorthernBorder_ReturnsNotNull()
        {
            int currentIndex = mazeSize * 1; // On second row
            char direction = 'N';

            int? actualIndex = MazeHandler.TraverseMaze(maze, currentIndex, direction);

            Assert.NotNull(actualIndex);
        }

        [Theory]
        [InlineData(3, 0)] // Should be based off mazeSize, couldn't get that to work.
        [InlineData(4, 1)]
        [InlineData(5, 2)]
        public void TraverseMaze_MovingNorthNotAtNorthernBorder_ReturnsIndexOfNorthernNeighbour(int startIndex, int expectedIndex)
        {
            char direction = 'N';

            int? actualIndex = MazeHandler.TraverseMaze(maze, startIndex, direction);

            Assert.Equal(expectedIndex, actualIndex);
        }



        // EAST

        [Fact]
        public void TraverseMaze_MovingEastAtEasternBorder_ReturnsNull()
        {
            int currentIndex = mazeSize - 1; // On right edge
            char direction = 'E';

            int? result = MazeHandler.TraverseMaze(maze, currentIndex, direction);

            Assert.Null(result);
        }

        [Fact]
        public void TraverseMaze_MovingEastNotAtEasternBorder_ReturnsNotNull()
        {
            int currentIndex = mazeSize; // Not on right edge
            char direction = 'E';

            int? actualIndex = MazeHandler.TraverseMaze(maze, currentIndex, direction);

            Assert.NotNull(actualIndex);
        }

        [Theory]
        [InlineData(0, 1)] 
        [InlineData(3, 4)]
        [InlineData(6, 7)]
        public void TraverseMaze_MovingEastNotAtEasternBorder_ReturnsIndexOfEasternNeighbour(int startIndex, int expectedIndex)
        {
            char direction = 'E';

            int? actualIndex = MazeHandler.TraverseMaze(maze, startIndex, direction);

            Assert.Equal(expectedIndex, actualIndex);
        }



        // SOUTH

        [Fact]
        public void TraverseMaze_MovingSouthAtSouthernBorder_ReturnsNull()
        {
            int currentIndex = mazeSize * (mazeSize - 1); // On southern edge
            char direction = 'S';

            int? result = MazeHandler.TraverseMaze(maze, currentIndex, direction);

            Assert.Null(result);
        }

        [Fact]
        public void TraverseMaze_MovingSouthNotAtSouthernBorder_ReturnsNotNull()
        {
            int currentIndex = 0; // Not on southern edge
            char direction = 'S';

            int? actualIndex = MazeHandler.TraverseMaze(maze, currentIndex, direction);

            Assert.NotNull(actualIndex);
        }

        [Theory]
        [InlineData(0, 3)]
        [InlineData(1, 4)]
        [InlineData(2, 5)]
        public void TraverseMaze_MovingSouthNotAtSouthernBorder_ReturnsIndexOfSouthernNeighbour(int startIndex, int expectedIndex)
        {
            char direction = 'S';

            int? actualIndex = MazeHandler.TraverseMaze(maze, startIndex, direction);

            Assert.Equal(expectedIndex, actualIndex);
        }



        // WEST

        [Fact]
        public void TraverseMaze_MovingWestAtWesternBorder_ReturnsNull()
        {
            int currentIndex = 0; // On western edge
            char direction = 'W';

            int? result = MazeHandler.TraverseMaze(maze, currentIndex, direction);

            Assert.Null(result);
        }

        [Fact]
        public void TraverseMaze_MovingWestNotAtWesternBorder_ReturnsNotNull()
        {
            int currentIndex = mazeSize - 1; // Not on western edge
            char direction = 'W';

            int? actualIndex = MazeHandler.TraverseMaze(maze, currentIndex, direction);

            Assert.NotNull(actualIndex);
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(5, 4)]
        [InlineData(8, 7)]
        public void TraverseMaze_MovingWestNotAtWesternBorder_ReturnsIndexOfEasternNeighbour(int startIndex, int expectedIndex)
        {
            char direction = 'W';

            int? actualIndex = MazeHandler.TraverseMaze(maze, startIndex, direction);

            Assert.Equal(expectedIndex, actualIndex);
        }


        [Fact]
        public void TrapCheck_GeneratedDoubleBelowThreshold_ReturnsFalse()
        {
            var random = new MockRandomGeneratorMin(); // Always generates 0.0.
            maze = new MockMazeFactoryAllMarshes().Create(null, MazeType.VerySimpleMaze, mazeSize);

            bool result = MazeHandler.TrapCheck(random, maze, 0);

            Assert.False(result);
        }

        [Fact]
        public void TrapCheck_GeneratedDoubleAboveThreshold_ReturnsTrue()
        {
            var random = new MockRandomGeneratorMax(); // Always generates 1.0.
            maze = new MockMazeFactoryAllMarshes().Create(null, MazeType.VerySimpleMaze, mazeSize);

            bool result = MazeHandler.TrapCheck(random, maze, 0);

            Assert.True(result);
        }

        [Fact]
        public void NewMaze_Invoked_MazeRefIsNotNull()
        {
            Assert.Null(MazeHandler.Maze);
            MazeHandler.NewMaze(MazeType.VerySimpleMaze, mazeSize);
            Assert.NotNull(MazeHandler.Maze);
        }

    }
}
