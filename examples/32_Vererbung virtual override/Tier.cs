using System;

namespace Vererbung_virtual_override;

public sealed class Tier : Lebewesen
{
    public Tier()
    {
        Console.WriteLine("Tier Konstruktor");
        alter = 10;
    }

    // Methode der Basisklasse wird überschrieben
    public override void Output()
    {
        Console.WriteLine("Output Tier");
    }

    // Muss implementiert werden, da dies in der Baisklasse mit "abstract" vorgegeben wurde
    public override void OutputId()
    {
        Random r = new Random();
        var x = r.Next(0, 100);
        Console.WriteLine($"Tier-{x}");
    }
}