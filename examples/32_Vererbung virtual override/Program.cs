using System;

namespace Vererbung_virtual_override;

public class Program
{
    private static void Main(string[] args)
    {
        // Aufruf abfolge?
        Mensch menschObj = new Mensch();
        menschObj.Output();
        menschObj.OutputId();

        Console.WriteLine();

        // Aufruf abfolge?
        Tier tierObjekt = new Tier();
        tierObjekt.Output();
        tierObjekt.OutputId();
        // Wert von Alter?

        Console.WriteLine();

        Lebewesen lebeObjekt;
        // Fehler da Klasse abstract ist -> kein erstellen einer Instanz möglich
        //lebeObjekt = new Lebewesen();

        // Zuweisung erlaubt da von Basisklasse abgeleitet
        lebeObjekt = tierObjekt;
        lebeObjekt.Output();
        lebeObjekt.OutputId();
    }
}