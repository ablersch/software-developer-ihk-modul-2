# Übung - Medienverwaltung Aufgabe 4

## Teil 1

Das Programm so anpassen damit von der Klasse `Medium` keine Instanzen erzeugt werden können.

Die Klasse `Medium` soll vorgeben das alle abgeleiteten Klassen eine Methode `Ausgabe()` besitzen müssen.

## Teil 2 - Ausgabe-Überschrift

Wenn die Überschift der Ausgabe noch in der `Program`-Klasse erfolgt soll diese verschoben werden in die `Medium`-Klasse. 
Es ist nicht notwendig das die Überschrift über die `Ausgabe()` ausgegeben wird.

Die Überschrift darf bei mehreren Medien nur einmal ausgegeben werden. Ist kein Medium vorhanden soll keine Überschrift erscheinen.


### Beispiel Ausgabe

```bash
Medienbestand
Signatur     Typ       Titel      Leihstatus   Eigenschaften
12553        Video     Gladiator  präsent      Dauer 110.50 min
5778         Buch      Faust      entliehen    Seitenzahl 325
```