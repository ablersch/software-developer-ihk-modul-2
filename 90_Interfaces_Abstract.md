# Interfaces und abstrakte Klassen

Wie muss eine Klasse aussehen?


<!-- .slide: class="left" -->
## Schnittstellen (Interfaces)

* [Schnittstellen](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/keywords/interface) beschreiben eine Gruppe verwandter Methoden, die zu einer beliebigen Klasse oder Struktur gehören können. 

* Sie dürfen keine Felder(Attribute) enthalten.

* Schnittstellenmember sind automatisch öffentlich.

* Die Schnittstellenmember besitzen selbst keine Codeimplementierung sondern nur Definitionen.

* Eine Klasse die von einer Schnittstelle erbt muss die Methoden implementieren.

* Eine Klasse darf von mehreren Schnittstellen erben.

* Interfaces werden häufig in der Praxis verwendet, wenn mehrere Programmierer an einem Projekt beteiligt sind. Oder um festzulegen das verschiedene Klassen, immer die gleichen Member implementieren.

Note: Interface Klasse beginnt mit "I"

Schnittstellen können aus Methoden, Eigenschaften und Ereignissen bestehen.

Keine Zugriffsmodifizierer zugelassen.

Jeder muss in der Klasse welche ein Interface nutzt alle Methoden implementieren

**VS** Interface


<!-- .slide: class="left" -->
### Beispiel Interface

```csharp
public interface IMedien {
  int Signatur {get; set;}
  void List();
}

class Zeitschriften : IMedien {
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


<!-- .slide: class="left" -->
## abstrakte Klassen

* Eine [abstrakte Klasse](https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members) stellt eine Basisklasse dar.

* Von einer abstrakten Klasse dürfen keine Objekte bzw. Instanzen erzeugt werden.

* Es kann nur von einer abstrakten Klasse geerbt werden.

* Alles was in dieser Klasse als abstrakt gekennzeichnet wird hat die ähnlichen Eigenschaften wie ein Interface:

  * Es dürfen keine Felder(Attribute) enthalten sein.

  * Die Member besitzen selbst keine Codeimplementierungen sondern nur Definitionen.

  * Eine Klasse die von einer abstrakten Klasse erbt muss die abstrakten Methoden implementieren.

  * In der abgeleiteten Klasse müssen die abstrakten Methoden mit [`override`](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/keywords/override) überschrieben werden.

Note: z.B. geometrische Berechnung: Umfang gilt bei allen Klassen (Kreis, Rechteck, Dreieck), ist aber überall anderst zu berechnen.


<!-- .slide: class="left" -->
### Beispiel abstrakte Klasse
```csharp
public abstract class Medien {
  abstract public void List();

  protected void Ausgabe() {
    Console.WriteLine("Ausgabe");
  }
}

class Zeitschriften : Medien {

  public override void List() {
    Console.WriteLine("Eigenschaften");
    Ausgabe();
  }
}
```


<!-- .slide: class="left" -->
## Interface vs abstrakte Klasse

* Interface:

  * Ein Klasse kann mehrere Interfaces einbinden.

  * Ein Interface besitzt nur Definitionen von öffentlichen Eigenschaften und Methoden welche später selbst ausprogrammiert werden müssen.

* abstrakte Klasse:

  * Es kann nur von einer abstrakten Klasse geerbt werden.

  * Eine abstrakte Klasse kann Felder und Methoden vererben und zusätzlich Methodenrümpfe (Methodendefinitionen) definieren die implementiert werden und ausprogrammiert werden müssen.


<!-- .slide: class="left" -->
**Interfaces benutzen** um inhaltlich verschiedenen Klassen eine bestimmte Funktionalität zu bieten.

**Abstrakte Klassen nutzen** als Basisklasse um inhaltlich gleichen Klassen eine gemeinsame Basis zu geben und zu erzwingen das bestimmte Methoden implementiert
werden.

Note: Übung Medienverwaltung 5
