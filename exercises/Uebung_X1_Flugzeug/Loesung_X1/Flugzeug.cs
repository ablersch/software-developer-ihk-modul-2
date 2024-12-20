using System;
using System.Threading;

namespace Flugzeug;

internal class Flugzeug
{
    public Flugzeug()
    {
        AktuelleGeschwindigkeit = 0;
        Gelandet = false;
    }

    public int AktuelleGeschwindigkeit { get; set; }

    public bool Gelandet { get; set; }

    public void Beschleunigen(int geschwindigkeit)
    {
        for (int i = AktuelleGeschwindigkeit; i <= geschwindigkeit; i++)
        {
            Console.Write($"\rFlugzeug beschleunigt auf {i} km/h");
            Thread.Sleep(80);
        }
        AktuelleGeschwindigkeit = geschwindigkeit;
    }

    public void Bremsen(int geschwindigkeit)
    {
        if (AktuelleGeschwindigkeit != geschwindigkeit)
        {
            for (int i = AktuelleGeschwindigkeit; i >= geschwindigkeit; i--)
            {
                Console.Write($"\rFlugzeug reduziert auf {i} km/h");
                Thread.Sleep(80);
            }
            if (geschwindigkeit == 0)
            {
                Gelandet = true;
                Console.WriteLine("\nFlugzeug gelandet");
            }
            AktuelleGeschwindigkeit = geschwindigkeit;
        }
        else
        {
            Console.WriteLine($"Fliegt schon mit {geschwindigkeit} km/h");
        }
    }
}