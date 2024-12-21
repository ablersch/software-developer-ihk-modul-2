# Übung - Medienverwaltung Aufgabe 8

Nun sollen die Daten welche eingegeben wurden auch nach dem Beenden der Anwendung zur Verfügung stehen und bei einem Start der Anwendung geladen werden.

## Daten speichern

Beim beenden der Anwendung die Daten in eine JSON-Datei serialisieren. Dazu folgendes umstellen:

* alle Felder müssen in `public` Properties umgestellt werden.
* Jede Klasse braucht einen weiteren Konstruktor mit all den Properties als Parameter die in dieser Klasse vorhanden sind. Diese dann auf die Properties mappen.
* Diesem Konstruktur das Attribute `[JsonConstructor]` zuweisen.
* Die `Medium` Klasse benötigt die Klassen-Attribute:
  * `[JsonDerivedType(typeof(Buch), "Buch")]`
  * `[JsonDerivedType(typeof(Video), "Video")]`

## Daten laden

Beim starten der Anwendung soll überprüft werden ob eine Datei mit Daten vorhanden ist. Wenn ja sollen diese Daten deserialisiert werden.

## Erweitert

* Darauf achten `try` und `catch` zum Abfangen von Fehlern zu benutzen.
* Wie kann der Inhalt der JSON-Datei optimiert bzw schöner lesbar gemacht werden?