using System;
using System.Collections.Generic;
using Serilog;

namespace Medienverwaltung_Aufgabe_7;

internal class Program
{
    public static Dictionary<int, Medium> medienDic = new Dictionary<int, Medium>();

    private static void CreateLogger()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt",
                rollingInterval: RollingInterval.Day,
                rollOnFileSizeLimit: true)
            .CreateLogger();
    }

    /// <summary>
    /// Gibt ein Medium Objekt aus dem Dictionary
    /// </summary>
    /// <param name="key">Signatur</param>
    /// <returns>Medien Objekt; Bei Fehler null</returns>
    private static Medium GetElement(int key)
    {
        if (medienDic.TryGetValue(key, out var medium))
        {
            return medium;
        }
        else
        {
            Log.Warning($"Signatur '{key}' nicht gefunden!");
            return null;
        }
    }

    private static void Main()
    {
        CreateLogger();

        Medium tempMedium;
        string auswahl = string.Empty;

        Console.WriteLine("Medienverwaltung");

        while (auswahl != "q")
        {
            Console.WriteLine("\n#### Menue ####");
            Console.WriteLine("Anlegen eines neuen Buch 'b'");
            Console.WriteLine("Anlegen eines neuen Video 'v'");
            Console.WriteLine("Ausgabe der vorhandenen Medien 'a'");
            Console.WriteLine("Entleihen des Medium 'e Signatur'");
            Console.WriteLine("Rueckgabe des Medium 'r Signatur'");
            Console.WriteLine("Löschen des Medium 'l Signatur'");
            Console.WriteLine("Programm beenden 'q'\n");

            auswahl = Console.ReadLine();
            int signatur = 0;
            if (auswahl.Length > 5 && auswahl.Contains(' '))
            {
                string[] temp = auswahl.Split(' ');
                auswahl = temp[0];
                if (!int.TryParse(temp[1], out signatur))
                {
                    Log.Information("Keine gültige Signatur eingegeben");
                    continue;
                }
            }

            Console.WriteLine();
            switch (auswahl)
            {
                case "b":
                    tempMedium = new Buch();
                    medienDic.Add(tempMedium.Signatur, tempMedium);
                    break;

                case "v":
                    tempMedium = new Video();
                    medienDic.Add(tempMedium.Signatur, tempMedium);
                    break;

                case "a":
                    if (medienDic.Count > 0)
                    {
                        Medium.AusgabeUeberschrift();
                    }
                    foreach (var medium in medienDic)
                    {
                        medium.Value.Ausgabe();
                    }
                    break;

                case "e":
                    tempMedium = GetElement(signatur);
                    tempMedium?.Entleihen();
                    break;

                case "r":
                    tempMedium = GetElement(signatur);
                    tempMedium?.Rueckgabe();
                    break;

                case "l":
                    if (medienDic.Remove(signatur))
                    {
                        Console.WriteLine($"Medium mit der Signatur '{signatur}' erfolgreich gelöscht.");
                    }
                    else
                    {
                        Log.Warning($"Signatur '{signatur}' nicht gefunden!");
                    }
                    break;

                case "q":
                    // "durchrutschen"
                    break;

                default:
                    Log.Information("Falsche Menüeingabe.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}