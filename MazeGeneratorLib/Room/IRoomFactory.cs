namespace MazeGeneratorLib
{
    internal interface IRoomFactory
    {
        IRoom Create(RoomType roomType);
    }
}