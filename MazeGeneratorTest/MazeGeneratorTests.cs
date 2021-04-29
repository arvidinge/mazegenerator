using System;
using System.Collections.Generic;
using Xunit;
using MazeGenerator;

namespace MazeGeneratorTests
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
        public void GetGridEdgeIndexes_NormalScenario_ReturnsEdgeIndexes(int gridSize, List<int> expectedIndexList)
        {

        }
    }
}
