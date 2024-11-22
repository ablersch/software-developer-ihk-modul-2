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
}