using System;
using System.Collections.Generic;

namespace GeometrischeFormen;

internal class Program
{
    private static void Main()
    {
        var rechtecke = new List<Rechteck>
        {
            new Rechteck { Name = "Rechteck1", Laenge = 5, Breite = 3 },
            new Rechteck { Name = "Rechteck2", Laenge = 7, Breite = 2 },
        };

        var kreise = new List<Kreis>
        {
            new Kreis { Name = "Kreis1", Radius = 4 },
            new Kreis { Name = "Kreis2", Radius = 24 },
        };

        foreach (var rechteck in rechtecke)
        {
            Console.WriteLine($"{rechteck.Name} hat eine Fläche von {rechteck.BerechneFlaeche()}.");
        }
        foreach (var kreis in kreise)
        {
            Console.WriteLine($"{kreis.Name} hat eine Fläche von {kreis.BerechneFlaeche()}.");
        }
    }
}