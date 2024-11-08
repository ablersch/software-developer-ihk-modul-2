using System;

namespace Vererbung_virtual_override;

public abstract class Lebewesen
{
    // nur in den vererbenden Klassen verfügbar nicht von außerhalb
    protected int alter;

    protected Lebewesen()
    {
        alter = 5;
    }

    public int GetAlter()
    {
        return alter;
    }

    // Muss in den Kindklassen definiert werden
    public abstract string GetId();

    // Methode wird als überschreibbar gekennzeichnet
    public virtual void Output()
    {
        Console.WriteLine("Output Lebewesen");
    }
}