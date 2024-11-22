using System;

namespace Vererbung;

internal class Mitarbeiter
{
    // Nur in dieser Klassen verfügbar nicht von außerhalb.
    // Da nur über den Konsturktor geändert, kann es readonly gesetzt werden
    private readonly string name;

    public Mitarbeiter()
    {
        Console.WriteLine("Name des Leiharbeiters");
        name = Console.ReadLine();
    }

    public Mitarbeiter(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }
}