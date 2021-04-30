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
            var actualIndexList = MazeGenerator.GetGridEdgeIndexes(size);
            actualIndexList.Sort();

            Assert.Equal(actualIndexList, expectedIndexList);

        }
    }
}
