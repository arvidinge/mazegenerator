using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MazeGeneratorLib.Tests
{
    public class RoomFactoryTests
    {
        IRoomFactory rf;
        public RoomFactoryTests()
        {
            rf = new RoomFactory();
        }

        [Fact]
        public void Create_RoomTypeForest_ReturnsForest()
        {
            IRoom room = rf.Create(RoomType.Forest);

            Assert.IsType<Forest>(room);
        }

        [Fact]
        public void Create_RoomTypeDesert_ReturnsDesert()
        {
            IRoom room = rf.Create(RoomType.Desert);

            Assert.IsType<Desert>(room);
        }

        [Fact]
        public void Create_RoomTypeMarsh_ReturnsMarsh()
        {
            IRoom room = rf.Create(RoomType.Marsh);

            Assert.IsType<Marsh>(room);
        }

        [Fact]
        public void Create_RoomTypeHills_ReturnsHills()
        {
            IRoom room = rf.Create(RoomType.Hills);

            Assert.IsType<Hills>(room);
        }
    }
}
