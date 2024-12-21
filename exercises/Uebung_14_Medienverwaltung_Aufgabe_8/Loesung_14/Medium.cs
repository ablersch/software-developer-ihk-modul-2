using System;
using System.Text.Json.Serialization;
using Serilog;

namespace Medienverwaltung_Aufgabe_8;

[JsonDerivedType(typeof(Buch), "Buch")]
[JsonDerivedType(typeof(Video), "Video")]
public abstract class Medium
{
    public Medium(int signatur, string titel, Leihstatus status)
    {
        Signatur = signatur;
        Titel = titel;
        Status = status;
    }

    public Medium()
    {
        Signatur = SignaturErzeugen();

        Console.WriteLine("Titel eingeben:");
        Titel = Console.ReadLine();

        Status = Leihstatus.präsent;
    }

    public int Signatur { get; set; }

    public Leihstatus Status { get; set; }

    public string Titel { get; set; }

    internal static void AusgabeUeberschrift()
    {
        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15}", "Signatur", "Typ", "Titel", "Leihstatus", "Eigenschaften");
    }

    internal abstract void Ausgabe();

    internal void Entleihen()
    {
        if (Status == Leihstatus.präsent)
        {
            Status = Leihstatus.entliehen;
            Console.WriteLine(Titel + " efolgreich ausgeliehen.");
        }
        else
        {
            Log.Error($"Fehler beim Entleihen von Signatur '{Signatur}'.");
        }
    }

    internal void Rueckgabe()
    {
        if (Status == Leihstatus.entliehen)
        {
            Status = Leihstatus.präsent;
            Console.WriteLine(Titel + " efolgreich zurueckgegeben.");
        }
        else
        {
            Log.Error($"Fehler beim Rückgeben von Signatur '{Signatur}'.");
        }
    }

    protected string KurzerTitel()
    {
        return (Titel.Length > 15) ? Titel.Substring(0, 15) : Titel;
    }

    private static int SignaturErzeugen()
    {
        Random random = new();
        int newKey;
        do
        {
            newKey = random.Next(1000, 100000);
        } while (Program.medienDic.ContainsKey(newKey));

        return newKey;
    }
}