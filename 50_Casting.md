# Casting

Werte umwandeln.

---

<!-- .slide: class="left" -->
## Casting (Umwandlung bzw. Typkonvertierung)

* **`is`** Prüft ob ein Objekt mit einem bestimmten Typ kompatibel ist.

* **`as`** Führt eine Konvertierung in den angegebenen Datentyp durch. Bei einem Fehler ist das Objekt `null`.

* **Klassische Konvertierung:** Um eine Umwandlung durchzuführen, legen Sie den Typ, in den Sie umwandeln, in Klammern vor den zu konvertierenden Wert/Variable. Bei einem Fehler wird eine Exception geworfen.

```csharp
int zahl = 42;         
double d = zahl;        // Automatische Umwandlung von int zu double
Console.WriteLine(d);   // Ausgabe: 42.0
```

```csharp
double d = 1234.7;
int zahl = (int)d;      // Explizite Umwandlung von double zu int
Console.WriteLine(d);   // Ausgabe: 1234
```

Note:

* int -> Double implizit (autom. vom Compiler)
* zahl = (int)d; explizit (auch mit Convert möglich)

---

<!-- .slide: class="left" -->
## Beispiel

```csharp []
Person hans;
Object myObject = new Person();
if (myObject is Person)     // Prüft ob myObject vom Datentyp Person ist.
{
    hans = (Person)myObject; 
    hans.GetName();
}


hans = myObject as Person;  // Führt eine Konvertierung aus.
if (hans != null)           // Erfolgreich wenn myObject nicht null ist.
{
    hans.GetName();
}
```

---

<!-- .slide: class="left" -->
## Umwandeln nach String

Geht mit allen Objekten die die Methode `ToString()` von der `Object`-Klasse erben.

Die `ToString()`-Methode wandelt den aktuellen Wert einer beliebigen Variablen in einen Text um. Einige Typen können nicht sinnvoll als Text dargestellt werden, so dass sie ihren Namespace und Typnamen zurückgeben.

```csharp []
int number = 12;
WriteLine(number.ToString()); // 12

bool boolean = true;
WriteLine(boolean.ToString()); // True

DateTime now = DateTime.Now;
WriteLine(now.ToString()); // aktuelles Datum

object me = new object();
WriteLine(me.ToString()); // System.Object
```

Note:
* **VS** Casting zeigen.
* **ÜBUNG** Medienverwaltung Aufgabe 5