using System;

namespace Vererbung;

internal class Program
{
    private static void Main(string[] args)
    {
        Leiharbeiter leiharbeiter = new Leiharbeiter();
        Console.WriteLine(leiharbeiter.GetData());
        Console.WriteLine("");

        leiharbeiter = new Leiharbeiter("Ferchau");
        Console.WriteLine(leiharbeiter.GetData());

        leiharbeiter = new Leiharbeiter("Paul", "Orizon");
        Console.WriteLine(leiharbeiter.GetData());

        Console.ReadLine();
    }
}