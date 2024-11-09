using System;

namespace Medienverwaltung_Aufgabe_2;

internal class Video
{
    private double laufzeit;
    private int signatur;
    private Leihstatus status;
    private string titel;

    public void Anlegen()
    {
        Console.WriteLine("Signatur eingeben: ");

        while (!int.TryParse(Console.ReadLine(), out signatur) || signatur < 999)
        {
            Console.WriteLine("Signatur ist keine Zahl oder hat keine 4 Zeichen. Erneut eingeben: ");
        }

        Console.WriteLine("Titel eingeben:");
        titel = Console.ReadLine();

        Console.WriteLine("Laufzeit eingeben:");
        while (!double.TryParse(Console.ReadLine(), out laufzeit))
        {
            Console.WriteLine("Laufzeit ist keine Zahl. Erneut eingeben: ");
        }

        status = Leihstatus.präsent;
        Console.WriteLine("Buch erfolgreich angelegt!");
    }

    /// <summary>
    /// Ausgabe der Buchdaten
    /// </summary>
    public void Ausgabe()
    {
        Console.WriteLine("{0,-15} {1,-15} {2, -15} {3,-15} Dauer {4:F2} min", signatur, nameof(Video), titel, status, laufzeit);
    }

    public void Entleihen(int signatur)
    {
        if (this.signatur == signatur)
        {
            if (status == Leihstatus.präsent)
            {
                status = Leihstatus.entliehen;
                Console.WriteLine($"{titel} erfolgreich ausgeliehen.");
            }
            else
            {
                Console.WriteLine($"{titel} ist bereits entliehen.");
            }
        }
    }

    public void Rueckgabe(int signatur)
    {
        if (this.signatur == signatur)
        {
            if (status == Leihstatus.entliehen)
            {
                status = Leihstatus.präsent;
                Console.WriteLine($"{titel} erfolgreich zurueckgegeben.");
            }
            else
            {
                Console.WriteLine($"Rueckgabe von {titel} nicht möglich da das Video nicht entliehen ist.");
            }
        }
    }
}