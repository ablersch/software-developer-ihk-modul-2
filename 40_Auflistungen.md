# Collections (Auflistungen)

Datenstrukturen zum Speichern und Verwalten von Daten.

---

<!-- .slide: class="left" -->
## Collection Klassen

Collections sind spezialisierte Datenstrukturen, die das Speichern, Verwalten und Durchsuchen von Objekten auf effiziente und benutzerfreundliche Weise ermöglichen. Es gibt verschiedene Arten von Collections, die jeweils für unterschiedliche Anwendungsfälle optimiert sind.

Vorteile gegenüber Arrays:

* Dynamische Größe
* Erweiterte Funktionalitäten
* Leistungsfähige Datenzugriffsmethoden
* bessere Performance mit LINQ
* Erweiter- und Anpassbarkeit

Note:
* **Dynamische Größe:** Arrays haben eine feste Größe; Collections passen diese zur Laufzeit an.
* **Erweiterte Funktionalitäten**: Arrays bieten nur grundlegende Funktionen und erfordern oft zusätzliche Logik; Collections bieten eine Vielzahl von Methoden und Eigenschaften, die Operationen wie Hinzufügen, Entfernen, Suchen, Sortieren und Filtern erleichtern.
* **Leistungsfähige Datenzugriffsmethoden**: Bestimmte Collections ermöglicht schnellen Zugriff auf Elemente über Schlüssel (Dictionary) oder über die Reihenfolge (Queue).
* **bessere Performance mit LINQ**: Arrays können auch mit LINQ abgefragt werden; Collections lassen sich nahtlos mit LINQ abfragen und bieten bessere Performance und Flexibilität bei größeren Datenmengen.
* **Erweiter- und anpassbarkeit**: Arrays sind weniger flexibel und bieten keine eingebauten Mechanismen zur Erweiterung; Collections können erweitert werden, um benutzerdefinierte Funktionen bereitzustellen.

---

<!-- .slide: class="left" -->
### Collection Namespaces

* **System.Collections:** Dabei kann die Collection immer den Typ `Object` verwalten. Eine Collection kann somit verschiedene Typen beinhalten. D.h. es müssen alle Elemente beim Zugriff konvertiert werden.

* **System.Collections.Generics:** Diesen Nachteil haben die generischen Collections nicht und sind deshalb zu bevorzugen da diese **Typsicherheit** bieten. D.h. beim Instanziieren werden die Datentypen festgelegt.

Mehr zum Thema [Collections](https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/concepts/collections)

---

<!-- .slide: class="left" -->
## ArrayList

