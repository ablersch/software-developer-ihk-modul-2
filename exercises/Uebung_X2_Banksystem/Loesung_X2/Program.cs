using System;
using System.Collections.Generic;
using System.Linq;

namespace Banksystem;

internal class Program
{
    // Beinhaltet alle Konten zur Laufzeit des Programms
    private static Dictionary<int, Konto> kontoDic = new();

    /// <summary>
    /// Alle Konten ausgeben
    /// </summary>
    /// <param name="kontoList">Liste der Konten</param>
    private static void AusgabeKonten(List<Konto> kontoList)
    {
        // Konten nach Kontostand sortieren
        kontoList = kontoList.OrderBy(x => x.Kontostand).ToList();
        foreach (var konto in kontoList)
        {
            konto.AusgabeKonto();
            Console.WriteLine("");
        }
    }

    /// <summary>
    /// Zu einem Inhaber alle Konten holen
    /// </summary>
    /// <param name="name">Name des Inhabers</param>
    /// <returns>List aller Konten eines Inhabers</returns>
    private static List<Konto> GetKontoFürInhaber(string name)
    {
        List<Konto> returnList = new();

        // Mit LINQ
        returnList.AddRange(kontoDic.Where(konto => konto.Value.Inhaber.Name == name).Select(konto => konto.Value));

        //foreach (var konto in kontoDic)
        //{
        //    if (konto.Value.Inhaber.Name == name)
        //    {
        //        returnList.Add(konto.Value);
        //    }
        //}

        return returnList;
    }

    private static void Main(string[] args)
    {
        int kontoNr = 0;
        Konto? konto = null;
        string auswahl = "";

        Console.WriteLine("Banksystem");

        while (auswahl != "q")
        {
            Console.WriteLine("\n#### Menue ####");
            Console.WriteLine("neues Konto erstellen (n)");
            Console.WriteLine("bestehendes Konto bearbeiten (b)");
            Console.WriteLine("Konto löschen (l)");
            Console.WriteLine("Alle Konten ausgeben (a)");
            Console.WriteLine("Programm beenden (q)\n");

            auswahl = Console.ReadLine() ?? string.Empty;

            Console.WriteLine();

            switch (auswahl)
            {
                case "n":
                    konto = new Konto();
                    kontoDic.Add(konto.Kontonummer, konto);
                    break;

                case "b":
                    Console.WriteLine("Name des Inhabers");
                    string name = Console.ReadLine() ?? string.Empty;
                    var konten = GetKontoFürInhaber(name);
                    if (konten == null || konten.Count == 0)
                    {
                        Console.WriteLine("Für diesen Inhaber gibt es keine Konten in userem System");
                        break;
                    }
                    AusgabeKonten(konten);
                    Console.WriteLine("Konto Nr des zu bearbeitenden Kontos?");

                    konto = null;
                    while (konto == null)
                    {
                        while (!int.TryParse(Console.ReadLine(), out kontoNr))
                        {
                            Console.WriteLine("Bitte eine gültige Nr eingeben");
                        }

                        konto = konten.FirstOrDefault(x => x.Kontonummer == kontoNr);

                        if (konto == null)
                        {
                            Console.WriteLine($"Das Konto mit der Nr: {kontoNr} wurde beim Kunden {name} nicht gefunden. Bitte richtige Kontonr eingeben.");
                        }
                    }
                    konto.Bearbeiten();

                    break;

                case "l":
                    Console.WriteLine("Konto Nr?");
                    while (!int.TryParse(Console.ReadLine(), out kontoNr))
                    {
                        Console.WriteLine("Bitte nur Zahlen eingeben");
                    }
                    if (!kontoDic.ContainsKey(kontoNr))
                    {
                        Console.WriteLine($"Das Konto mit der Nr {kontoNr} wurde nicht gefunden.");
                        break;
                    }
                    kontoDic.Remove(kontoNr);
                    Console.WriteLine("Konto wurde gelöscht");
                    break;

                case "a":
                    AusgabeKonten(kontoDic.Values.ToList());
                    break;

                case "q":
                    // "durchrutschen"
                    break;

                default:
                    Console.WriteLine("\nFalsche Eingabe\n");
                    break;
            }
        }
    }
}