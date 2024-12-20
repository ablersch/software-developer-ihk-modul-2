using System;
using System.IO;

namespace Dateioperationen;

internal class Program
{
    private static readonly string logFilePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\LogFile.txt";

    private static void Main()
    {
        string einlesen;

        Console.WriteLine($"Datei: {logFilePath}");

        if (!File.Exists(logFilePath))
        {
            Console.WriteLine($"Datei {logFilePath} existiert nicht.");
        }
        File.WriteAllText(logFilePath, "Text in die Datei schreiben.");
        File.Delete(logFilePath);

        // Text schreiben, Datei wird automatisch erstellt
        using (var writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine("Schreibe das in die Datei");
        }

        // Text einlesen
        using StreamReader reader = new(logFilePath);

        // alle Zeichen einlesen
        einlesen = reader.ReadToEnd();

        // ließt eine Zeile
        // einlesen = reader.ReadLine();

        var fileInfo = new FileInfo(logFilePath);

        using var fileInfoWriter = fileInfo.AppendText();
        fileInfoWriter.WriteLine("### Schreibe Text in die LogDatei ###");

        // Dateiinfos ausgeben
        Console.WriteLine("Erstellungszeitpunkt: \t" + fileInfo.CreationTime);
        Console.WriteLine("Letzte Änderung: \t" + fileInfo.LastWriteTime);
        Console.WriteLine("Größe in Byte: \t\t" + fileInfo.Length);
    }
}