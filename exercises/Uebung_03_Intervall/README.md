# Übung - Intervall

Implementieren Sie die Klasse `Intervall` zur Darstellung von `int`-Zahlenintervallen. Folgendes soll berücksichtig werden:

* Felder für Min und Max für die Unter- und die Obergrenze welche nur in der Intervallklasse sichtbar/zugreifbar (`private`) sind.

* Konstruktor mit Parametern um initial die Werte für Min und Max zu setzen.

* Methode `public int Size()` zur Berechnung der Intervallgröße (max – min).

* Methode `public int Avg()` zur Berechnung des Intervall-Mittelwertes ((max - min) / 2).

* Methode `public void Move(int offset)` zur Verschiebung des Intervalls (max + Verschiebung ; min + Verschiebung). 

* Methode `public void Scale(int offset)` zum Skalieren des Intervalls (max * Skalierungswert; min * Skalierungswert).

* Methode `public void Output(string methodName)` zum Ausgeben der Intervallwerte (Max und Min).

Schreiben Sie eine `Main()` in der ein Intervall-Objekt mit festen Werten instanziiert und die genannten Methoden mindestens einmal aufgerufen und die Werte ausgegeben werden.

## Beispiel Ausgabe

```bash
Werte:
Max = 111
Min = 11

Intervallgroesse:
100

Mittelwert:
50

Verschiebung:
Max = 121
Min = 21

Skalieren:
Max = 1210
Min = 210

```