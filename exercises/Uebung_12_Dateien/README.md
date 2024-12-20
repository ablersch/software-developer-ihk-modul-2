# Übung - Dateien einlesen

Es sollen bestehende Logdateien (bzw. Textdateien) in einer Konsolenanwendung eingelesen bzw. ausgegeben werden.

Die auszugebenden Dateien sollen als Parameter (vollständiger Pfad) der Anwendung übergeben werden. D.h. der Pfad soll nicht im Programm eingegeben werden. Es können auch mehrere Dateien übergeben werden. Nutzen Sie hierzu das `string[] args` der `Main()`.

D.h. das Programm kann wie folgt gestartet werden:

```bash
meinProgramm.exe c:\temp\test.txt c:\temp\error.log
```

## Folgende Funktionen sollen implementiert werden

* Prüfen Sie ob die Datei existiert
* Es sollen nur Textdateien akzeptiert werden (z.B. .log und .txt). Wird die übergebene Datei nicht unterstützt soll eine Meldung erscheinen und das Programm mit der nächsten Datei weiterarbeiten.
* Vor jeder Dateiausgabe Dateiinfos ausgeben:

    * Größe in KB
    * Erstelldatum (nur Datum)
    * letzte Bearbeitung

* Danach alle Zeilen ausgeben:

    * Wurde ein Log Status (so wie bei unserer Logger Übung) hinterlegt soll zu jedem Status eine Farbe hinterlegt werden. z.b. mit: `Console.ForegroundColor = ConsoleColor.Red;`
    * Die Ausgabe mit der entsprechenden Farbe versehen.

## Beispiel-Ausgabe

![Beispiel](Beispiel.png)

## Hinweis

Um solch ein Projekt einfach zu debuggen gibt es die Möglichkeit dem Debugger Befehlszeilenargumente mitzugeben.

![Debug Parameter](DebugParameter.png)