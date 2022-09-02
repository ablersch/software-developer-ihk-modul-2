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

        /////////////////////////////////
        // Text schreiben
        // Datei wird automatisch erstellt
        using (var writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine("Schreibe das in die Datei");
        }

        File.Delete(logFilePath);

        var fileInfo = new FileInfo(logFilePath);
        var writer2 = fileInfo.AppendText();
        writer2.WriteLine("### Schreibe Text in die LogDatei ###");
        writer2.WriteLine("### Schreibe Text in die LogDatei  2###");
        writer2.Close();

        // Prüfen ob Datei existiert
        if (!File.Exists(logFilePath))
        {
            File.Create(logFilePath);
        }

        //////////////////////////////////
        // Text einlesen
        // using declaration syntax
        using StreamReader reader = new(logFilePath);

        // alle Zeichen einlesen
        einlesen = reader.ReadToEnd();

        // ließt eine Zeile
        // einlesen = reader.ReadLine();

        Console.WriteLine(einlesen);

        // Dateiinfos ausgeben
        Console.WriteLine("Erstellungszeitpunkt: \t" + fileInfo.CreationTime);
        Console.WriteLine("Letzte Änderung: \t" + fileInfo.LastWriteTime);
        Console.WriteLine("Größe in Byte: \t\t" + fileInfo.Length);

        Console.ReadLine();
    }
}