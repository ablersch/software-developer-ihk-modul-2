using System;

namespace GeometrischeFormen;

internal sealed class Rechteck : Form
{
    private double breite;
    private double laenge;

    public double Breite
    {
        get
        {
            return breite;
        }
        set
        {
            if (value > 0)
            {
                breite = value;
            }
            else
            {
                Console.WriteLine("Keine negativen Werte erlaubt.");
            }
        }
    }

    public double Laenge
    {
        get
        {
            return laenge;
        }
        set
        {
            if (value > 0)
            {
                laenge = value;
            }
            else
            {
                Console.WriteLine("Keine negativen Werte erlaubt.");
            }
        }
    }

    public override double BerechneFlaeche()
    {
        return Laenge * Breite;
    }
}