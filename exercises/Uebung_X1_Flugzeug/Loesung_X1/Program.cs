using System;

namespace Flugzeug;

internal class Program
{
    private static void Main()
    {
        var flugzeug = new Flugzeug();

        Console.WriteLine("Zum landen: 0 km/h eingeben");
        Console.WriteLine("Zum Starten: beliebige ganze Zahl eingeben");

        while (!flugzeug.Gelandet)
        {
            Console.Write("\nGeschwindigkeit eingeben:");
            if (int.TryParse(Console.ReadLine(), out int geschwindigkeit))
            {
                if (flugzeug.AktuelleGeschwindigkeit < geschwindigkeit)
                {
                    flugzeug.Beschleunigen(geschwindigkeit);
                }
                else
                {
                    // Bremsen und neue Geschwindkeit gleich aktuelle Geschwindigkeit
                    flugzeug.Bremsen(geschwindigkeit);
                }
            }
            else
            {
                Console.WriteLine("Bitte ganze Zahl eingeben");
            }
        }

        Console.ReadLine();
    }
}