Eine [`ArrayList`](https://docs.microsoft.com/de-de/dotnet/api/system.collections.arraylist?view=net-6.0) ist eine dynamische Liste von Objekten. Im Gegensatz zu Arrays, die eine feste Größe haben, kann eine `ArrayList` in ihrer Größe dynamisch wachsen und schrumpfen, wenn Elemente hinzugefügt oder entfernt werden.

* Dynamische Größe
* Zugriff über Index
* kann beliebige Objekte speichern
* Performance schlechter als bei `List<T>`

---

<!-- .slide: class="left" -->
### Beispiel ArrayList

```csharp []
ArrayList arrayList = new ArrayList();
arrayList.Add(5);
arrayList.Add("text");
Console.WriteLine($"Elemente: {arrayList.Count}");

// Der Typ wird beim Kompilieren des Codes festgelegt
foreach (var element in arrayList) 
{
     Console.WriteLine(element);
}
arrayList[1] = 10;
Console.WriteLine("2. Element: " + arrayList[1]);
```

---

<!-- .slide: class="left" -->
## Hashtable

Eine [`Hashtable`](https://docs.microsoft.com/de-de/dotnet/api/system.collections.hashtable?view=net-6.0) ist eine spezielle Art von Datenstruktur die Daten in Form von Schlüssel-Wert-Paaren speichert und über einen sogenannten Hashing-Mechanismus schnellen Zugriff auf die gespeicherten Daten bietet.

Kommt es nicht auf die Reihenfolge der Elemente an, kann man sich dafür entscheiden. Es kann ein bestimmtes Element zwar schnell gefunden werden, man hat aber keinen Einfluss auf die Positionierung der Elemente in der Liste.

* Schneller Zugriff über Schlüssel (Hashcode)
* Keinen Einfluss auf den Index
* Reihenfolge nicht beeinflussbar

Note: 
Bei einer Liste mit Indizes muss die Liste so lange durchlaufen werden bis eine Übereinstimmung gefunden wurde. Bei sehr vielen Einträgen, kann das sehr zeitaufwendig und rechenintensiv sein.

Hashcode: `Int`-Wert welcher über Algorithmus aus dem Schlüssel berechnet wird.

---

<!-- .slide: class="left" -->
### Beispiel Hashtable

```csharp []
Hashtable hashTable = new Hashtable();

hashTable.Add("auto1", "Das Auto ist ein Audi");
hashTable.Add("auto2", "Das Auto ist ein BMW");
hashTable.Add("motorrad1", "Das Motorrad ist eine Ducati");

if (hashTable.ContainsKey("auto1")) {
     Console.WriteLine($"Ausgabe des Wertes von KEY auto1: {hashTable["auto1"]}");
}

if (hashTable.ContainsValue("Audi")) {
     Console.WriteLine("beinhaltet WERT Audi");
}

// Definiert ein Schlüssel-Wert-Paar für ein Wörterbuch. Es ist eine generische Struktur mit 2 Werten.
// Kann bei Collections benutzt werden
foreach (DictionaryEntry element in hashTable) {
     Console.WriteLine($"Key: {element.Key} Wert: {element.Value}");
}
```

---

<!-- .slide: class="left" -->
## List\<T>

Eine [`List<T>`](https://docs.microsoft.com/de-de/dotnet/api/system.collections.generic.list-1?view=net-6.0) ist eine generische, dynamische Liste. Sie speichert Elemente vom spezifischen Typ `T`, wodurch Typensicherheit gewährleistet wird.

* Typsicherheit
* Dynamische Größe
* Zugriff über Index
* Kein schneller Zugriff (`Dictionary` ist schneller)
* Listen sind ideal für Schleifen
* Werden in C\# häufig genutzt

---

<!-- .slide: class="left" -->
### Beispiel List

```csharp []
List<int> liste = new List<int>();

liste.Add(40);
liste.Add(50);
liste.Add(60);

Console.WriteLine($"Anzahl Elemente: {liste.Count}");

if (liste.Contains(40)) {
     Console.WriteLine("Liste beinhaltet Wert 40");
}

Console.WriteLine($"2. Wert {liste[1]}");

foreach (int i in liste) {
     Console.WriteLine(i);
}
```

Note:
* **VS** List Verwendung zeigen mit Zuweisung von Objekten und Objekten mit Vererbung.

---

<!-- .slide: class="left" -->
## Dictionary<TKey, TValue>

Das [`Dictionary`](https://docs.microsoft.com/de-de/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0) ist eine Sammlung von Schlüssel-Wert-Paaren, die einen schnellen Zugriff auf Elemente anhand ihres eindeutigen Schlüssels ermöglicht.

Die Schlüssel und Werte können unterschiedliche Typen haben, wobei der Schlüssel typischerweise ein einzigartiges Objekt sein muss, um Verwechslungen zu vermeiden.

**TKey** Der Typ des Schlüssels im Wörterbuch.
**TValue** Der Typ des Wertes im Wörterbuch.


* Schneller Zugriff mit Schlüsseln (ist einer `Hashtable` oder einer `List` vorzuziehen)
* Schlüssel-Wert-Paare
* Typsicherheit

---

<!-- .slide: class="left" -->
### Beispiel Dictionary

```csharp []
string tempString;

Dictionary<string, string> dictionary = new Dictionary<string, string>();

dictionary.Add("tier1", "Hase");
dictionary.Add("tier2", "Hund");
dictionary.Add("tier3", "Esel");

if (dictionary.ContainsKey("tier1")) {
     Console.WriteLine($"Wert zum KEY tier1: {dictionary["tier1"]}");
}

if (dictionary.TryGetValue("tier1", out tempString)) {
     Console.WriteLine($"found Wert: {tempString}");
}

foreach (KeyValuePair<string, string> pair in dictionary) {
     Console.WriteLine($"Key: {pair.Key} Wert: {pair.Value}");
}
```

---

<!-- .slide: class="left" -->
## weitere Collections

* **`HashSet<T>`**: Sammlung eindeutiger Werte ohne bestimmter Reihenfolge, keine Duplikate.
* **`Queue<T>`**: FIFO-Warteschlange (First In, First Out).
* **`Stack<T>`**: LIFO-Stapel (Last In, First Out).
* **`SortedList`**<TKey, TValue>: Sortierte Schlüssel-Wert-Paare.
* **`LinkedList<T>`**: Doppelt verkettete Liste, flexibel für Einfügungen.
* **`ObservableCollection<T>`**: Benachrichtigt bei Änderungen, ideal für GUI-Bindings.
* **`ConcurrentDictionary<TKey, TValue>`**: Thread-sicheres Dictionary für parallelen Zugriff.
* **`ImmutableList<T>`**: Unveränderliche Liste, ideal für unveränderliche Daten.

Note:
* Jede Collection bietet Lösungen für spezifische Anforderungen wie Geschwindigkeit, Sortierung, Einzigartigkeit und Thread-Sicherheit.
* **ÜBUNG 7** Wetterstation