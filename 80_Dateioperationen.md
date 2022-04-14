# Dateioperationen

Mit Dateien arbeiten


<!-- .slide: class="left" -->
## Allgemein

Das .Net Framework stellt im `System.IO` Namespace viele Klassen für Dateioperationen zur Verfügung.

* Klassen [StreamReader](https://docs.microsoft.com/de-de/dotnet/api/system.io.streamreader?view=netframework-4.7.2) und [StreamWriter](https://docs.microsoft.com/de-de/dotnet/api/system.io.streamwriter?view=netframework-4.7.2) um Text aus Dateien zu lesen bzw. zu schreiben.

* Klassen [File (static)](https://docs.microsoft.com/de-de/dotnet/api/system.io.file?view=netframework-4.7.2) und [FileInfo](https://docs.microsoft.com/de-de/dotnet/api/system.io.fileinfo?view=netframework-4.7.2) um Dateiinfos anzeigen zu lassen. Werden viele solcher Operationen durchgeführt ist FileInfo zu bevorzugen.

  * Dateigröße ermitteln
  * Prüfung ob Datei existiert
  * Erstelldatum, Letzte Änderung usw.

* Die Klassen [Directory (static)](https://docs.microsoft.com/de-de/dotnet/api/system.io.directory?view=netframework-4.7.2) und [DirectoryInfo](https://docs.microsoft.com/de-de/dotnet/api/system.io.directoryinfo?view=netframework-4.7.2) um mit Ordnern zu arbeiten.
  * Dateien eines Ordner lesen
  * Prüfung ob Ordner existiert
  * Order erstellen


<!-- .slide: class="left" -->
## StreamReader und StreamWriter

In Datei schreiben

```csharp
using (StreamWriter writer = new StreamWriter("C:\\log.txt") ) {
    writer.WriteLine("Schreibe das in die Datei");
}
```

Aus Datei lesen

```csharp
using (StreamReader reader = new StreamReader(@"c:\log.txt") ) {
    string einlesen = reader.ReadToEnd();
}
```

Aus Datei lesen mit `FileInfo`

```csharp
FileInfo fileInfo = new FileInfo(pfad);
StreamReader streamReader = fileInfo.OpenText();
string line;
// solange lesen solange nicht null zurück kommt
while ((line = streamReader.ReadLine()) != null) {
        Console.WriteLine(line);
}
streamReader.Dispose();
```

Note: **VS** Dateioperationen

Filestream vs StreamWriter: StreamWriter (TextWriter) ist ein Stream Decoder um Text zu schreiben.

FileStream konvertiert Textdateien in byte[]


<!-- .slide: class="left" -->
## Dispose() Methode

* Aufräumarbeiten werden von der Garbage Collection möglicherweise zeitverzögert ausgeführt, da sie dann durchgeführt werden, wenn das Programm wenig beschäftigt ist.

* Sollen Aufräumarbeiten für ein Objekt zu einem bestimmten Zeitpunkt ausgeführt werden (beim Schließen von Dateien bzw Freigabe von Ressourcen) kann dies mit der Methode [Dispose()](https://docs.microsoft.com/de-de/dotnet/standard/garbage-collection/implementing-dispose) realisiert werden.

* Die Methode ist bei allen Klassen verfügbar, welche die **IDisposable Schnittstelle** implementieren.

* Einige Klassen bieten **Close()** und **Dispose()** an:

  * In der Dispose() wird normalerweise die Close() ebenfalls aufgerufen.

  * Um eine SQL Verbindung zu schließen ist Close() besser geeignet da diese danach wieder geöffnet werden kann (das Objekt bleibt bestehen).

  * Bei Dispose() wird das Objekt zurückgesetzt d.h. ein weiteres Öffnen der Verbindung ist nicht möglich.

Note: Möglichkeit Ressourcen frei zu geben


<!-- .slide: class="left" -->
## using Anweisung

[Using](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/keywords/using-statement) als Anweisung definiert einen Bereich in welchem das in der using Anweisung definierte Objekt Gültigkeit hat. Das deklarierte Objekt wird, nachdem der mit using definierte Gültigkeitsbereich verlassen wird, automatisch verworfen (**Dispose**). Damit wird sichergestellt das dies auch bei einem Ausnahmefehler geschieht.

* Nutzen bei Klassen, die auf Ressourcen zugreifen. z.B. 

  * Dateizugriffe
  * Datenbankabfragen
  * ...

* Using kann bei allen Klassen die die **IDisposable Schnittstelle** implementieren angewendet werden.

* Das Objekt wird im Kopf der using Anweisung erzeugt (soll nicht außerhalb erzeugt werden, da das Objekt ansonsten noch Gültigkeit hat)

* **Fehler müssen nach wie vor abgefangen werden**


<!-- .slide: class="left" -->
### Syntax

Im Anweisungsblock wird das zu verwendende Objekt initialisiert.

```csharp
using (Klassenname objektname = new Klassenname() )
{
  // Code der das Objekt, welches im Anweisungsblock erstellt wurde, benutzt.
}
```


<!-- .slide: class="left" -->
### Beispiel

Am Ende des Using Blocks wird für dieses Objekt automatisch die `Dispose()` Methode aufgerufen, und das Objekt somit verworfen/freigegeben.

```csharp
try {
  using (StreamReader sr = StreamReader("C:\\test.txt"))
  {
    Console.WriteLine(sr.ReadLine());
  }
} catch (Exception e) { }
```

Die selbe Funktionalität wie using bietet ein try-finally Block.

```csharp
try {
  // sr Objekt ist nur innerhalb dieses Bereichs gültig
  StreamReader sr = new StreamReader("C:\\test.txt"));
  try
  {
    Console.WriteLine(sr.ReadLine());
  }
  finally
  {
    if (sr != null) {
        // Aufruf der Dispose() Methode (Freigabe der Ressourcen)
      ((IDisposable)sr).Dispose();
    }
  }
} catch (Exception e) {}
```

Note: ÜBUNG Logger, Dateien einlesen und Medienverwaltung Aufgabe 4

Test mit der DLL vom Nebensitzer oder von mir