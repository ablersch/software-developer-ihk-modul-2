using System;
using System.Text.Json.Serialization;

namespace Medienverwaltung_Aufgabe_9;

internal class Video : Medium, ILaufzeit
{
    [JsonConstructor]
    public Video(double laufzeit, int signatur, string titel, Leihstatus status) : base(signatur, titel, status)
    {
        Laufzeit = laufzeit;
    }

    public Video()
    {
        Console.WriteLine("Laufzeit eingeben:");
        Laufzeit = Convert.ToDouble(Console.ReadLine());
    }

    public double Laufzeit { get; set; }

    internal override void Ausgabe()
    {
        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} Dauer {4:F2} min", Signatur, nameof(Video), KurzerTitel(), Status, Laufzeit);
    }
}