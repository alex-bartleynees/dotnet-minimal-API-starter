using System.Runtime.Serialization;

namespace Application.Common.Exceptions
{
    [Serializable]
    public sealed class NotFoundException : Exception
    {

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        private NotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }
}