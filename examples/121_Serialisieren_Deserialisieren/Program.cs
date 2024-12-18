using System.Collections.Generic;
using System.Text.Json;

namespace Serialisieren_Deserialisieren;

public class Program
{
    private static void Main(string[] args)
    {
        Mensch menschObj = new()
        {
            Alter = 20,
            Wohnort = "Ulm"
        };

        Tier tierObj = new()
        {
            Alter = 10,
            Art = "Reptil"
        };

        var lebewesen = new List<Lebewesen>
        {
            menschObj,
            tierObj
        };

        var jsonString = JsonSerializer.Serialize(lebewesen);

        var list = JsonSerializer.Deserialize<List<Lebewesen>>(jsonString);
    }
}