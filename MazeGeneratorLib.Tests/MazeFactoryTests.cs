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

        public MazeFactoryTests()
        {
            mazeFactory = new MazeFactory();
        }

        [Fact]
        public void Create_RandomGeneratorIsNull_ThrowsException()
        {
            var ex = Record.Exception(() => mazeFactory.Create(null, MazeType.VerySimpleMaze, 0));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }
    }
}
