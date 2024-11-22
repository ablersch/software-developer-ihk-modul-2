using System;

namespace Vererbung_virtual_override;

public class Mensch : Lebewesen
{
    public override void OutputId()
    {
        Console.WriteLine("Mensch-123");
    }
}