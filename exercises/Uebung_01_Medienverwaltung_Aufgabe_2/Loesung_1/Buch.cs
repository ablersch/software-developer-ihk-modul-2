using System;

namespace Medienverwaltung_Aufgabe_2;

internal class Buch
{
    private int seitenzahl;
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

        Console.WriteLine("Seitenzahl eingeben: ");
        while (!int.TryParse(Console.ReadLine(), out seitenzahl))
        {
            Console.WriteLine("Seitenzahl ist keine Zahl. Erneut eingeben: ");
        }
        status = Leihstatus.präsent;
        Console.WriteLine("Buch erfolgreich angelegt!");
    }

    /// <summary>
    /// Ausgabe der Buchdaten
    /// </summary>
    public void Ausgabe()
    {
        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15}", signatur, nameof(Buch), titel, status, seitenzahl);
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
                Console.WriteLine($"Rueckgabe von {titel} nicht möglich da das Buch nicht entliehen ist.");
            }
        }
    }
}