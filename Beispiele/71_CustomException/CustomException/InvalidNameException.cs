using System.Runtime.Serialization;

namespace CustomException;

[Serializable]
public class InvalidNameException : Exception
{
    /// <inheritdoc />
    public InvalidNameException()
    {
    }

    /// <inheritdoc />
    public InvalidNameException(string name)
        : base($"Invalid Name: {name}")
    {
    }

    /// <inheritdoc />
    protected InvalidNameException(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext)
    {
    }
}