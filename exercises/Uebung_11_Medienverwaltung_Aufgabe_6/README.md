# Übung - Medienverwaltung Aufgabe 6

Bei jedem Auftreten eines Leih- oder Rückgabefehlers soll automatisch ein Eintrag in einer Log-Datei _log.txt_ geschrieben werden. Zusätzlich soll die Meldung in der Konsole ausgegeben werden. 

Der Eintrag soll die Signatur beinhalten bei welcher es ein Problem gab. Nutzen sie dazu Ihre selbst erstellte Klassenbibliothek aus der "Logger Übung".

Um eine Klassenbibliothek einzubinden müssen Sie dem Projekt einen Verweis auf die DLL hinzufügen. Außerdem sollten Sie den Namespace der DLL in Ihr Projekt einbinden (`using`).

## Beispiel Ausgabe

```bash
Fehler beim Entleihen von Signatur 25265.
```