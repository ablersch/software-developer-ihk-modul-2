using System.Text.Json.Serialization;

namespace Serialisieren_Deserialisieren;

[JsonDerivedType(typeof(Mensch), "Mensch")]
[JsonDerivedType(typeof(Tier), "Tier")]
public abstract class Lebewesen
{
    protected Lebewesen()
    {
    }

    public int Alter { get; set; }
}