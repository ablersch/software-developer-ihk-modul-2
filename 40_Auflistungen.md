# Collections (Auflistungen)

Datenstrukturen zum speichern und verwalten von Daten.

---

<!-- .slide: class="left" -->
## Auflistungen

Collections sind Datenstrukturen, die das Speichern, Verwalten und Durchsuchen von Objekten auf effiziente und benutzerfreundliche Weise ermöglichen. Es gibt verschiedene Arten von Collections, die jeweils für unterschiedliche Anwendungsfälle optimiert sind.

Mehr zum Thema [Collections](https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/concepts/collections)

---

<!-- .slide: class="left" -->
## Vorteile gegenüber Arrays

* **Dynamische Größe**: Arrays haben eine feste Größe, Collections passen diese zur Laufzeit an.
  
* **Erweiterte Funktionalitäten**: Arrays bieten nur grundlegende Funktionen und erfordern oft zusätzliche Logik. Collections bieten eine Vielzahl von Methoden und Eigenschaften, die Operationen wie Hinzufügen, Entfernen, Suchen, Sortieren und Filtern erleichtern.
  
* **Leistungsfähige Datenzugriffsmethoden**: Bestimmte Collections ermöglichen schnellen Zugriff auf Elemente über Schlüssel oder über die Reihenfolge.

* **bessere Performance mit LINQ**: Arrays können auch mit LINQ abgefragt werden Collections aber bieten bessere Performance und Flexibilität bei größeren Datenmengen.

---

<!-- .slide: class="left" -->
## List\<T>

Eine [`List<T>`](https://docs.microsoft.com/de-de/dotnet/api/system.collections.generic.list-1) ist eine dynamische Liste welche Elemente vom spezifischen Typ `T` speichert.

**Vorteile**:
* ✔ einfach zu verwenden.
* ✔ Dynamische Größe.
* ✔ Zugriff über Index.
* ✔ Gute Performance für das Hinzufügen am Ende.

**Nachteile**:
* ✖ Nicht für schnelle Suche nach Werten optimiert.
* ✖ Langsames Einfügen oder Löschen in der Mitte.

---

<!-- .slide: class="left" -->
### Beispiel List

```csharp []
var liste = new List<int>();
liste.Add(40);
liste.Add(50);
liste.Add(60);

Console.WriteLine($"Anzahl Elemente: {liste.Count}");

if (liste.Contains(40)) 
{
     Console.WriteLine("Liste beinhaltet Wert 40");
}

Console.WriteLine($"2. Wert {liste[1]}");

foreach (int i in liste) 
{
     Console.WriteLine(i);
}
```

Note:
* **VS** `List` Verwendung zeigen mit Zuweisung von Objekten und Objekten mit Vererbung.

---

<!-- .slide: class="left" -->
## Dictionary\<TKey, TValue>

Das [`Dictionary`](https://docs.microsoft.com/de-de/dotnet/api/system.collections.generic.dictionary-2) ist eine Hash-Table basierte Sammlung von Schlüssel-Wert-Paaren, die einen schnellen Zugriff auf Elemente anhand ihres eindeutigen Schlüssels ermöglicht. Die Schlüssel und Werte können unterschiedliche Datentypen haben. Der Schlüssel muss eindeutig sein.

**TKey** Der Typ des Schlüssels im Wörterbuch. **TValue** Der Typ des Wertes im Wörterbuch.

**Vorteile**:
* ✔ Sehr schnelles Suchen, Einfügen und Entfernen.
* ✔ Geeignet für große Datenmengen mit Schlüssel-Zugriff.
* ✔ Kein doppelter Schlüssel erlaubt.

**Nachteile**:
* ✖ Höherer Speicherverbrauch als eine Liste.
* ✖ Schlüssel müssen eindeutig sein.
* ✖ Keine garantierte Reihenfolge.

---

<!-- .slide: class="left" -->
### Beispiel Dictionary\<TKey, TValue>

```csharp []
var dictionary = new Dictionary<string, string>();
dictionary.Add("tier1", "Hase");
dictionary.Add("tier2", "Hund");
dictionary.Add("tier3", "Esel");

if (dictionary.ContainsKey("tier1")) 
{
     Console.WriteLine($"Wert zum KEY tier1: {dictionary["tier1"]}");
}

if (dictionary.TryGetValue("tier1", out string tempString)) 
{
     Console.WriteLine($"found Wert: {tempString}");
}

foreach (KeyValuePair<string, string> pair in dictionary) 
{
     Console.WriteLine($"Key: {pair.Key} Wert: {pair.Value}");
}
```

---

<!-- .slide: class="left" -->
## HashSet\<T>

Eine ungeordnete Menge von eindeutigen Elementen mit schneller Suche.

**Vorteile**:
* ✔ Sehr schnelle Such- und Einfügeoperationen.
* ✔ Automatische Verhinderung von doppelten Einträgen.
* ✔ Effizienter als eine `List<T>` für die Prüfung, ob ein Element vorhanden ist.

**Nachteile**:
* ✖ Keine garantierte Reihenfolge.
* ✖ Höherer Speicherverbrauch als eine `List<T>`.
* ✖ Kein direkter Indexzugriff.

---

<!-- .slide: class="left" -->
## Beispiel HashSet\<T>

```csharp
HashSet<int> zahlen = new HashSet<int> { 1, 2, 3, 4, 5 };

// Einfügen eines neuen Werts
bool hinzugefügt = zahlen.Add(3); // Wird nicht hinzugefügt, da 3 bereits existiert
Console.WriteLine($"Wurde die 3 hinzugefügt? {hinzugefügt}"); // False

hinzugefügt = zahlen.Add(6); // Wird hinzugefügt, da 6 noch nicht existiert
Console.WriteLine($"Wurde die 6 hinzugefügt? {hinzugefügt}"); // True

Console.WriteLine("HashSet-Inhalt:");
foreach (var zahl in zahlen)
{
     Console.WriteLine(zahl);
}

// Prüfen, ob ein Element existiert
Console.WriteLine($"Enthält das HashSet die Zahl 4? {zahlen.Contains(4)}"); // True

// Entfernen eines Elements
zahlen.Remove(2);
```

---

<!-- .slide: class="left" -->
## weitere Collections

* **`Queue<T>`**: FIFO-Warteschlange (First In, First Out).
* **`Stack<T>`**: LIFO-Stapel (Last In, First Out).
* **`SortedList`**<TKey, TValue>: Sortierte Schlüssel-Wert-Paare.
* **`LinkedList<T>`**: Doppelt verkettete Liste, flexibel für Einfügungen.
* **`ObservableCollection<T>`**: Benachrichtigt bei Änderungen, ideal für GUI-Bindings.
* **`ConcurrentDictionary<TKey, TValue>`**: Thread-sicheres Dictionary für parallelen Zugriff.
* **`ImmutableList<T>`**: Unveränderliche Liste, ideal für unveränderliche Daten.

Note:
* Jede Collection bietet Lösungen für spezifische Anforderungen wie Geschwindigkeit, Sortierung, Einzigartigkeit und Thread-Sicherheit.
* **ÜBUNG 7** Geometrische Formen
  * Für die Übung `Math`-Klasse notwendig