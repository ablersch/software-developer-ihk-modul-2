using System;

namespace Medienverwaltung_Aufgabe_6;

internal class Video : Medium
{
    private double laufzeit;

    public Video()
    {
        Console.WriteLine("Laufzeit eingeben:");
        laufzeit = Convert.ToDouble(Console.ReadLine());
    }

    internal override void Ausgabe()
    {
        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} Dauer {4:F2} min", Signatur, nameof(Video), KurzerTitel(), status, laufzeit);
    }
}