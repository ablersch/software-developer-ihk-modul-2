# Übung - Banksystem

Programmieren Sie zur Wiederholung der Themen aus dem Modul II ein kleines Banksystem welches für einen Inhaber mehrere Konten verwalten kann. Bei der Umsetzung wie gelernt Klassen und Methoden einsetzen.

## Folgende Funktionen sollen möglich sein

* Erstellung eines neuen Kontos
* bearbeiten eines existierenden Kontos
* Löschen eines bestehenden Kontos
* Ausgeben aller Konten in sortierter Reihenfolge (nach Kontostand)

Konten sollen einen Inhaber samt Namen und Alter, einen Kontostand, ein Kreditlimit, eine laufende Kreditsumme und das Realgeld besitzen (Realgeld entspricht Kontostand abzüglich des durch Kredit vorhandenen Geldes).

Nicht alle Konten dürfen ein Kreditlimit (Kredit) besitzen. Erst wenn der Inhaber 18 Jahr alt ist.

## Auswahlmöglichkeiten

Die Auswahlmöglichkeiten sollen per Texteingabe auswählbar sein und bei Auswahl vertiefende Fragen stellen z.B. beim bearbeiten eines Kontos "Welches Konto", dann noch tiefer "Welche Eigenschaft", "Welcher Wert".

Die Anwendung soll dann wieder zum Ursprung springen und die selben Möglichkeiten bieten. Solange, bis der Benutzer das Programm durch einen bestimmten Text oder ein Zeichen beendet.

## Beachten

* Beim Ändern des Kreditlimits ist auf das Alter zu prüfen
* Beim vergeben eines Kredit ist auf den Kreditlimit zu prüfen

## Erweiterungen

* Bereits eingegeben Inhaber können aus einer Liste beim erstellen eines neuen Kontos ausgewählt werden.
* Es können Konten mit verschiedenen Währungen bestehen. Beachtet die Umrechnung in andere Währungen.
