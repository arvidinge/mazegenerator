using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MazeGeneratorLib.Tests
{
    public class MazeFactoryTests
    {
        IMazeFactory mazeFactory;
        IRandomGenerator randomGenerator;

        public MazeFactoryTests()
        {
            mazeFactory = new MazeFactory();
            randomGenerator = new MockRandomGeneratorMin();
        }

        [Fact]
        public void Create_RandomGeneratorIsNull_ThrowsException()
        {
            var ex = Record.Exception(() => mazeFactory.Create(null, MazeType.VerySimpleMaze, 0));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void Create_VerySimpleMazeRequested_ReturnsVerySimpleMaze()
        {
            var result = mazeFactory.Create(randomGenerator, MazeType.VerySimpleMaze, 2);

            Assert.IsType<VerySimpleMaze>(result);
        }
    }
}
