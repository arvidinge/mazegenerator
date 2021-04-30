﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGeneratorLib
{
    internal class RoomFactory : IRoomFactory
    {
        public IRoom Create(RoomType roomType)
        {
            switch (roomType)
            {
                case RoomType.Forest:
                    return new Forest();
                case RoomType.Marsh:
                    return new Marsh();
                case RoomType.Desert:
                    return new Desert();
                case RoomType.Hills:
                    return new Hills();
                default:
                    throw new InvalidRoomTypeException(message: $"Invalid RoomType: {roomType}");
            }
        }
    }
}
