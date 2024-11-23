# Übung - Medienverwaltung Aufgabe 5

## Teil 1 - Objekte speichern

Nun können mehrere Objekte einer Klasse existieren. Z.b. zwei Video- und drei Bücher-Objekte. Der Bestand der Bibliothek soll in einer Collection temporär (nur zur Laufzeit des Programms) gespeichert werden.

Es könnte nun nötig werden das das Feld `signatur` außerhalb der `Medium`-Klasse benötigt wird.

**Eine Collection beinhaltet alle Objekte.**

## Teil 2 - Prüfen und Vergabe der Signatur

Als weiterer Schritt soll die Signatur automatisch mit Zufallszahlen erstellt werden. Nutzen Sie die Klasse `Random`.

```csharp
Random random = new Random();
int signatur = random.Next(Zahl von, Zahl bis);
```

Prüfen Sie ob eine Signatur bereits existiert. Wenn ja eine neue Zufallszahl generieren.

Ebenfalls soll beim Entleihen und Rückgeben geprüft werden ob die eingegebene Signatur überhaupt existiert. Wenn nicht soll eine Meldung ausgegeben werden.

## Teil 3 - weitere Anpassungen

|Kommando    | Aktion
-------------|----------
|„a“| Titel können eine beliebige Länge haben. Bei der Ausgabe soll die Spaltenstruktur aber erhalten bleiben. Schneiden Sie die Titel bei der Ausgabe entsprechend ab.|
|„l Signatur“| Löschen des durch die Signatur bezeichneten Objekts. z.B. l 2234|