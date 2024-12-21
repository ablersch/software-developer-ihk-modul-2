# Serialisieren und Deserialisieren 

Daten umwandeln

---

<!-- .slide: class="left" -->
## Serialisieren und Deserialisieren

Beim Serialisieren und Deserialisieren von JSON in C\# geht es darum, Daten zwischen Objekten in einem Programm und JSON-Daten umzuwandeln. 

---

<!-- .slide: class="left" -->
## JSON Serialisierung

Das Serialisieren bedeutet, ein C\#-Objekt in einen JSON-String umzuwandeln. Dies wird verwendet, um Daten in einem strukturierten, leicht lesbaren Format zu speichern oder zu übertragen.

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

Das Deserialisieren bedeutet, einen JSON-String zurück in ein C\#-Objekt umzuwandeln. Dies ist nützlich, um Daten, die z. B. von einer API als JSON zurückgegeben werden, in einem Programm weiterzuverarbeiten.

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
## Voraussetzungen

* Nur Properties können serialisiert werden
* Es wird ein parameterloser Konstruktor benötigt
* Oder ein Konstruktur mit genau so vielen Parametern wie die JSON Daten
* Ein Konstuktor welcher mit `[JsonConstructor]` markiert ist

Note:
* `[JsonConstructor]` erlaubt einen bestimmten Konstruktor explizit für die Deserialisierung anzugeben, auch wenn er mehrere Parameter hat oder es mehrere Konstuktoren gibt

---

<!-- .slide: class="left" -->
## Vererbungshierarchien beim serialisieren

Um die Vererbungshierarchien bei der Serialisierung und Deserialisierung von Objekten zu unterstützen wird das Attribut `[JsonDerivedType]` benötigt.

Es ermöglicht, eine Basisklasse und ihre abgeleiteten Klassen so zu kennzeichnen, dass der Typ der Objekte zur Laufzeit korrekt erkannt wird.

```csharp
[JsonDerivedType(typeof(Buch), "Buch")]
[JsonDerivedType(typeof(Video), "Video")]
public abstract class Medium
{
    public int Signatur { get; set; }
    public string Titel { get; set; }
}
```

Note: 
Wenn man eine Basisklasse wie `Medium` und abgeleitete Klassen wie `Buch` oder `Film` hat, benötigt der Deserialisierungsprozess eine Möglichkeit, den konkreten Typ des Objekts zu identifizieren.

---

<!-- .slide: class="left" -->
## abgeleitete Klassen serialisieren

Beim Serialisieren fügt `System.Text.Json` das im Attribut definierte Kennzeichen ("Buch" oder "Film") als Typinformationen hinzu.

```csharp
var medium = new Buch { Signatur = 1, Titel = "Mein Buch", Autor = "Max Mustermann" };
string json = JsonSerializer.Serialize(medium);

// Ergebnis:
{
  "$type": "Buch",
  "Signatur": 1,
  "Titel": "Mein Buch",
  "Autor": "Max Mustermann"
}
```

Note:
* Bei der Deserialisierung wird das `$type`-Feld ausgewertet, und das System entscheidet basierend darauf, welche abgeleitete Klasse instanziiert werden soll.
* In **VS** zeigen Beispiel "121_Serialisieren_Deserialisieren"
  * `JsonDerivedType` bei abstrakter Klasse
  * [JsonConstructor] bei Tier-Konstruktor ohne Eingabe

---

<!-- .slide: class="left" -->
## Vorteile der JSON-Serialisierung

* JSON ist leichtgewichtig und gut lesbar.
* Es ist plattformunabhängig und wird in vielen Sprachen unterstützt.
* JSON-Serialisierung in C# ist effizient und direkt in der `System.Text.Json`-Bibliothek integriert (seit .NET Core 3.0).

Für fortgeschrittene Anwendungsfälle kann man auch Einstellungen beim Serialisieren und Deserialisieren verwenden, um z. B. benutzerdefinierte Regeln zu definieren, wie Daten formatiert werden.

Note: 
```csharp
private static readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true, // Für schön formatierten JSON-Ausgabe
        Converters =
        {
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) // Falls Enums existieren
        }
    };
```
**ÜBUNG** Medienverwaltung Aufgabe 8