using System;
using System.IO;

namespace Dateien_ausgeben;

internal class Program
{
    private static void DateiAusgabe(FileInfo fileInfo)
    {
        // Bytes in KB umrechnen ohne das Nachkommastellen verloren gehen
        float lengthInKb = fileInfo.Length / 1024f;

        Console.WriteLine($"Datei: {fileInfo.FullName}");
        Console.WriteLine($"Größe [KB]: {lengthInKb} Erstelldatum: {fileInfo.CreationTime.ToShortDateString()} letzte Änderung: {fileInfo.LastWriteTime}");
        Console.WriteLine();

        try
        {
            using var streamReader = fileInfo.OpenText();

            string line;
            // Solange lesen, solange nicht null zurück kommt
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.Contains("Error"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (line.Contains("Warning"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (line.Contains("Information"))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    // Normal, ohne Farbe ausgeben
                    Console.ResetColor();
                }

                Console.WriteLine(line);
            }
            Console.ResetColor();
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void Main(string[] args)
    {
        // Prüfen ob Befehlszeilenargumente vorhanden sind
        if (args.Length > 0)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("\n---------------");

                FileInfo fileInfo = new(args[i]);

                if (fileInfo.Exists)
                {
                    if (fileInfo.Extension == ".log" || fileInfo.Extension == ".txt")
                    {
                        DateiAusgabe(fileInfo);
                    }
                    else
                    {
                        Console.WriteLine($"Die Endung {fileInfo.Extension} wird nicht unterstützt.");
                    }
                }
                else
                {
                    Console.WriteLine($"Die Datei {fileInfo.FullName} existiert nicht.");
                }
            }
        }
        else
        {
            Console.WriteLine("Kein(e) Parameter mitgegeben.");
        }
    }
}