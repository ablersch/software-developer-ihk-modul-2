# Übung - Flugzeug

Erstellen Sie ein Programm mit einer Klasse `Flugzeug`, welches das Fliegen mittels der Konsolenausgabe simuliert.
Hierbei soll die Zielgeschwindigkeit eingegeben werden und beim Beschleunigen/Bremsen ausgegeben werden.

Es werden Methoden zum Beschleunigen und Bremsen benötigt, in denen die Zielgeschwindigkeit als Parameter übergeben werden soll.

## Erweiterungen

* Wenn die eingegebene Zielgeschwindigkeit mit der momentanen Geschwindigkeit übereinstimmen sollte, wird "Das Flugzeug fliegt bereits mit ... km/h !" ausgegeben.

* Wird eine Zielgeschwindigkeit von 0 eingeben landet das Flugzeug und das Programm wird beendet.


## Beispiel Ausgabe

```bash
Zum landen: 0 km/h eingeben
Zum Starten: beliebige ganze Zahl eingeben

Geschwindigkeit eingeben:9.5
Bitte ganze Zahl eingeben

Geschwindigkeit eingeben:20
Flugzeug beschleunigt auf 20 km/h
Geschwindigkeit eingeben:5
Flugzeug reduziert auf 5 km/h
Geschwindigkeit eingeben:0
Flugzeug reduziert auf 0 km/h
Flugzeug gelandet
```
