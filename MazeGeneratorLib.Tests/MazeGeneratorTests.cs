using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MazeGeneratorLib;

namespace MazeGeneratorLib.Tests
{
    public class MazeGeneratorTests
    {
        IMazeGenerator mg;
        IRandomGenerator rg;
        IRoomFactory rf;

        public MazeGeneratorTests()
        {
            mg = new MazeGenerator();
            rf = new RoomFactory();
        }


        public static IEnumerable<object[]> GridEdgeTestData => new List<object[]>
        {
            new object[] { 2, new List<int> { 0, 1,
                                              2, 3 }},

            new object[] { 3, new List<int> { 0, 1, 2,
                                              3,    5,
                                              6, 7, 8 }},

            new object[] { 4, new List<int> { 0,  1,  2,  3,
                                              4,          7,
                                              8,          11,
                                              12, 13, 14, 15 }}
        };

        [Theory]
        [MemberData(nameof(GridEdgeTestData))]
        public void GetGridEdgeIndexes_ValidGridSize_ReturnsEdgeIndexes(int size, List<int> expectedIndexList)
        {
            var actualIndexList = mg.GetGridEdgeIndexes(size);
            actualIndexList.Sort();

            Assert.Equal(actualIndexList, expectedIndexList);
        }

        [Fact]
        public void GetStartAndEndIndexes_StartAndEndGeneratedEqual_StartAndEndNotEqual()
        {
            rg = new MockRandomGeneratorMin();

            var (start, end) = mg.GetStartAndEndIndexes(rg, 2);
            
            // MockRandomGeneratorMin will have generated 0 for both start and end indexes.
            // The internals of GetStartAndEndIndexes should change end index to something else.

            Assert.NotEqual(start, end);
        }

        [Fact]
        public void GetStartAndEndIndexes_StartAndEndBothMax_EndOverflowsToZero()
        {
            rg = new MockRandomGeneratorMax();

            var (_, end) = mg.GetStartAndEndIndexes(rg, 2);

            // MockRandomGeneratorMax will have generated max index for both start and end indexes.
            // The internals of GetStartAndEndIndexes should increase end index by 1 but overflow to 0 using mod operator.

            Assert.Equal(0, end);
        }

        [Fact]
        public void GetStartAndEndIndexes_StartAndEndGeneratedEqual_EndOneGreaterThanStart()
        {
            rg = new MockRandomGeneratorMin();

            var (start, end) = mg.GetStartAndEndIndexes(rg, 2);

            // MockRandomGeneratorMin will have generated 0 for both start and end indexes.
            // The internals of GetStartAndEndIndexes should increase end index by 1.

            Assert.Equal(start + 1, end);
        }

        [Fact]
        public void GetRandomSafeRoomType_AllPossibleGenerations_NoUnsafeRooms()
        {
            // Figure out how many safe room types there are.
            int safeTypesCount = 0;
            RoomType[] roomTypes = (RoomType[])Enum.GetValues(typeof(RoomType));

            foreach (var type in roomTypes)
            {
                var room = rf.Create(type);
                if (room.BehaviourThreshold == 1) safeTypesCount++;
            }

            // Generate every such room and make sure they all have a threshold of 1.
            bool allSafe = true;
            for (int i = 0; i < safeTypesCount; i++)
            {
                rg = new MockRandomGeneratorConst(intAnswer: i);
                // MockRandomGeneratorConst always gives the constructor argument back with Generate().
                // Using that with a loop index checks all room types deemed safe by GetRandomSafeRoomType.

                IRoom room = rf.Create(mg.GetRandomSafeRoomType(rg));
                if (room.BehaviourThreshold < 1.0)
                {
                    allSafe = false;
                    break;
                }
            }

            Assert.True(allSafe);
        }

        [Theory]
        [InlineData(2, 4)]
        [InlineData(3, 9)]
        [InlineData(4, 16)]
        public void GenerateMaze_ValidArguments_RoomsArrayIsSizeSquaredInLength(int gridsize, int expectedRoomsLength)
        {
            rg = new MockRandomGeneratorMin();
            var (rooms, _, _) = mg.GenerateMaze(rg, gridsize);

            Assert.Equal(expectedRoomsLength, rooms.Length);
        }
    }
}
