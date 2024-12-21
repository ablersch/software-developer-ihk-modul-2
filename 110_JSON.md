# JSON

JavaScript Object Notation

---

<!-- .slide: class="left" -->
## JSON (JavaScript Object Notation)

[JSON](https://www.json.org/json-de.html) ist ein beliebtes Format, um Daten zwischen verschiedenen Systemen auszutauschen, z. B. zwischen einem Webserver und einem Client.

* **Einfach und lesbar:** JSON verwendet eine sehr einfache Struktur, die für Menschen leicht verständlich ist.
* **Schlüssel-Wert-Paare:** JSON-Daten bestehen aus Schlüssel-Wert-Paaren, die in geschweiften Klammern {} eingeschlossen sind. Dies ähnelt Objekten in vielen Programmiersprachen.
* **Kompatibilität:** JSON ist plattformunabhängig und kann problemlos zwischen verschiedenen Systemen und Programmiersprachen ausgetauscht werden.

Note: JSON (JavaScript Object Notation) ist ein leichtgewichtiges Datenformat, das oft verwendet wird, um Daten zwischen Servern und Webanwendungen auszutauschen.

---

<!-- .slide: class="left" -->
## JSON Struktur

JSON verwendet zwei Hauptstrukturen:

1. **Objekte:** Diese bestehen aus Schlüssel-Wert-Paaren, wobei der Schlüssel immer ein String ist und der Wert entweder:
   * ein weiterer String, 
   * eine Zahl, 
   * ein Array, 
   * ein weiteres Objekt, 
   * `true`, `false`, 
   * oder `null` 
  
    sein kann.

2. **Arrays:** Arrays sind geordnete Listen von Werten, die ebenfalls in JSON-Format vorliegen können (z. B. Strings, Zahlen, Objekte, Arrays, etc.).

---

<!-- .slide: class="left" -->
## Beispiel

```json
{
  "Vorname": "Max",
  "Nachname": "Mustermann",
  "Alter": 30,
  "Beruf": "Entwickler",
  "Hobbys": ["Programmieren", "Lesen", "Laufen"],
  "Verheiratet": true,
  "Wohnadresse":
  {
    "Strasse": "Bach Weg",
    "Hausnummer": 12,
    "Stadt": "Ulm",
    "PLZ": 88888
  }
}
```

[Json to C#](http://json2csharp.com/)

Note:
* Schlüssel-Wert-Paare: 
  * `"Vorname": "Max"` (der Wert ist ein String) 
  * `"Alter": 30` (der Wert ist eine Zahl).
* Array: `"Hobbys": ["Programmieren", "Lesen", "Laufen"]`, wobei die Hobbys als Liste von Strings dargestellt werden.
* Boolean-Wert: `"Verheiratet": true` ist ein Boolescher Wert.
* Objekt `"Wohnadresse"`


---

<!-- .slide: class="left" -->
## Verwendung von JSON:

* **Datenübertragung:** JSON wird häufig verwendet, um Daten zwischen einem Server und einer Webanwendung zu senden und zu empfangen (z. B. in REST-APIs).
* **Speichern von Konfigurationen:** Es wird oft verwendet, um Konfigurationsdaten in Dateien zu speichern, die von Programmen gelesen werden.
* **Datenbanken:** Einige NoSQL-Datenbanken wie MongoDB verwenden JSON-ähnliche Strukturen zum Speichern von Daten.


