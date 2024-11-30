# Übung - Logger

Ziel ist es eine Logger DLL zu erstellen, die es ermöglicht **ohne Instanz** dieser Klasse Daten in eine Logdatei zu schreiben. D.h. die Klasse und alle ihre Methoden sollen `static` sein.

Erstellen Sie wie gewohnt ein Konsolenprojekt und nutzen Sie die `Main()` zum Testen des Loggers, indem Sie von dort die Logger-Methoden aufrufen. 

**Achtung:** Nehmen Sie nicht den gleichen Namen für den Namespace und die Klasse.

## Methoden

Erstellen Sie mindestens zwei Methoden:

* Mit der ersten Methode übergeben Sie den Pfad zu der Stelle an der die Logdatei gespeichert werden soll und den Namen der Datei. Wenn der Ordner nicht existiert soll dieser erstellt werden.

* Mit der zweiten Methode erstellen Sie die Logdatei und schreiben in diese.

## weitere Anforderungen

* Die Logdatei darf nicht größer wie 5MB werden. Wird die Datei größer soll diese gelöscht werden.

* Der Logdateieintrag soll Datum, Uhrzeit und einen Fehlertyp (z.B. Error, Warning, Information ...) beinhalten.

* Kapseln sie alle möglichen Fehlerquellen (vor allem Datei Lese- und Schreibzugriffe) mit `using` und einem `try`/`catch`-Block.

### Beispiel Log-Eintrag

```bash
02.07.2017 11:31:52 - Error: das ist ein logger text
```
