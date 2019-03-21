using System;
using System.Runtime.Serialization;

namespace CustomClassLibrary.Exceptions
{
    [Serializable]
    class ArgumentFormatException : ArgumentException
    {
        public ArgumentFormatException()
            : base(ErrorMessage.ArgumentFormatExceptionMsg)
        {
        }

        public ArgumentFormatException(string message)
            : base(message)
        {
        }

        public ArgumentFormatException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ArgumentFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
