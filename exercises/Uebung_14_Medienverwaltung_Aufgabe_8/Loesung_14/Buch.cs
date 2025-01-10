using System;
using System.Text.Json.Serialization;
using Serilog;

namespace Medienverwaltung_Aufgabe_8;

internal class Buch : Medium
{
    [JsonConstructor]
    public Buch(int seitenzahl, int signatur, string titel, Leihstatus status) : base(signatur, titel, status)
    {
        Seitenzahl = seitenzahl;
    }

    public Buch()
    {
        do
        {
            Console.WriteLine("Seitenzahl eingeben:");
            if (!int.TryParse(Console.ReadLine(), out int seitenzahl))
            {
                Log.Warning("Seitenzahl nicht gültig. Bitte nur ganze Zahlen eingeben.");
            }
            else
            {
                Seitenzahl = seitenzahl;
            }
        }
        while (Seitenzahl == 0);
    }

    public int Seitenzahl { get; set; }

    internal override void Ausgabe()
    {
        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} Seitenzahl {4,-15}", Signatur, nameof(Buch), KurzerTitel(), Status, Seitenzahl);
    }
}