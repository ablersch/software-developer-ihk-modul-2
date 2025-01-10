using System;
using System.Text.Json.Serialization;

namespace Medienverwaltung_Aufgabe_9;

internal class Tonie : Medium, ILaufzeit
{
    [JsonConstructor]
    public Tonie(double laufzeit, int signatur, string titel, Leihstatus status) : base(signatur, titel, status)
    {
        Laufzeit = laufzeit;
    }

    public Tonie()
    {
        Console.WriteLine("Laufzeit eingeben:");
        Laufzeit = Convert.ToDouble(Console.ReadLine());
    }

    public double Laufzeit { get; set; }

    internal override void Ausgabe()
    {
        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} Dauer {4:F2} min", Signatur, nameof(Tonie), Titel.Length > 15 ? Titel.Substring(0, 15) : Titel, Status, Laufzeit);
    }
}