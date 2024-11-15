using System;

namespace Sekundenspeicher;

internal class Program
{
    private static void Main()
    {
        Second second = new();

        Console.WriteLine("Sekunden eingeben:");
        var input = Console.ReadLine();

        if (ulong.TryParse(input, out ulong secondsValue))
        {
            second.Seconds = secondsValue;
        }
        else
        {
            // Keine Zahl eingegeben. Das Programm wird beendet
            Environment.Exit(0);
        }

        Console.WriteLine($"\nSekunden: {second.Seconds}");
        Console.WriteLine($"Minuten: {second.Minutes}");
        Console.WriteLine($"Stunden: {second.Hours}");
        Console.WriteLine($"Tage: {second.Days}");

        Console.WriteLine("\nErweitert:");
        Console.WriteLine(second.StringWithRest());
    }
}