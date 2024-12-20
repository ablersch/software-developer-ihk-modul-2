using System;

namespace Medienverwaltung_Aufgabe_6;

internal class Buch : Medium
{
    private int seitenzahl;

    public Buch()
    {
        Console.WriteLine("Seitenzahl eingeben:");
        while (!int.TryParse(Console.ReadLine(), out seitenzahl))
        {
            Console.WriteLine("Seitenzahl nicht gültig. Bitte nur ganze Zahlen eingeben:");
        }
    }

    internal override void Ausgabe()
    {
        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} Seitenzahl {4,-15}", Signatur, nameof(Buch), KurzerTitel(), status, seitenzahl);
    }
}