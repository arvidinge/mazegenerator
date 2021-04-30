namespace MazeGeneratorLib
{
    internal interface IMazeFactory
    {
        IMaze Create(IRandomGenerator random, MazeType mazeType, int size);
    }
}