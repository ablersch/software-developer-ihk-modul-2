using System;

namespace Intervall;

internal class Program
{
    private static void Main()
    {
        var myIntervall = new Intervall(111, 11);
        myIntervall.Output("Werte:");

        Console.WriteLine($"Intervallgroesse: \n{myIntervall.Size()} ");

        Console.WriteLine($"\nMittelwert: \n{myIntervall.Avg()} \n");

        myIntervall.Move(10);
        myIntervall.Output("Verschiebung: ");

        myIntervall.Scale(10);
        myIntervall.Output($"{nameof(myIntervall.Scale)}:");
    }
}