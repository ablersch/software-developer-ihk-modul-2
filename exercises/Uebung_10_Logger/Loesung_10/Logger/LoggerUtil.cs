using System;
using System.IO;

namespace Logger;

public static class LoggerUtil
{
    // 5MB  -> 5 byte * 1024 = kbyte * 1024 = mbyte
    private const int maxLogSize = 5242880;

    public enum LogTyp
    {
        Debug,
        Information,
        Warning,
        Critical,
        Error
    };

    public static string FilePath { get; private set; }

    private static string FolderPath { get; set; }

    /// <summary>
    /// Pfad und Dateiname für die Logdatei setzen.
    /// Ordner wird erstellt wenn er nicht existiert.
    /// </summary>
    /// <param name="folderPath">Ordner wo die Logdatei gespeichert wird</param>
    /// <param name="fileName">Name der Logdatei</param>
    public static void Init(string folderPath, string fileName)
    {
        FolderPath = string.IsNullOrEmpty(folderPath) ? AppContext.BaseDirectory : folderPath;

        try
        {
            // Verzeichnis erstellen, falls nicht vorhanden
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }

        // Prüfen ob eine Dateiendung angegeben wurde
        if (fileName.Contains('.'))
        {
            FilePath = Path.Combine(FolderPath, fileName);
        }
        else
        {
            // Wenn nicht Endung auf txt setzen
            FilePath = Path.Combine(FolderPath, fileName + ".txt");
        }
    }

    /// <summary>
    /// Write log files
    /// </summary>
    /// <param name="logText">Log message</param>
    /// <param name="logTyp">Enum typ</param>
    public static void WriteToLog(string logText, LogTyp logTyp)
    {
        bool deleteFile = false;
        try
        {
            if (!string.IsNullOrWhiteSpace(FilePath))
            {
                // Neuer Eintrag mit Zeit, LogTyp und Text
                logText = $"{DateTime.Now} - {logTyp}: {logText}";

                // Datei erstellen, falls nicht vorhanden
                using var writer = new StreamWriter(FilePath, true);

                writer.WriteLine(logText);

                // StreamWriter schreibt nicht sofort
                writer.Flush();

                if (writer.BaseStream.Length > maxLogSize)
                {
                    // löschen direkt nicht möglich da Datei noch vom StreamWriter geöffnet ist!!
                    deleteFile = true;
                }

                if (deleteFile)
                {
                    File.Delete(FilePath);
                }
            }
            else
            {
                Console.WriteLine("Bitte zuerst den Pfad und die Logdatei festlegen.");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Fehler beim schreiben. Fehler: {e.Message}.");
        }
    }
}