# Interfaces und abstrakte Klassen

Wie muss eine Klasse aussehen?

---

<!-- .slide: class="left" -->
## Was ist ein Interface (Schnittstelle)

Ein [Interface](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/keywords/interface) ist eine Sammlung von Methodensignaturen, Eigenschaften oder Ereignissen, die von einer Klasse implementiert werden müssen. Es ist ein Vertrag, der festlegt, welche Funktionalitäten eine Klasse bereitstellen muss, ohne deren konkrete Implementierung vorzugeben.

**Interfaces ermöglichen**:

**Abstraktion**: Der Fokus liegt auf dem "Was" und nicht dem "Wie".

**Polymorphismus**: Unterschiedliche Klassen können auf dieselbe Weise verwendet werden, wenn sie dasselbe Interface implementieren.

Note:
* wichtiges Konstrukt in der Programmierung, um Code sauber zu strukturieren.
* Jede Klasse die diesen Vertrag implementiert muss auch die im Vertrag definierten Member bereitstellen.
* Trennt und entkoppelt den Vertrag und die Implementierung.
* beschreibt eine Gruppe verwandter Methoden, die zu einer beliebigen Klasse oder Struktur gehören können.
* **Polymorphismus**: Überladen von Methoden; Vererbung und Methodenüberschreibung.

---

<!-- .slide: class="left" -->
## Interfaces (Schnittstellen)

* Werden definiert mit `interface`
* Die Schnittstellenmember besitzen selbst keine Codeimplementierung sondern nur Definitionen.
* Schnittstellenmember sind automatisch öffentlich.
* Sie dürfen keine Felder enthalten.
* Von einer Schnittstelle kann keine Instanz erstellt werden.
* Eine Klasse darf von mehreren Schnittstellen erben.

Note:
* `Interface`-Klasse beginnt mit "I"
* Sollte in einer eigenen Datei definiet werden.
* Keine Zugriffsmodifizierer zugelassen.
* Es müssen in einer Klasse, welche ein Interface einbindet, alle Methoden implementiert werden.

---

<!-- .slide: class="left" -->
## Vorteile und Anwendungsfälle

* **Definition von Standards/Verträgen**: Ein Interface definiert den Vertrag, den jede implementierende Klasse einhalten muss, ohne die interne Logik offenzulegen.
* **Flexibilität durch Mehrfachvererbung**: In C\# kann eine Klasse nur von einer Basisklasse erben, aber sie kann mehrere `Interfaces` implementieren.
* **Förderung der Testbarkeit**: Interfaces erleichtern Unit Tests durch die Verwendung von Mock-Objekten.
* **Erstellen von Plugins und Erweiterungen**: Nützlich in modularen Anwendungen, bei denen neue Funktionalitäten hinzugefügt werden können.
* **Strategien und Austauschbarkeit**: Verschiedene Implementierungen einer Funktionalität können durch Interfaces ausgetauscht werden.
* **Dependency Injection (DI)**: Interfaces sind in der Dependency Injection (DI) weit verbreitet, da sie das Einbinden von Abhängigkeiten (z. B. Services) erleichtern.

Note:
* zu 3: Ein Interface wie `ILogger` kann in Tests durch eine simulierte Implementierung ersetzt werden.
* zu 4: Ein Spiel könnte ein Interface `IWeapon` verwenden, sodass neue Waffentypen einfach hinzugefügt werden können.
* zu 5: Eine App, die verschiedene Authentifizierungsmechanismen (z. B. OAuth, JWT) unterstützt

---

<!-- .slide: class="left" -->
### Beispiel Interface

```csharp
public interface IMedien 
{
  int Signatur { get; set; }
  void List();
}

// Einbinden der Schnittstelle
class Zeitschriften : IMedien 
{
  public void List() 
  {
    Console.WriteLine("Ausgabe der Eigenschaften");
  }
  
  public int Signatur { get; set; }
}
```

Note:
* **VS** Interface erstellen
  * Quick Actions --> Pull up to Interface
* **ÜBUNG** Medienverwaltung Aufgabe 9

---

<!-- .slide: class="left" -->
## abstrakte Klassen

* Eine [abstrakte Klasse](https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members) stellt eine Basisklasse dar.

* Von einer abstrakten Klasse dürfen keine Objekte bzw. Instanzen erzeugt werden.

* Es kann nur von einer abstrakten Klasse geerbt werden.

* Alles was in dieser Klasse als abstrakt gekennzeichnet wird hat die ähnlichen Eigenschaften wie ein Interface:

  * Es dürfen keine Felder enthalten sein.

  * Die Member besitzen selbst keine Codeimplementierungen sondern nur Definitionen.

  * Eine Klasse die von einer abstrakten Klasse erbt muss die abstrakten Methoden implementieren.

  * In der abgeleiteten Klasse müssen die abstrakten Methoden mit [`override`](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/keywords/override) überschrieben werden.

Note: 
* z.B. geometrische Berechnung: 
  * Umfang gilt bei allen Klassen wie z.B. Kreis, Rechteck oder Dreieck, ist aber bei allen anderst zu berechnen.

---

<!-- .slide: class="left" -->
### Beispiel abstrakte Klasse

```csharp
public abstract class Medien 
{
  abstract public void List();

  protected void Ausgabe() 
  {
    Console.WriteLine("Ausgabe");
  }
}

class Zeitschriften : Medien 
{
  public override void List() 
  {
    Console.WriteLine("Eigenschaften");
    Ausgabe();
  }
}
```

---

<!-- .slide: class="left" -->
## Interface vs abstrakte Klasse

**Interface**:
  * Eine Klasse kann mehrere Interfaces einbinden.
  * Ein Interface besitzt nur Definitionen von öffentlichen Eigenschaften und Methoden welche später selbst programmiert werden müssen.
  * Kein Konstruktor möglich.

**abstrakte Klasse**:
  * Es kann nur von einer abstrakten Klasse geerbt werden.
  * Eine abstrakte Klasse kann Eigenschaften und Methoden vererben und zusätzlich Methodendefinitionen definieren die implementiert werden und ausprogrammiert werden müssen.
  * Konstruktoren können definiert werden.

---

<!-- .slide: class="left" -->
### Anwendungsfälle

**Interfaces** benutzen um inhaltlich verschiedenen Klassen eine bestimmte Funktionalität zu bieten.

**Abstrakte Klassen** nutzen als Basisklasse um inhaltlich gleichen Klassen eine gemeinsame Basis (die aber verändert oder erweitert werden kann) zu geben und zu erzwingen das bestimmte Methoden implementiert werden.
