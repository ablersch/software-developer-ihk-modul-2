﻿using System;

namespace Cast;

internal class Auto : Fahrzeug
{
    public string treibstoff;
}

internal class Fahrzeug
{
    public string antrieb;
}

internal class Tier
{
    public string name;
}

internal class Program
{
    private static void Main(string[] args)
    {
        int i = 2;
        double d = 4.4;
        d = i;
        //i = d;

        Fahrzeug fahrzeug = new Fahrzeug();
        Auto pkw = new Auto();

        // Zuweisung ist ok, da Vererbung besteht
        fahrzeug = pkw;

        // Cast notwendig
        //pkw = fahrzeug;

        // Zuweisung an Object möglich da alles von Object erbt
        Object objTemp = new Auto();

        // nicht möglich
        //Tier tier = new Auto();

        objTemp = new Tier();

        // Prüfung ob Cast möglich
        // Alles erbt von Object
        if (objTemp is Object)
        {
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
        if (pkw != null)
        {
        }
    }
}