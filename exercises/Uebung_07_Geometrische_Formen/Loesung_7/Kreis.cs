using System;

namespace GeometrischeFormen;

internal sealed class Kreis : Form
{
    private double radius;

    public double Radius
    {
        get
        {
            return radius;
        }
        set
        {
            if (value > 0)
            {
                radius = value;
            }
            else
            {
                Console.WriteLine("Keine negativen Werte erlaubt.");
            }
        }
    }

    public override double BerechneFlaeche()
    {
        return Math.Round(Math.PI * (Radius * Radius), 2);
    }
}