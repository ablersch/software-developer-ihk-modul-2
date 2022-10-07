# Casting

Werte umwandeln

---

<!-- .slide: class="left" -->
## Casting (Umwandlung bzw. Typkonvertierung)

* **is Schlüsselwort:** Prüft ob ein Objekt mit einem bestimmten Typ kompatibel ist.

* **as Schlüsselwort:** Führt eine Konvertierung in den angegebenen Datentyp durch. Bei einem Fehler ist das Objekt null.

* **Klassische Konvertierung:** Um eine Umwandlung durchzuführen, legen Sie den Typ, in den Sie umwandeln, in Klammern vor den zu konvertierenden Wert/Variable. Bei einem Fehler wird eine Exception geworfen.

```csharp
double d = 1234.7;
int zahl;
// Cast double to int
zahl = (int)d;    -> Ergebnis: 1234
```

Note:
int -> Double implizit (autom vom Compiler)

zahl = (int)d; explizit (auch mit Convert möglich)

---

<!-- .slide: class="left" -->
## Umwandeln nach String

Geht mit allen Objekten die die Methode `ToString()` von  der Klasse System.Object erben.

Die ToString-Methode wandelt den aktuellen Wert einer beliebigen Variablen in eine Textdarstellung um. Einige Typen können nicht sinnvoll als Text dargestellt werden, so dass sie ihren Namespace und Typnamen zurückgeben.

```csharp
int number = 12;
WriteLine(number.ToString()); // 12

bool boolean = true;
WriteLine(boolean.ToString()); // True

DateTime now = DateTime.Now;
WriteLine(now.ToString()); // aktuelles Datum

object me = new object();
WriteLine(me.ToString()); // System.Object
```

---

<!-- .slide: class="left" -->
## Beispiel

```csharp
Person hans;
Object myObject = new Person();
if (myObject is Person) // Prüft ob myObject mit Person kompatibel ist
{
    hans = (Person)myObject; // Alternativ:  ((Person)myObject).GetName();
    hans.GetName();
}

```

```csharp
hans = myObject as Person; // Führt eine Konvertierung aus
if (hans != null) // Erfolgreich wenn person nicht null ist
{
    hans.GetName();
}
```

Note: **VS** Casting, und Static (z.B. Methode zum prüfen ob Email Adresse) zeigen. Casting machen in VS.

ÜBUNG Medienverwaltung 4

Erklärung zu statisch