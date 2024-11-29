# Serialisieren und Deserialisieren 

Daten umwandeln

---

<!-- .slide: class="left" -->
## Serialisieren und Deserialisieren

Beim Serialisieren und Deserialisieren von JSON in C# geht es darum, Daten zwischen Objekten in einem Programm und JSON-Daten (JavaScript Object Notation) umzuwandeln. 

---

<!-- .slide: class="left" -->
## JSON Serialisierung

Das Serialisieren bedeutet, ein C#-Objekt in einen JSON-String umzuwandeln. Dies wird verwendet, um Daten in einem strukturierten, leicht lesbaren Format zu speichern oder zu übertragen.

```csharp
using System.Text.Json;

public class Person
{
    public string Vorname { get; set; }
    public string Nachname { get; set; }
    public int Alter { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        var person = new Person
        {
            Vorname = "Max",
            Nachname = "Mustermann",
            Alter = 30
        };

        // Serialisierung
        string jsonString = JsonSerializer.Serialize(person);
        Console.WriteLine(jsonString); // Ausgabe: {"Vorname":"Max","Nachname":"Mustermann","Alter":30}
    }
}
```

---

<!-- .slide: class="left" -->
## JSON Deserialisierung

Das Deserialisieren bedeutet, einen JSON-String zurück in ein C#-Objekt umzuwandeln. Dies ist nützlich, um Daten, die z. B. von einer API als JSON zurückgegeben werden, in einem Programm weiterzuverarbeiten.

```csharp
using System.Text.Json;

public class Person
{
    public string Vorname { get; set; }
    public string Nachname { get; set; }
    public int Alter { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        string jsonString = "{\"Vorname\":\"Max\",\"Nachname\":\"Mustermann\",\"Alter\":30}";

        // Deserialisierung
        Person person = JsonSerializer.Deserialize<Person>(jsonString);
        Console.WriteLine($"{person.Vorname} {person.Nachname}, Alter: {person.Alter}");
        // Ausgabe: Max Mustermann, Alter: 30
    }
}
```

---

<!-- .slide: class="left" -->
## Vorteile der JSON-Serialisierung

* JSON ist leichtgewichtig und gut lesbar.
* Es ist plattformunabhängig und wird in vielen Sprachen unterstützt.
* JSON-Serialisierung in C# ist effizient und direkt in der `System.Text.Json`-Bibliothek integriert (seit .NET Core 3.0).

Für fortgeschrittene Anwendungsfälle kannst man auch Einstellungen beim Serialisieren und Deserialisieren verwenden, um z. B. benutzerdefinierte Regeln zu definieren, wie Daten formatiert werden.

Note: 
**ÜBUNG** Medienverwaltung Aufgabe 8