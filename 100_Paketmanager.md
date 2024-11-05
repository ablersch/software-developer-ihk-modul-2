# Paketmanager 

Paketmanager in C#

---

<!-- .slide: class="left" -->
## NuGet

[NuGet](https://www.nuget.org/) ist der Paketmanager für .NET, der es Entwicklern ermöglicht, Bibliotheken und Tools einfach zu finden, zu installieren und zu verwalten. Es bietet eine zentrale Anlaufstelle für das Teilen von wiederverwendbarem Code.

* NuGet-Pakete werden von einer öffentlichen oder privaten Quelle bezogen.

Note: 
* Packages zeigen auf NuGet Website.
* eigene Pakete in einem privaten Feed hosten z.B. Firmen.
* für eigene Pakete wird eine `.nuspec`-Datei benötigt.

---

<!-- .slide: class="left" -->
## Paketinstallation

* **Visual Studio:** NuGet-Pakete können über den NuGet-Paket-Manager in Visual Studio installiert werden.
  * Gehe auf „Projekt > NuGet-Pakete verwalten“.
  * Suche nach einem Paket, wähle die Version aus und installiere es.
* **Package Manager Console**: Sie bietet eine Alternative zur grafischen Benutzeroberfläche und erlaubt Entwicklern, direkt mit der NuGet-Paketverwaltung zu interagieren.
  
```bash
Install-Package <Paketname>
```

* **.NET CLI:** Pakete können auch mit der Kommandozeile installiert werden:

```bash
dotnet add package <Paketname>
```

---

<!-- .slide: class="left" -->
## Paketverwaltung

* **Pakete aktualisieren:** Pakete können im NuGet-Paket-Manager oder mit der CLI aktualisiert werden:

```bash
dotnet add package <Paketname> --version <Version>
```

```bash
Update-Package
```

* **Pakete deinstallieren:** Um ein Paket zu entfernen, kannst du den NuGet-Paket-Manager oder die CLI verwenden:

 ```bash
 dotnet remove package <Paketname>
```

Note: `Update-Package` damit kannst du ein Paket in allen Projekten der Lösung gleichzeitig aktualisieren:

---

<!-- .slide: class="left" -->
## Abhängigkeiten

* Jedes NuGet-Paket kann Abhängigkeiten zu anderen Paketen haben. Diese werden automatisch mitinstalliert.
* Wenn du ein Paket installierst, werden auch seine Abhängigkeiten in deinem Projekt geladen.

---

<!-- .slide: class="left" -->
## Vorteile von NuGet

* **Wiederverwendbarkeit:** Einmal erstellter Code kann in verschiedenen Projekten verwendet werden.
* **Versionierung:** Es ist einfach, verschiedene Versionen eines Pakets zu verwalten.
* **Einfache Integration:** NuGet erleichtert die Integration von externen Bibliotheken und Tools.

Note: 
* **ÜBUNG** Medienverwaltung Aufgabe 6


