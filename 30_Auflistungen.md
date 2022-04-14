# Collections (Auflistungen)

Gruppieren von Objekten (alternativen für Arrays).


<!-- .slide: class="left" -->
## Collection Klassen

Zur Zeit kennen wir nur Arrays für Aufzählungen. Diese haben aber einige
Nachteile:

* Die Größe muss festgelegt werden

* Array ist statisch (Größe kann nicht automatisch angepasst werden)

* Index bleibt vorhanden wenn ein Element gelöscht wird

Dafür gibt es neue Klassen sogenannte **Collections**. Diese können ihre Kapazität dynamisch verwalten und enthalten keine leeren Indizes.

Damit diese verwendet werden können, müssen folgende Namespaces in das Projekt eingebunden werden:


<!-- .slide: class="left" -->
### Collection Namespaces

* **System.Collections:** Dabei kann die Collection immer den Typ Object verwalten. Eine Collection kann somit verschiedene Typen beinhalten. D.h. es müssen alle Elemente beim Zugriff konvertiert werden.

* **System.Collections.Generics:** Diesen Nachteil haben die generischen Collections nicht und sind deshalb zu bevorzugen da diese **Typsicherheit** bieten. D.h. beim Instanziieren werden die Datentypen festgelegt.

Mehr zum Thema [Collections](https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/concepts/collections)

Note: **VS** autom Auflösung zeigen


<!-- .slide: class="left" -->
## ArrayList

Eine häufig verwendete Klasse für Aufzählungen ist die Klasse [ArrayList](https://docs.microsoft.com/de-de/dotnet/api/system.collections.arraylist?view=netframework-4.7.2).

Damit diese verwendet werden kann, muss der folgende Namespace in das
Projekt eingebunden werden:

```csharp
using System.Collections;
```


<!-- .slide: class="left" -->
### Beispiel ArrayList

```csharp
ArrayList arrayList = new ArrayList();
arrayList.Add(5);
arrayList.Add("text");
Console.WriteLine($"Elemente: {arrayList.Count}");

// Der Typ wird beim Kompilieren des Codes festgelegt
foreach (var element in arrayList) {
     Console.WriteLine(element);
}
arrayList[1] = 10;
Console.WriteLine("2. Element: " + arrayList[1]);
```


<!-- .slide: class="left" -->
## Hashtable

Bei einer Liste mit Indizes muss man die Liste so lange durchlaufen bis man eine Übereinstimmung gefunden hat. Bei sehr vielen Einträgen, kann das sehr zeitaufwendig und rechenintensiv sein.

Kommt es nicht auf die Reihenfolge der Elemente an, kann man sich für eine [Hashtabelle](https://docs.microsoft.com/de-de/dotnet/api/system.collections.hashtable?view=netframework-4.7.2) entscheiden. Dort kann ein bestimmtes Element zwar schnell gefunden werden, hat aber keinen Einfluss auf die Positionierung der Elemente in der Liste.

* Elemente können schnell gefunden werden (über Hashcodes)

* Kein Einfluss auf den Index

* Zugriff erfolgt über einen Schlüssel

Note: Hashcode: Int Wert welcher über Algorithmus berechnet wird


<!-- .slide: class="left" -->
### Beispiel Hashtable

```csharp
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
foreach (DictionaryEntry hashElements in hashTable) {
     Console.WriteLine($"Key: {hashElements.Key} Wert: {hashElements.Value}");
}
```


<!-- .slide: class="left" -->
## List `<T>`

* Zugriff über Index

* Kein schneller Zugriff (Dictionary ist schneller)

* Listen sind ideal für Schleifen

Damit diese verwendet werden kann, muss der folgende Namespace in das
Projekt eingebunden werden:

```csharp
using System.Collections.Generics;
```

Mehr zum Thema [List](https://docs.microsoft.com/de-de/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)


<!-- .slide: class="left" -->
### Beispiel List `<T>`

```csharp
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


<!-- .slide: class="left" -->
## Dictionary `<TKey, TValue>`

* Das [Dictionary](https://docs.microsoft.com/de-de/dotnet/api/system.collections.generic.dictionary-2?view=netframework-4.7.2) Stellt eine Auflistung von Schlüsseln und Werten dar

* Sehr effizient und schnelles Nachschlagen mit Schlüsseln (ist einer Hashtabelle oder einer Liste vorzuziehen)

* **TKey** Der Typ der Schlüssel im Wörterbuch.

* **TValue** Der Typ der Werte im Wörterbuch.


<!-- .slide: class="left" -->
### Beispiel Dictionary `<TKey, TValue>`

```csharp
string tempString;

Dictionary<string, string> dictionary = new Dictionary<string, string>();

dictionary.Add("tier1", "Hase");
dictionary.Add("tier2", "Hund");
dictionary.Add("tier3", "Esel");

if (dictionary.ContainsKey("tier1")) {
     Console.WriteLine($"Wert zum KEY tier1: {dictionary["tier1"]}");
}

if (dictionary.TryGetValue("tier1", out tempString)) {
     // analog Int32.TryParse(...)
     Console.WriteLine($"found Wert: {tempString}");
}

foreach (KeyValuePair<string, string> pair in dictionary) {
     Console.WriteLine($"Key: {pair.Key} Wert: {pair.Value});
}
```

Note: Gibt noch weitere wie z.B. HashSet, Queue, SortedList, Stack, ..

**VS** In VS z.B. List Verwendung zeigen mit Zuweisung von Objekten und Objekten mit Vererbung.
ÜBUNG Wetterstation
