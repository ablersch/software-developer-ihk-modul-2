# Übung - Sekunden speichern

## Teil 1
Erstellen Sie eine Klasse namens `Sekunden`. Diese Klasse soll Sekunden speichern können.

Die Klasse soll keine Methoden benutzen sondern nur folgende Properties.

* `Seconds`
* `Minutes`
* `Hours`
* `Days`

Die Sekunden sollen dabei in die entsprechenden Werte umgerechnet werden. 
z.B. 
* entsprechen 130 Sekunden 2 Minuten.
* entsprechen 130 Sekunden 0 Stunden.
* ...

Verwenden Sie alle Eigenschaften der Klasse mindestens einmal.

## Bemerkung

Die Sekunden können fest vorgegeben werden oder auch per Eingabe abgefragt werden. Es sollen nur ganze Minuten, Stunden und Tage angezeigt werden.

* Minute 	= 60 Sekunden
* Stunde 	= 60 * 60 = 3600 Sekunden
* Tag 	    = 3600 * 24 = 86400 Sekunden


## Beispiel Ausgabe

```bash
Sekunden eingeben:
888

Sekunden: 888
Minuten: 14
Stunden: 0
Tage: 0
```

## Teil 2

Erweitern Sie Ihr Programm um eine Methode, damit die Sekunden nicht umgerechnet werden, sondern immer die Restwerte ([Modulo](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/operators/arithmetic-operators#remainder-operator-)) angezeigt werden. Hierzu muss mit dem Rest weiter gerechnet werden. 
Erstellen Sie dazu eine Methode die die Berechnung ausführt und einen fertigen String zurückliefert.

## Beispiel Ausgabe

```bash
Sekunden eingeben:
888

Tage: 0 Stunden: 0 Minuten: 14 Sekunden: 48
```

```bash
Sekunden eingeben:
7771516

Tage: 89 Stunden: 22 Minuten: 45 Sekunden: 16
```