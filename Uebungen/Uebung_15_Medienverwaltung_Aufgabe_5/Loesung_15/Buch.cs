using System;

namespace Medienverwaltung_Aufgabe_5
{
    class Buch : Medium
    {
        private int seitenzahl;

        public Buch()
        {
            typ = TypBezeichnung.Buch;
            
            Console.WriteLine("Seitenzahl eingeben:");
            while (!Int32.TryParse(Console.ReadLine(), out seitenzahl) )
            {
                Console.WriteLine("Seitenzahl nicht gültig. Bitte nur ganze Zahlen eingeben:");
            }
        }

        internal void Ausgabe()
        {
            Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} Seitenzahl {4,-12}", signatur, typ, (titel.Length > 12) ? titel.Substring(0, 12) : titel, leihstatus, seitenzahl);
        }
    }
}
