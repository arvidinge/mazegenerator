using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MazeGeneratorLib
{
    public class InvalidRoomTypeException : Exception
    {
        public InvalidRoomTypeException() { }
        public InvalidRoomTypeException(string message) : base(message) { }
        public InvalidRoomTypeException(string message, Exception innerException) : base(message, innerException) { }
        protected InvalidRoomTypeException(
            SerializationInfo info, 
            StreamingContext context) : base(info, context) { }
    }

    public class InvalidMazeTypeException : Exception
    {
        public InvalidMazeTypeException() { }
        public InvalidMazeTypeException(string message) : base(message) { }
        public InvalidMazeTypeException(string message, Exception innerException) : base(message, innerException) { }
        protected InvalidMazeTypeException(
            SerializationInfo info, 
            StreamingContext context) : base(info, context) { }
    }

    public class InvalidDirectionException : Exception
    {
        public InvalidDirectionException() { }
        public InvalidDirectionException(string message) : base(message) { }
        public InvalidDirectionException(string message, Exception inner) : base(message, inner) { }
        protected InvalidDirectionException(
          SerializationInfo info,
          StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class InvalidMazeSizeException : Exception
    {
        public InvalidMazeSizeException() { }
        public InvalidMazeSizeException(string message) : base(message) { }
        public InvalidMazeSizeException(string message, Exception inner) : base(message, inner) { }
        protected InvalidMazeSizeException(
          SerializationInfo info,
          StreamingContext context) : base(info, context) { }
    }
}
