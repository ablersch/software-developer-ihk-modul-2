using System;

namespace Vererbung_virtual_override;

public class Program
{
    private static void Main(string[] args)
    {
        Lebewesen lebeObjekt;
        // Fehler da Klasse abstract ist -> kein erstellen einer Instanz möglich
        //lebeObjekt = new Lebewesen();

        // Aufruf abfolge?
        Tier tierObjekt = new Tier();

        // Zuweisung erlaubt da von Basisklasse abgeleitet
        lebeObjekt = tierObjekt;

        // es wird immer die letzte überschriebene Methode aufgerufen
        tierObjekt.Output();
        lebeObjekt.Output();

        tierObjekt.GetAlter();
        lebeObjekt.GetAlter();

        lebeObjekt.GetId();

        Mensch menschObj = new Mensch();
        menschObj.Output();
        menschObj.GetAlter();
        menschObj.GetId();

        Console.ReadLine();
    }
}