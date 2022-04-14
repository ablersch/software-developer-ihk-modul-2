using System;

namespace Cast
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 2;
            double d = 4.4;
            d = i;

            //i = d;


            Fahrzeug fahr = new Fahrzeug();
            Auto pkw = new Auto();

            // Zuweisung ist ok, da Vererbung besteht
            fahr = pkw;
            // Cast notwendig
            //pkw = fahr;

            // Zuweisung an Object möglich da alles von Object erbt
            Object objTemp = new Auto();

            // nicht möglich
            //Tier tier = new Auto();

            objTemp = new Tier();

            // Prüfung ob Cast möglich
            if (objTemp is Object) {
                Console.WriteLine("Ist Object");
            }
            if (objTemp is Fahrzeug)
            {
                Console.WriteLine("Ist Fahrzeug");
            }
            if (objTemp is Tier)
            {
                Console.WriteLine("Ist Tier");
            }

            // Alternative Cast mit as 
            Tier biber = objTemp as Tier;
            if (biber != null) // Cast erfolgreich
            { }

            // Alternative
            biber = (Tier)objTemp;

            // Nicht möglich, Fehler
            pkw = objTemp as Auto;
            if (pkw != null) { }
        }
    }

    class Fahrzeug
    {
        public string antrieb;
    }


    class Auto : Fahrzeug
    {
        public string treibstoff;
    }

    class Tier
    {
        public string name;
    }
}
