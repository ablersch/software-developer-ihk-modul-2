using System;

namespace Medienverwaltung_Aufgabe_3;

internal class Program
{
    private static void Main()
    {
        string auswahl = string.Empty;
        int signatur;
        Video video = null;
        Buch buch = null;

        Console.WriteLine("Medienverwaltung");

        while (auswahl != "q")
        {
            Console.WriteLine("\n#### Menue ####");
            Console.WriteLine("Anlegen eines neuen Buch 'b'");
            Console.WriteLine("Anlegen eines neuen Video 'v'");
            Console.WriteLine("Ausgabe der vorhandenen Medien 'a'");
            Console.WriteLine("Entleihen des Medium 'e Signatur'");
            Console.WriteLine("Rueckgabe des Medium 'r Signatur'");
            Console.WriteLine("Programm beenden 'q'\n");

            auswahl = Console.ReadLine();
            signatur = 0;
            if (auswahl.Length > 5)
            {
                string[] temp = auswahl.Split(' ');
                auswahl = temp[0];
                if (!int.TryParse(temp[1], out signatur))
                {
                    Console.WriteLine("Keine gültige Signatur eingegeben");
                    continue;
                }
            }

            Console.WriteLine();
            switch (auswahl)
            {
                case "b":
                    buch = new Buch();
                    break;

                case "v":
                    video = new Video();
                    break;

                case "a":
                    Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15}", "Signatur", "Typ", "Titel", "Leihstatus", "Eigenschaften");
                    video?.Ausgabe();
                    buch?.Ausgabe();
                    break;

                case "e":
                    if (signatur == 0)
                    {
                        Console.WriteLine("Keine gültige Signatur zum entleihen eingegeben");
                        continue;
                    }
                    video?.Entleihen(signatur);
                    buch?.Entleihen(signatur);
                    break;

                case "r":
                    if (signatur == 0)
                    {
                        Console.WriteLine("Keine gültige Signatur zum zurückgeben eingegeben");
                        continue;
                    }
                    video?.Rueckgabe(signatur);
                    buch?.Rueckgabe(signatur);
                    break;

                case "q":
                    // "durchrutschen"
                    break;

                default:
                    Console.WriteLine("Falsche Eingabe\n");
                    break;
            }
        }
    }
}