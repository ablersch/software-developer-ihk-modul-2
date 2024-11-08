using System;

namespace Vererbung;

internal class Leiharbeiter : Mitarbeiter
{
    // Feld
    private string leiharbeitervermittlung;

    // Zugriff auf Konstruktor der Basisklasse
    public Leiharbeiter()
    {
        Console.WriteLine("Name der Leiharbeitervermittlung");
        Leiharbeitervermittlung = Console.ReadLine();
    }

    // Aufruf des Konstruktor der Basisklasse
    public Leiharbeiter(string leiharbeitervermittlung)
    {
        Leiharbeitervermittlung = leiharbeitervermittlung;
    }

    // Aufruf des Konstruktor der Basisklasse mit einem Parameter
    public Leiharbeiter(string leiharbeitervermittlung, string name) : base(name)
    {
        Leiharbeitervermittlung = leiharbeitervermittlung;
    }

    // Eigenschaft (Property) für das Feld leiharbeitervermittlung
    public string Leiharbeitervermittlung
    {
        get { return leiharbeitervermittlung; }
        set
        {
            // Das Schlüsselwort "value" verweist auf den Wert,
            // der der Eigenschaft vom Clientcode zugewiesen werden soll.
            if (string.IsNullOrWhiteSpace(value))
            {
                leiharbeitervermittlung = "Nicht bekannt";
            }
            else
            {
                leiharbeitervermittlung = value;
            }
        }
    }

    public string GetData()
    {
        return $"Name: {GetName()} Leiharbeitervermittlung: {Leiharbeitervermittlung}";
    }
}