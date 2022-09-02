using System;

namespace Vererbung_virtual_override;

public sealed class Tier : Lebewesen
{
    // Muss implementiert werden, da dies in der Baisklasse mit "abstract" vorgegeben wurde
    public override string GetId()
    {
        Random r = new Random();
        var x = r.Next(0, 100);
        return "Tier-" + x;
    }

    // Methode der Basisklasse wird überschrieben
    public override void Output()
    {
        alter = 5;
        Console.WriteLine("Output Tier (überschrieben)");
        GetAlter();
    }
}
