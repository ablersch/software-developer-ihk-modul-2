using System;

namespace Medienverwaltung_Aufgabe_5;

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

    internal void Entleihen(int signatur)
    {
        if (Signatur == signatur)
        {
            if (status == Leihstatus.präsent)
            {
                status = Leihstatus.entliehen;
                Console.WriteLine($"{titel} erfolgreich ausgeliehen");
            }
            else
            {
                Console.WriteLine($"{titel} ist bereits entliehen");
            }
        }
    }

    internal void Rueckgabe(int signatur)
    {
        if (Signatur == signatur)
        {
            if (status == Leihstatus.entliehen)
            {
                status = Leihstatus.präsent;
                Console.WriteLine($"{titel} efolgreich zurueckgegeben");
            }
            else
            {
                Console.WriteLine($"Rueckgabe von {titel} nicht möglich da das Medium nicht entliehen ist");
            }
        }
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