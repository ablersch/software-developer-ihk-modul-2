using System;
using Logger;

namespace Medienverwaltung_Aufgabe_6;

internal abstract class Medium
{
    protected Leihstatus status;

    protected string titel;

    public Medium()
    {
        Signatur = SignaturErzeugen();

        Console.WriteLine("Titel eingeben:");
        titel = Console.ReadLine();

        status = Leihstatus.präsent;
    }

    internal int Signatur { get; set; }

    internal static void AusgabeUeberschrift()
    {
        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15}", "Signatur", "Typ", "Titel", "Leihstatus", "Eigenschaften");
    }

    internal abstract void Ausgabe();

    internal void Entleihen()
    {
        if (status == Leihstatus.präsent)
        {
            status = Leihstatus.entliehen;
            Console.WriteLine(titel + " efolgreich ausgeliehen.");
        }
        else
        {
            WriteWarningToLog($"Fehler beim Entleihen von Signatur '{Signatur}'.");
        }
    }

    internal void Rueckgabe()
    {
        if (status == Leihstatus.entliehen)
        {
            status = Leihstatus.präsent;
            Console.WriteLine(titel + " efolgreich zurueckgegeben.");
        }
        else
        {
            WriteWarningToLog($"Fehler beim Rückgeben von Signatur '{Signatur}'.");
        }
    }

    protected string KurzerTitel()
    {
        return (titel.Length > 15) ? titel.Substring(0, 15) : titel;
    }

    private static int SignaturErzeugen()
    {
        Random random = new Random();
        int newKey;
        do
        {
            newKey = random.Next(1000, 100000);
        } while (Program.medienDic.ContainsKey(newKey));

        return newKey;
    }

    private static void WriteWarningToLog(string message)
    {
        Console.WriteLine(message);
        LoggerUtil.WriteToLog(message, LoggerUtil.LogTyp.Warning);
    }
}