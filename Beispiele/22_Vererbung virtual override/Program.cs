using System;

namespace Vererbung_virtual_override {

    class Program {

        static void Main(string[] args)
        {
            Lebewesen lebeObjekt;
            // Fehler da Klasse abstract ist -> kein erstellen einer Instanz möglich
            // lebeObjekt = new Lebewesen();

            // Aufruf abfolge?
            Tier tierObjekt = new Tier();

            // Zuweisung erlaubt da von Basisklasse abgeleitet
            lebeObjekt = tierObjekt;

            // es wird immer die letzte überschriebene Methode aufgerufen
            tierObjekt.Output();
            lebeObjekt.Output();

            tierObjekt.GetAlter();
            lebeObjekt.GetAlter();

            Console.ReadLine();
        }
    }



    abstract class Lebewesen
    {
        // nur in den vererbenden Klassen verfügbar nicht von außerhalb
        protected int alter;

        // Muss in den Kindklassen definiert werden
        public abstract string GetId();

        public Lebewesen() 
        {
            alter = 5;
        }

        public int GetAlter()
        {
            return alter;
        }

        // Methode wird als überschreibbar gekennzeichnet
        public virtual void Output()
        {
            Console.WriteLine("Output Lebewesen");
        }
    }


    sealed class Tier : Lebewesen
    {
        // Methode der Basisklasse wird überschrieben
        public override void Output()
        {
            alter = 5;
            Console.WriteLine("Output Tier (überschrieben)");
            GetAlter();
        }

        // Muss implementiert werden, da dies in der Baisklasse mit "abstract" vorgegeben wurde
        public override string GetId()
        {
            Random r = new Random();
            var x = r.Next(0, 100);
            return "Tier-" + x;
        }
    }


    class Mensch : Lebewesen
    {
        public override string GetId()
        {
            return "Mensch-123";
        }
    }
}
