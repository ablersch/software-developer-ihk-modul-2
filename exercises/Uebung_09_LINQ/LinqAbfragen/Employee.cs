namespace LinqAbfragen;

internal class Employee
{
    public bool Active { get; set; } = true;

    public Department Department { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Number { get; set; }
}