using System;

namespace Banksystem;

public class Kunde
{
    public Kunde()
    {
        int alter;

        Console.WriteLine("Inhaber Name:");
        Name = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Alter:");

        while (!int.TryParse(Console.ReadLine(), out alter))
        {
            Console.WriteLine("Kein gültiges Alter eingegeben");
        }
        Alter = alter;
    }

    public int Alter { get; set; }

    public string Name { get; set; }

    // TODO bearbeiten vom Kunde
    // TODO mehrere Kunden
    public void AusgabeInhaber()
    {
        Console.WriteLine("Inhaber");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Alter: {Alter}");
    }
}