# Dateioperationen und DLLs

Mit Dateien arbeiten, DLLs erstellen und nutzen

---

<!-- .slide: class="left" -->
## `using`-Anweisung

Das [`using`](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/keywords/using-statement)-Statement wird verwendet, um sicherzustellen, dass Ressourcen ordnungsgemäß freigegeben werden, sobald sie nicht mehr benötigt werden. Es ist besonders wichtig für Objekte, die das `IDisposable`-Interface implementieren, wie z. B. Streams, Datenbankverbindungen oder Dateien.

`using` definiert einen Bereich in welchem das in der Anweisung definierte Objekt Gültigkeit hat. Das Objekt wird, nachdem der Gültigkeitsbereich verlassen wird, automatisch verworfen (`Dispose()`).

Note:
* Automatische Ressourcenfreigabe, auch bei Exceptions.
* Einfacher zu lesen und sicherer als das manuelle Aufrufen von `Dispose`.

---

<!-- .slide: class="left" -->
## Was macht `Dispose`?

[`Dispose()`](https://docs.microsoft.com/de-de/dotnet/standard/garbage-collection/implementing-dispose) wird verwendet, um Ressourcen (z. B. Dateien, Netzwerkverbindungen, Speicherpuffer) zu bereinigen.

* `Dispose` ist eine Methode, die vom `IDisposable`-Interface definiert wird.
* Sie wird aufgerufen, um explizit nicht verwaltete Ressourcen (z. B. Dateihandles, Netzwerkressourcen) freizugeben.
* Wenn ein Objekt nicht korrekt "disposed" wird, kann es zu Ressourcenlecks kommen, da diese Ressourcen außerhalb der Garbage Collection liegen.

Note: 
* Möglichkeit Ressourcen frei zu geben
* Bei `Dispose()` wird das Objekt zurückgesetzt d.h. ein weiteres Öffnen der Verbindung ist nicht möglich.

---

<!-- .slide: class="left" -->
## Das alte `using`-Statement

Im Anweisungsblock wird das zu verwendende Objekt initialisiert.

```csharp
// Objekt erstellen
using (var writer = new StreamWriter("example.txt"))
{
    writer.WriteLine("Hello, World!");
    // Nach diesem Block wird writer.Dispose() automatisch aufgerufen.
}
```

---

<!-- .slide: class="left" -->
## Das neue `using`-Statement

Seit C# 8.0 gibt es eine kürzere und übersichtlichere Möglichkeit, das `using`-Statement zu verwenden. Man kann `using` ohne Block nutzen, und die Ressource wird am Ende des aktuellen Gültigkeitsbereichs automatisch freigegeben.

```csharp
using var writer = new StreamWriter("example.txt");
writer.WriteLine("Hello, World!");
// Dispose wird automatisch aufgerufen, wenn die Methode endet.
```

---

<!-- .slide: class="left" -->
## Manuelles Aufrufen von `Dispose`

Ohne `using` kann die Methode `Dispose` auch manuell aufgerufen werden:

```csharp
StreamWriter writer = null;
try
{
  writer = new StreamWriter("example.txt");
  writer.WriteLine("Manuelles Dispose");
}
finally
{
  if (writer != null)
  {
    writer.Dispose(); // Manuelles Aufrufen von Dispose.
  }
}
```

* mehr fehleranfällig, da `Dispose` nicht automatisch aufgerufen wird.
* längerer, unübersichtlicher Code.

---

<!-- .slide: class="left" -->
## `Using` mit Fehlerbehandlung

Das `using`-Statement ruft die `Dispose`-Methode automatisch auf, auch wenn innerhalb des Blocks eine Ausnahme ausgelöst wird. Deshalb ist kein zusätzlicher `try`-`catch`-Block erforderlich, um sicherzustellen, dass Ressourcen freigegeben werden.

Ein `try`-`catch`-Block ist dann sinnvoll, wenn eine Ausnahme gezielt behandelt oder eine benutzerdefinierte Fehlermeldung ausgeben werden soll. Ebenfalls sinnvoll ist es beim Erzeugen des Objekts, um dort Fehler abfangen zu können.

* **Fehler beim Öffnen der Datei**: Datei existiert nicht, Berechtigungen fehlen.
* **Lese-/Schreibfehler**: Netzwerkprobleme oder Festplattenfehler.

Note: 
* Wenn der Konstruktor des Objekts im `using`-Statement (z. B. `StreamReader` oder `FileStream`) eine Ausnahme auslöst, wird die Ressource gar nicht erst erstellt und `Dispose` ist nicht relevant. In solchen Fällen musst du den Fehler separat behandeln.
* ein `try`-`catch` ist nicht immer notwendig.

---

<!-- .slide: class="left" -->
### Beispiel

```csharp
try
{
  using var stream = new StreamReader("example.txt");
  Console.WriteLine(stream.ReadToEnd());
}
catch (FileNotFoundException ex)
{
  Console.WriteLine($"Die Datei wurde nicht gefunden: {ex.Message}");
}
catch (IOException ex)
{
  Console.WriteLine($"Ein Fehler beim Zugriff auf die Datei ist aufgetreten: {ex.Message}");
}
```

---

<!-- .slide: class="left" -->
## Dateioperationen

Dateioperationen ermöglichen es, mit Dateien auf einem Computer zu arbeiten. In C\# stellt der Namespace `System.IO` Klassen und Methoden bereit, um Dateien zu erstellen, zu lesen, zu schreiben, zu löschen und vieles mehr.

---

<!-- .slide: class="left" -->
## Datei erstellen, Text schreiben und lesen

Mit der Methode `File.WriteAllText` kann eine Datei erstellt und Text in diese Datei geschreiben werden. 

Mit `File.ReadAllText` kann der Text ausgelesen werden.

```csharp
using System;
using System.IO;

class Program
{
  static void Main()
  {
    string dateipfad = "example.txt";
    string inhalt = "Hallo, das ist eine Testdatei.";

    // Datei erstellen und Text schreiben
    File.WriteAllText(dateipfad, inhalt);

    Console.WriteLine($"Die Datei {dateipfad} wurde erstellt.");

    string inhalt = File.ReadAllText(dateipfad);
    Console.WriteLine("Datei-Inhalt:");
    Console.WriteLine(inhalt);
  }
}

```

Note:
* Text anhängen mit `File.AppendAllText(dateipfad, neuerInhalt);`

---

<!-- .slide: class="left" -->
## Datei löschen

Mit `File.Delete` kann eine Datei gelöscht werden.

```csharp
using System;
using System.IO;

class Program
{
  static void Main()
  {
    string dateipfad = "example.txt";

    // Prüfen ob Datei existiert
    if (File.Exists(dateipfad))
    {
      // Datei löschen
      File.Delete(dateipfad);
      Console.WriteLine($"Die Datei {dateipfad} wurde gelöscht.");
    }
    else
    {
      Console.WriteLine($"Die Datei {dateipfad} existiert nicht.");
    }
  }
}
```

---

<!-- .slide: class="left" -->
## Ordner erstellen

Mit `Directory.CreateDirectory` können Ordner erstellt werden.


```csharp
using System;
using System.IO;

class Program
{
  static void Main()
  {
    string ordnerPfad = "NeuerOrdner";

    // Ordner erstellen
    Directory.CreateDirectory(ordnerPfad);

    Console.WriteLine($"Der Ordner {ordnerPfad} wurde erstellt.");
  }
}
```

---

<!-- .slide: class="left" -->
## Arbeiten mit `File`

Die Methoden der `File`-Klasse (`File.WriteAllText`, `File.ReadAllText`, usw.) sind einfacher und kürzer. Sie eignen sich besonders für kleinere, schnelle Dateioperationen.

Vorteile:
* **Einfachheit**: Einzeilige Methoden, die einfach zu verwenden sind.
* **Automatische Ressourcenschließung**: Keine Notwendigkeit, Streams manuell zu schließen.
* **Lesbarkeit**: Der Code ist übersichtlich und leicht verständlich.

Nachteile:
* **Weniger Kontrolle**: Keine Möglichkeit, das Schreiben oder Lesen zeilenweise oder blockweise anzupassen.
* **Speicherintensiver**: Große Dateien werden vollständig im Speicher gehalten (z.B. bei `File.ReadAllText`).

---

<!-- .slide: class="left" -->
## Arbeiten mit `StreamWriter`/`StreamReader`

Diese Klassen bieten mehr Flexibilität und Kontrolle, da sie datenstrombasierte Operationen unterstützen. Sie eignen sich besser für große Dateien oder Szenarien, in denen zeilenweise oder stückweise Daten verarbeitet werden sollen.

Vorteile:
* **Kontrolle**: Zeilenweises Schreiben/Lesen möglich.
* **Effizienter bei großen Dateien:** Nur der benötigte Teil der Datei wird in den Speicher geladen.

Nachteile:
* **Komplexität**: Der Code ist ausführlicher und erfordert das manuelle Schließen der Streams (oder die Verwendung von `using`-Blöcken).
* **Potenzial für Fehler**: Unsachgemäßer Umgang mit Streams kann zu Ressourcensperren oder Speicherlecks führen.

---

<!-- .slide: class="left" -->
## StreamWriter

Der `StreamWriter` wird verwendet, um Text in einen Datenstrom (z. B. eine Datei) zu schreiben. Er arbeitet effizient, da er Daten in einem Puffer speichert und sie blockweise schreibt, anstatt jeden Schreibvorgang einzeln auszuführen.

Wichtige Eigenschaften:
* `AutoFlush`: Bestimmt, ob der Puffer automatisch nach jedem Schreibvorgang geleert wird.
* `BaseStream`: Der zugrunde liegende Datenstrom, der mit dem StreamWriter verwendet wird.

Wichtige Methoden:
* `Write(string)`: Schreibt eine Zeichenfolge in den Stream.
* `WriteLine(string)`: Schreibt eine Zeichenfolge gefolgt von einem Zeilenumbruch.
* `Flush()`: Leert den Puffer und schreibt alle Daten sofort.

Note:
* `writer.Flush()`: Schreibt alle gepufferten Daten sofort in die Datei.
* Positionierung im Stream
  * `reader.BaseStream.Seek(0, SeekOrigin.Begin)`: Setzt den Stream zurück zum Anfang.
  * `reader.DiscardBufferedData()`: Aktualisiert den Puffer nach der Änderung der Position.

---

<!-- .slide: class="left" -->
### Beispiel

In Datei schreiben:

```csharp []
using var writer = new StreamWriter("C:\\log.txt");
writer.WriteLine("Schreibe das in die Datei");
writer.Write("Zeilen können verbunden sein");
writer.Write(" und enden hier.");
```

---

<!-- .slide: class="left" -->
## StreamReader

Der `StreamReader` wird verwendet, um Text aus einem Datenstrom (z. B. einer Datei) zu lesen. Er ist ideal, wenn man Dateien zeilenweise oder stückweise verarbeiten möchte.

Wichtige Eigenschaften:
* `EndOfStream`: Gibt an, ob der Stream vollständig gelesen wurde.
* `BaseStream`: Der zugrunde liegende Datenstrom, der mit dem StreamReader verwendet wird.
* `CurrentEncoding`: Gibt die verwendete Textkodierung zurück.

Wichtige Methoden:
* `Read()`: Liest ein einzelnes Zeichen aus dem Stream.
* `ReadLine()`: Liest eine vollständige Zeile aus dem Stream.
* `ReadToEnd()`: Liest den gesamten Rest des Streams als String.


Note:
* Angabe benutzerdefinierte Kodierungen (z. B. UTF-8, ASCII), wenn  Streams geöffnet werden.

---

<!-- .slide: class="left" -->
### Beispiel

Aus Datei lesen:

```csharp []
// using declaration syntax
using var reader = new StreamReader(@"c:\log.txt"); 
string allesEinlesen = reader.ReadToEnd();

string? zeile;
while ((zeile = reader.ReadLine()) != null) // Zeilenweise lesen
{
  Console.WriteLine(zeile);
}
```

---

<!-- .slide: class="left" -->
### Wann `FileInfo` verwenden

Im Vergleich zu den Methoden der `File`-Klasse ist `FileInfo` objektorientiert, sodass man Instanzen erstellen und wiederverwenden kann, um mehrere Eigenschaften und Methoden auf eine Datei anzuwenden.

* Wiederholt mit derselben Datei gearbeitet werden soll (z. B. Eigenschaften abrufen, Datei lesen/schreiben).
* Effizient für mehrere Aufrufe (Status bleibt erhalten)
* Zusätzliche Informationen über eine Datei benötigt (z. B. Größe, Erstellungszeit, Änderungszeit).

---

<!-- .slide: class="left" -->
### Eigenschaften von `FileInfo`

Die `FileInfo`-Klasse bietet viele nützliche Eigenschaften, um Dateiinformationen abzurufen:

| **Eigenschaft** | **Beschreibung** |
|-------------------------|--------------------------------|
| `Name`  | Gibt den Namen der Datei zurück.  |
| `FullName`  | Gibt den vollständigen Pfad der Datei zurück.|
| `Directory` | Liefert ein `DirectoryInfo`-Objekt. |
| `DirectoryName`| Gibt den Namen des Verzeichnisses als String zurück.|
| `CreationTime` | Liefert das Erstellungsdatum/Uhrzeit der Datei.|
| `LastAccessTime` | Liefert das letzte Zugriffsdatum/Uhrzeit der Datei.|
| `LastWriteTime`  | Liefert das Datum/Uhrzeit der letzten Änderung.  |
| `Exists`   | Gibt an, ob die Datei existiert (`true` oder `false`).  |

---

<!-- .slide: class="left" -->
### Methoden von `FileInfo`

Die `FileInfo`-Klasse bietet Methoden für verschiedene Dateioperationen:

| **Methode**   | **Beschreibung**  |
|---------------|-------------------|
| `Create()` | Erstellt die Datei, wenn sie nicht existiert. |
| `Delete()` | Löscht die Datei.     |
| `CopyTo(string)` | Kopiert die Datei an einen neuen Ort.    |
| `MoveTo(string)`| Verschiebt die Datei an einen neuen Ort. |
| `Open(FileMode)`  | Öffnet die Datei und gibt einen `FileStream` zurück. |
| `OpenRead()`| Öffnet die Datei zum Lesen und gibt einen `FileStream` zurück.|
| `OpenWrite()` | Öffnet die Datei zum Schreiben und gibt einen `FileStream` zurück.|
| `Refresh()`| Aktualisiert die Eigenschaften, falls sich die Datei geändert hat. |

Note: 
* **VS** Beispiel "91_Dateioperationen"
* `FileStream` vs `StreamWriter`
  * `StreamWriter` (TextWriter) ist ein Stream Decoder um Text zu schreiben.
  * `FileStream` konvertiert Textdateien in `byte[]`

---

<!-- .slide: class="left" -->
## Was wann verwenden

Verwende `StreamWriter`/`StreamReader`, wenn man:

* Große Dateien verarbeiten muss.
* Zeilenweise oder mit spezieller Kodierung arbeite möchte.
* Mehr Kontrolle über den Schreib-/Lesebereich braucht.

Verwende die `File`-Klasse, wenn man:

* Einfache und schnelle Dateioperationen benötigt.
* Kleine Dateien vollständig einlesen oder schreiben will.

Verwende `FileInfo` wenn man:

* Wiederholt mit derselben Datei arbeiten will
* Zusätzliche Informationen über eine Datei benötigt (z. B. Größe, Erstellungszeit, Änderungszeit).

---

<!-- .slide: class="left" -->
## DLL

DLLs (Dynamic Link Libraries) sind eine praktische Möglichkeit, Code wiederverwendbar, modular und wartbar zu machen. Sie sind besonders nützlich in großen Projekten oder wenn man Funktionalität mit mehreren Anwendungen teilen möchte.

**Vorteile**:

* **Wiederverwendbarkeit**: Eine DLL kann in mehreren Projekten verwendet werden, ohne den Code zu duplizieren.
* **Modularität**: Große Projekte können in kleinere, übersichtlichere Module aufgeteilt werden.
* **Wartbarkeit**: Änderungen in einer DLL müssen nicht in jeder Anwendung separat gemacht werden – es reicht, die DLL zu aktualisieren.

---

<!-- .slide: class="left" -->
## DLL erstellen

In Visual Studio ein neues "Class Library (.NET)-Projekt" erstellen.

```csharp
namespace MathLibrary
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
```

---

<!-- .slide: class="left" -->
## Nutzung der DLL in einer Konsolenanwendung

Ein neues Konsolenprojekt erstellen und die DLL als Referenz hinzufügen.

```csharp
using System;
using MathLibrary;  // Namespace der DLL

class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();
        int result = calc.Add(5, 7);
        Console.WriteLine($"Ergebnis: {result}");
    }
}
```

Nach dem Kompilieren und Verknüpfen der DLL kann die Konsolenanwendung auf die `Calculator`-Klasse zugreifen.

Note:
* **VS** zeigen
  * z.B. DLL welche eine Methode bereitstellt um etwas in der Console auszugeben. 
  * OutputType ändern
  * DLL einbinden in anderem Projekt
  * File und Assembly Version
* **ÜBUNG** Logger
* **ÜBUNG** Medienverwaltung Aufgabe 6
* **ÜBUNG** Dateien einlesen