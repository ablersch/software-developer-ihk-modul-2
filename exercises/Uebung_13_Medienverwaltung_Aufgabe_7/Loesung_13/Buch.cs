using System;
using Serilog;

namespace Medienverwaltung_Aufgabe_7;

internal class Buch : Medium
{
    private int seitenzahl;

    public Buch()
    {
        do
        {
            Console.WriteLine("Seitenzahl eingeben:");
            if (!int.TryParse(Console.ReadLine(), out seitenzahl))
            {
                Log.Warning("Seitenzahl nicht gültig. Bitte nur ganze Zahlen eingeben.");
            }
        }
        while (seitenzahl == 0);
    }

    internal override void Ausgabe()
    {
        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} Seitenzahl {4,-15}", Signatur, nameof(Buch), KurzerTitel(), status, seitenzahl);
    }
}