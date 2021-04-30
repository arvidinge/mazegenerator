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
        IMazeIntegration mi;

        public MazeIntegrationTests()
        {
            mi = new MazeIntegration();
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
