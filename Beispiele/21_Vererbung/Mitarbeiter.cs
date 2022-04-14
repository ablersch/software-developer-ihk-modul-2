using System;

namespace Vererbung
{
    class Mitarbeiter
    {
        // nur in dieser Klassen verfügbar nicht von außerhalb
        private string name;

        public Mitarbeiter() 
        {
            Console.WriteLine("Name des Leiharbeiters");
            name = Console.ReadLine();
        }

        public Mitarbeiter(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
    }
}
