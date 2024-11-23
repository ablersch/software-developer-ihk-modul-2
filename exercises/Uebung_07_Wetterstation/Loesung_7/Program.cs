using System;
using System.Collections.Generic;

namespace Wetterstation;

internal class Program
{
    private static void Main()
    {
        var station = new List<Wetter>
        {
            new Wetter("Station Scott", -55, -2, 800, 0),
            new Wetter("Station Tunis", 115, 30, 1030, 0),
            new Wetter("Station Wien", 15, 70, 930, 3)
        };

        Console.WriteLine("Messbereiche der Wetterstationen");
        Console.WriteLine("Temperatur: - 80 bis + 80 Grad Celsius Luftfeuchtigkeit: 0 bis 100 Prozent");
        Console.WriteLine("Druck: 700 hPa bis 1500 hPa Niederschlag: 0 bis 100 Liter");

        Console.WriteLine();

        foreach (var wetter in station)
        {
            Console.WriteLine($"{wetter.StationsName} Temperatur: {wetter.Temperatur} Feuchtigkeit: {wetter.Luftfeuchtigkeit} " +
                $"Luftdruck: {wetter.Luftdruck} Regenmenge: {wetter.Regenmenge}");
        }
    }
}