using System;

namespace Vererbung;

internal class Leiharbeiter : Mitarbeiter
{
    // Attribut
    private string leiharbeitervermittlung;

    public Leiharbeiter()  // Zugriff auf Konstruktor der Basisklasse
    {
        Console.WriteLine("Name der Leiharbeitervermittlung");
        Leiharbeitervermittlung = Console.ReadLine();
    }

    public Leiharbeiter(string leiharbeitervermittlung) // Aufruf des Konstruktor der Basisklasse
    {
        Leiharbeitervermittlung = leiharbeitervermittlung;
    }

    public Leiharbeiter(string leiharbeitervermittlung, string name) : base(name) // Aufruf des Konstruktor der Basisklasse mit einem Parameter
    {
        Leiharbeitervermittlung = leiharbeitervermittlung;
    }

    // Eigenschaft (Property) für das Attribut leiharbeitervermittlung
    public string Leiharbeitervermittlung
    {
        get { return leiharbeitervermittlung; }
        set
        {
            // Das Schlüsselwort "value" verweist auf den Wert,
            // der der Eigenschaft vom Clientcode zugewiesen werden soll
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