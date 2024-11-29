# Interfaces und abstrakte Klassen

Wie muss eine Klasse aussehen?

---

<!-- .slide: class="left" -->
## Was ist ein [Interface]((https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/keywords/interface)) (Schnittstelle)

* wichtigstes Konstrukt in der Programmierung, um Code sauber zu strukturieren.
* Definiert einen Vertrag.
* Jede Klasse die diesen Vertrag implementiert muss auch die im Vertrag definierten Member bereitstellen.
* Trennen und entkoppeln den Kontrakt und die Implementierung.
* beschreiben eine Gruppe verwandter Methoden, die zu einer beliebigen Klasse oder Struktur gehören können.

---

<!-- .slide: class="left" -->
## Interfaces (Schnittstellen)

* Werden definiert mit `interface`
* Die Schnittstellenmember besitzen selbst keine Codeimplementierung sondern nur Definitionen.
* Schnittstellenmember sind automatisch öffentlich.
* Sie dürfen keine Felder enthalten.
* Eine Klasse darf von mehreren Schnittstellen erben.
* Von einer Schnittstelle kann keine Instanz erstellt werden.

Note:

* `Interface`-Klasse beginnt mit "I"
* Schnittstellen können aus Methoden, Eigenschaften und Ereignissen bestehen.
* Keine Zugriffsmodifizierer zugelassen.
* Es müssen in einer Klasse, welche ein Interface einbindet, alle Methoden implementiert werden.

---

<!-- .slide: class="left" -->
## Anwendungsfälle

* Codedefinition von der Implementierung trennen.
* Damit Klassen einfach testbar werden.
* Um Sicherheit zu erreichen, sollten bestimmte Details ausgeblendet werden und nur die wichtigen Details eines Objekts (einer Schnittstelle) angezeigt werden.
* C# unterstützt keine "Mehrfachvererbung". Mit Schnittstellen kann dies jedoch erreicht werden, da die Klasse mehrere Schnittstellen implementieren kann.

---

<!-- .slide: class="left" -->
### Beispiel Interface

```csharp []
public interface IMedien 
{
  int Signatur {get; set;}
  void List();
}

// Einbinden der Schnittstelle
class Zeitschriften : IMedien 
{
  public void List() {
    Console.WriteLine("Ausgabe der Eigenschaften");
  }
  
  public int Signatur {
    get{...}
    set{...}
  }
  ...
}
```

Note:

* **VS** Interface zeigen

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

Note: z.B. geometrische Berechnung: Umfang gilt bei allen Klassen (Kreis, Rechteck, Dreieck), ist aber überall anderst zu berechnen.

---

<!-- .slide: class="left" -->
### Beispiel abstrakte Klasse

```csharp []
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

* Interface:
  * Eine Klasse kann mehrere Interfaces einbinden.
  * Ein Interface besitzt nur Definitionen von öffentlichen Eigenschaften und Methoden welche später selbst programmiert werden müssen.
  * Kein Konstruktor möglich

* abstrakte Klasse:
  * Es kann nur von einer abstrakten Klasse geerbt werden.
  * Eine abstrakte Klasse kann Felder und Methoden vererben und zusätzlich Methodenrümpfe (Methodendefinitionen) definieren die implementiert werden und programmiert werden müssen.
  * Konstruktoren können definiert werden

---

<!-- .slide: class="left" -->
### Anwendungsfälle

**Interfaces benutzen** um inhaltlich verschiedenen Klassen eine bestimmte Funktionalität zu bieten.
**Abstrakte Klassen nutzen** als Basisklasse um inhaltlich gleichen Klassen eine gemeinsame Basis (die aber verändert oder erweitert werden kann) zu geben und zu erzwingen das bestimmte Methoden implementiert werden.

Note: 
**ÜBUNG** Medienverwaltung Aufgabe 9 (noch weiter ausarbeiten)