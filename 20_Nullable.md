# Null und Nullable

Was ist `null`, wo wird es eingesetzt und was muss beachtet werden?

---

<!-- .slide: class="left" -->
## Was bedeutet `null`?

`null` ein spezieller Wert, der anzeigt, dass eine Variable keinen gültigen Wert oder keine Referenz auf ein Objekt hat.

```csharp
string name = null;  // "name" verweist auf nichts, sie enthält keinen String.
```

Note:
* Für Referenztypen (wie `string`, `object`, `Arrays`): `null` bedeutet, dass die Variable auf kein Objekt verweist. 

* Für Werttypen (wie `int`, `double`, `bool`): Werttypen können standardmäßig nicht `null` sein, weil sie immer einen Wert enthalten müssen. Es sei denn, sie werden als nullable markiert, zum Beispiel `int?`

---

<!-- .slide: class="left" -->
## Verwendung von `null`?

`null` ist nützlich, um anzuzeigen, dass eine Variable derzeit keinen gültigen Wert hat oder nicht initialisiert wurde.

Oft wird `null` als Rückgabewert verwendet, um anzuzeigen, dass eine Methode kein Ergebnis hat.

```csharp
public string? FindName(int id)
{
    if (id == 1)
        return "Anna";
    else
        return null;  // Kein Name für diese ID gefunden.
}
```

Der Umgang mit `null` erfordert Vorsicht, weil der Versuch, auf eine Variable zuzugreifen, die `null` ist, zu einer `NullReferenceException` führen kann.

---

<!-- .slide: class="left" -->
## Null-Prüfung

Um solche Fehler zu vermeiden, sollte immer geprüft werden, ob eine Variable `null` ist, bevor man auf sie zugreift:

```csharp
string? name = null;

if (name != null)
{
    Console.WriteLine(name.Length);  // Sicher, weil "name" nicht null ist.
}
else
{
    Console.WriteLine("Name ist null");
}
```

Der `??`-Operator in C# wird als **Null-Coalescing-Operator** bezeichnet. Er wird verwendet, um eine Null-Prüfung durchzuführen und einen Standardwert anzugeben, falls eine Variable `null` ist.

```csharp
string result = name ?? "Unbekannt";  // Wenn "name" null ist, wird "Unbekannt" verwendet.
```

Note:
Der `??`-Operator wird oft verwendet, um `null`-Werte kurz und effizient zu behandeln, ohne explizit eine `if`-Abfrage zu schreiben.

Wenn der linke Operand `null` ist, wird der rechte Operand zurückgegeben.

Besonders hilfreich bei der Initialisierung von Variablen mit einem Standardwert, wenn die Möglichkeit besteht, dass sie `null` sein könnten.

---

<!-- .slide: class="left" -->
## Was bedeutet nullable?

In C# bedeutet "nullable," dass ein Datentyp einen zusätzlichen Zustand haben kann, der `null` ist. Normalerweise können sogenannte Werttypen wie `int`, `double`, oder `bool` keinen `null`-Wert annehmen. Nur Referenztypen wie `string`, `object` oder `arrays` konnten ursprünglich auf `null` gesetzt werden.

---

<!-- .slide: class="left" -->
## In früheren Versionen

In älteren C#-Versionen (vor C# 8.0) konnte man `null` einem `string` zuweisen, ohne `string?` zu verwenden:

```csharp
string value = null;  // Das funktioniert in älteren Versionen.
```

Der Grund, warum `string?` eingeführt wurde, ist die Verbesserung der `Null`-Sicherheit des Codes.

---

<!-- .slide: class="left" -->
## Warum `string?` verwenden?

Vor C# 8.0 war es möglich, einem string den Wert `null` zuzuweisen, aber es gab keine Möglichkeit für den Compiler, dich darauf hinzuweisen, dass du bei der Verwendung dieser Variable vorsichtig sein musst. Das führte oft zu `NullReferenceException`-Fehlern, wenn versucht wurde, auf einen `null`-Wert zuzugreifen:

```csharp
string name = null;
Console.WriteLine(name.Length);  // Führt zu NullReferenceException!
```

---

<!-- .slide: class="left" -->
## Verbesserte Sicherheit mit `string?`

Seit C# 8.0 gibt es die sogenannten **nullable reference type**. Wenn du `string?` verwendest, gibst du explizit an, dass diese Variable `null` sein kann. Dadurch wird der Compiler strenger und fordert dich auf, mit möglichen `null`-Werten vorsichtig umzugehen. Gleichzeitig wird der Standard-Referenztyp, wie `string`, als nicht-nullable betrachtet.

Das bedeutet, dass du dem Compiler sagst: "`string` darf keinen `null`-Wert enthalten", und er wird dich warnen, wenn man es versucht:

```csharp
string? name = null;  // Erlaubt, weil es ein nullable string ist.
if (name != null)
{
    Console.WriteLine(name.Length);  // Sicher, weil wir vorher überprüft haben, dass "name" nicht null ist.
}
```

Ohne das `?`:

```csharp
string name = null;  // Der Compiler gibt jetzt eine Warnung aus!
```

Note: 
Die Einstellung `<Nullable>enable</Nullable>` in der Projektdatei von VS aktiviert die **nullable reference types**-Funktionalität in C#.

Wenn du die Einstellung `enable` verwendest, werden alle Referenztypen standardmäßig als nicht-nullable betrachtet. 
Das bedeutet, dass du dem Compiler mitteilst, dass diese Variablen niemals null sein sollen.

Vorteile:
* Erhöhte Code-Sicherheit
* Expliziter Code: Es wird klarer, welche Variablen null sein dürfen und welche nicht. Das erhöht die Lesbarkeit und Wartbarkeit des Codes.
* Frühe Fehlererkennung

---

<!-- .slide: class="left" -->
## Zusammenfassung
* Vor C# 8.0: Alle Referenztypen (`string`, `object`, etc.) konnten `null` sein. Es gab keine Compiler-Unterstützung, um dich vor `null`-Fehlern zu warnen.

* Ab C# 8.0: Mit `nullable reference types` kannst du klar angeben, welche Variablen `null` sein dürfen (`string?`) und welche nicht (`string`). Das hilft, Fehler zu vermeiden und sichereren Code zu schreiben.

`string?` ist also ein hilfreiches Werkzeug, um `null`-Fehler frühzeitig zu erkennen und deinen Code robuster zu machen.

Note: **Übung** tbd