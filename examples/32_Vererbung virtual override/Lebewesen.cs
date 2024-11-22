using System;

namespace Vererbung_virtual_override;

public abstract class Lebewesen
{
    // nur in den vererbenden Klassen verfügbar nicht von außerhalb
    protected int alter;

    protected Lebewesen()
    {
        Console.WriteLine("Lebewesen Konstruktor");
        alter = 5;
    }

    // Methode wird als überschreibbar gekennzeichnet.
    // Kann bei Bedarf überschrieben/angepasst werden
    public virtual void Output()
    {
        Console.WriteLine("Output Lebewesen");
    }

    // Muss in allen Kindklassen definiert werden
    public abstract void OutputId();
}