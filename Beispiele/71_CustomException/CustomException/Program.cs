using CustomException;

string name = "MaxMustermann";

try
{
    if (!name.Contains(' '))
    {
        throw new InvalidNameException(name);
    }
}
catch (InvalidNameException e)
{
    Console.WriteLine(e.Message);
}