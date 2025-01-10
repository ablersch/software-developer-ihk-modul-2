using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Serilog;

namespace Medienverwaltung_Aufgabe_9;

internal class Program
{
    public static Dictionary<int, Medium> medienDic = [];
    private static readonly string dataFilePath = "data.json";

    private static readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true, // Für schön formatierten JSON-Ausgabe
        Converters =
        {
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) // Falls Enums existieren
        }
    };

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
    /// Ein Medium Objekt aus dem Dictionary liefern.
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

    private static void LoadData()
    {
        if (!File.Exists(dataFilePath))
        {
            Log.Warning($"Datei {dataFilePath} nicht vorhanden.");
            return;
        }

        try
        {
            medienDic = JsonSerializer.Deserialize<Dictionary<int, Medium>>(File.ReadAllText(dataFilePath), options);
        }
        catch (Exception e)
        {
            Log.Error(e, "Fehler beim deserialisieren.");
            return;
        }

        Console.WriteLine($"Daten wurden erfolgreich aus '{dataFilePath}' geladen.");
    }

    private static void Main()
    {
        CreateLogger();
        LoadData();

        Medium tempMedium;
        string auswahl = string.Empty;

        Console.WriteLine("Medienverwaltung");

        while (auswahl != "q")
        {
            Console.WriteLine("\n#### Menue ####");
            Console.WriteLine("Anlegen eines neuen Buch 'b'");
            Console.WriteLine("Anlegen eines neuen Video 'v'");
            Console.WriteLine("Anlegen eines neuen Tonie 't'");
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

                case "t":
                    tempMedium = new Tonie();
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
                        Console.WriteLine($"Medium mit der Signatur: {signatur} erfolgreich gelöscht.");
                    }
                    else
                    {
                        Log.Warning($"Signatur '{signatur}' nicht gefunden!");
                    }
                    break;

                case "q":
                    SaveData();
                    break;

                default:
                    Log.Information("Falsche Menüeingabe.");
                    Console.WriteLine();
                    break;
            }
        }
    }

    private static void SaveData()
    {
        try
        {
            // Serialisieren des Dictionaries in einen JSON-String
            string jsonString = JsonSerializer.Serialize(medienDic, options);

            // Speichern des JSON-Strings auf der Festplatte
            File.WriteAllText(dataFilePath, jsonString);
        }
        catch (NotSupportedException ne)
        {
            Log.Error(ne, "Fehler beim deserialisieren.");
        }
        catch (Exception e)
        {
            Log.Error(e, $"Fehler beim schreiben der Daten in '{dataFilePath}'.");
            return;
        }
        Console.WriteLine($"Daten wurden erfolgreich in '{dataFilePath}' gespeichert.");
    }
}