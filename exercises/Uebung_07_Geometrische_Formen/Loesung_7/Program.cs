using System;
using System.Collections.Generic;

namespace GeometrischeFormen;

internal class Program
{
    private static void Main()
    {
        var formen = new List<Form>
        {
            new Rechteck { Name = "Rechteck1", Laenge = 5, Breite = 3 },
            new Rechteck { Name = "Rechteck2", Laenge = 7, Breite = 2 },
            new Kreis { Name = "Kreis1", Radius = 4 },
            new Kreis { Name = "Kreis2", Radius = 24 },
        };

        foreach (var form in formen)
        {
            Console.WriteLine($"{form.Name} hat eine Fläche von {form.BerechneFlaeche()}.");
        }
    }
}