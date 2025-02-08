# Übung - Geometrische Formen

## Basisklasse

* Erstellen Sie eine Basis-Klasse `Form`. 
* Von der Klasse darf keine Instanz erzeugt werden dürfen (besonderes Schlüsselwort notwendig).
* Diese Klasse soll eine Eigenschaft `string Name` besitzen.
* Sie soll eine virtuelle Methode `double BerechneFlaeche()` enthalten, die standardmäßig 0 zurückgibt.

## Abgeleitete Klasse `Rechteck`

* Erstellen Sie eine abgeleitete Klasse `Rechteck`.
* Diese Klasse soll zwei Eigenschaften haben:
  * `double Laenge`
  * `double Breite`
* Überschreibe die Methode `BerechneFlaeche()`, sodass sie die Fläche des Rechtecks berechnet (`Laenge * Breite`).
* Im Setter für `Laenge` und `Breite` soll überprüft werden, dass keine negativen Werte gesetzt werden können.
* Von der Klasse darf keine weitere Klasse abgeleitet werden. Verbieten Sie dies explizit.

## Abgeleitete Klasse `Kreis`

* Erstellen Sie eine abgeleitete Klasse `Kreis`.
* Diese Klasse soll eine Eigenschaft `double Radius` haben.
* Überschreibe die Methode `BerechneFlaeche()`, sodass sie die Fläche des Kreises berechnet (`π * Radius²`). Das Ergebnis soll auf 2 Nachkommastellen gerundet werden.
* Der Setter für `Radius` soll prüfen, dass kein negativer Wert gesetzt wird.
* Von der Klasse darf keine weitere Klasse abgeleitet werden. Verbieten Sie dies explizit.

## Ausgabe

In der `Main()` erstellen Sie eine Liste um Formen speichern zu können. Erstellen Sie mehrere Instanzen von `Rechteck` und `Kreis` und füge Sie diese der Liste hinzu. 

Die Daten können statisch hinterlegt werden. Keine Eingabe über die Konsole notwendig.

Durchlaufen Sie die Liste mit einer Schleife und geben Sie für jede Form den Namen und die berechnete Fläche aus.

### Ausgabe

```bash
Rechteck1 hat eine Fläche von 15.
Rechteck2 hat eine Fläche von 14.
Kreis1 hat eine Fläche von 50,27.
Kreis2 hat eine Fläche von 1809,56.
```
