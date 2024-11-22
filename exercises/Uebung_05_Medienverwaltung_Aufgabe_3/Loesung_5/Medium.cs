using System;

namespace Medienverwaltung_Aufgabe_3;

internal class Medium
{
    protected int signatur = 0;
    protected Leihstatus status;
    protected string titel;

    public Medium()
    {
        bool signaturValid = false;
        Console.WriteLine("Signatur eingeben: ");

        while (!signaturValid)
        {
            signaturValid = int.TryParse(Console.ReadLine(), out signatur);

            if (!signaturValid)
            {
                Console.WriteLine("Signatur keine Zahl. Erneut eingeben: ");
                continue;
            }

            if (signatur < 1000)
            {
                Console.WriteLine("Signatur muss mindestens 4 Zeichen beinhalten. Erneut eingeben:");
                signaturValid = false;
            }
            else
            {
                signaturValid = true;
            }
        }

        Console.WriteLine("Titel eingeben:");
        titel = Console.ReadLine();

        status = Leihstatus.präsent;
    }

    internal void Entleihen(int signatur)
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

    internal void Rueckgabe(int signatur)
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
                Console.WriteLine($"Rueckgabe von {titel} nicht möglich da das Medium nicht entliehen ist.");
            }
        }
    }
}