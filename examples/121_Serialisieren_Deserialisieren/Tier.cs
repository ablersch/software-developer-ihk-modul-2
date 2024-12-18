using System;
using System.Text.Json.Serialization;

namespace Serialisieren_Deserialisieren;

public sealed class Tier : Lebewesen
{
    public Tier()
    {
        Console.WriteLine("Art eingeben:");
        Art = Console.ReadLine();
    }

    [JsonConstructor]
    public Tier(string art)
    {
        Art = art;
    }

    public string Art { get; set; }
}