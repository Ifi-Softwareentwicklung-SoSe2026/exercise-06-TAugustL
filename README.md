[![LiaScript Course](https://raw.githubusercontent.com/LiaScript/LiaScript/master/badges/course.svg)](https://liascript.github.io/course/?https://raw.githubusercontent.com/Ifi-Softwareentwicklung-SoSe2026/exercise-06-TAugustL/refs/heads/main/README.md)

# Aufgabe 06

Softwareentwicklung SoSe2026
============================

## GitHub Issues – Kurzanleitung

Kategorisierung
====================

Issues können in GitHub durch Labels und Typen kategorisiert werden, um sie thematisch und nach Art zu ordnen.


![Die rechte Seite des Bildschirms zur Erstellung eines Issues mit allen Optionen für Kategorisierung und Priorisierung.](img/Github_GUI_Overview.png "Die rechte Seite des Bildschirms zur Erstellung eines Issues mit allen Optionen für Kategorisierung und Priorisierung.")<!-- style="height: 10cm;" -->


Labels
--------------------

Labels ordnen Issues thematisch zu und erleichtern das Filtern und Sortieren.

- **Agentenbezogen:**
  - `assignment` – Issues, die von Maria als Aufgaben zugewiesen werden.
  - `kevin` – Issues, die für den KI-Agenten Kevin bestimmt sind.
  - `student-task` – Übungsaufgaben für Studierende.

- **Arbeitsbereich:**
  - `csharp` – Issues, die die Implementierung in C# betreffen.
  - `documentation` – Issues, die Dokumentation oder die `README.md` betreffen.
  - `enhancement` – Issues für neue Funktionen oder Erweiterungen.

- **Status:**
  - `blocked` – Issues, die aufgrund fehlender Abhängigkeiten oder Informationen blockiert sind.
  - `bug` – Issues, die einen Fehler oder unerwartetes Verhalten melden.
  - `question` – Issues, die Klärungsbedarf haben.

- **Triage:**
  - `help wanted` – Issues, bei denen Unterstützung benötigt wird.
  - `duplicate` – Issues, die bereits als Duplikat erkannt wurden.
  - `invalid` – Issues, die ungültig oder nicht relevant sind.
  - `wontfix` – Issues, die bewusst nicht behoben werden.


![Labeloptionen in GitHub.](img/Github_GUI_Labels.png"Labeloptionen in GitHub.")<!-- style="height: 8cm;" -->

Typen
--------------------

Typen definieren die Art des Issues und passen die verfügbaren Felder an. Sie helfen, Issues nach ihrem Zweck zu klassifizieren.


![Ausgewählte Typ-Optionen](img/Github_GUI_Type.png "Ausgewählte Typ-Optionen")<!-- style="height: 8cm;" -->

- **Bug** – Meldet einen Fehler im Code oder System.
- **Feature** – Bezeichnet eine neue Funktion oder Verbesserung.
- **Task** – Beschreibt eine allgemeine Aufgabe, die erledigt werden muss.

Priorisierung
--------------------

Jeder Typ ermöglicht die Festlegung einer Priorität, um die Wichtigkeit und Dringlichkeit des Issues anzuzeigen.


![Angezeigte Prioritätsoptionen](img/Github_GUI_Fields_Prio.png "Angezeigte Prioritätsoptionen")<!-- style="height: 8cm;" -->

Prioritätsstufen:

- **urgent** – Dringend, muss sofort bearbeitet werden.
- **high** – Hoch, sollte bald bearbeitet werden.
- **medium** – Mittel, normale Priorität.
- **low** – Niedrig, kann später bearbeitet werden.

## Aufgabe

## **User Story: Digitale Flächenverwaltungsplattform für Bauvorhaben**

Als Bauamtsmitarbeiter möchte ich eine digitale Plattform zur Verwaltung von Bauflächen und Bauvorhaben nutzen, damit ich Bauanträge effizient bearbeiten, Flächen zuweisen und den Fortschritt von Bauprojekten nachverfolgen kann.

### **Akzeptanzkriterien**

1. **Grundlegende Flächenverwaltung**
====================

- Das System muss Grundstücke und Bauflächen verwalten können (Flurstücknummer („0015 00012 001/002“ (Flur 0015, Flurstück 00012, Teilfläche 001/002)), Größe, Lage, aktuelle Nutzung (Gewerbe, Landwirtschaft, Forst, Wohnnutzung, Brachfläche, ...), Bebaubarkeit (ja, nein, auflagen). Ein Grundstück kann mehrere Bauflächen enthalten.
- Jede Fläche muss mit Metadaten wie B-Plan-Nummer ("BP-2022-089 – Wohngebiet Leipzig-Nord"), Bodenrichtwert ($500 €/m^2$) und Eigentümer verknüpft sein.
- Flächen müssen als `frei`, `reserviert` oder `bebaut` markiert werden können.

2. **Bauvorhaben verwalten**
====================

- Das System muss Bauvorhaben anlegen und verknüpfen können mit:
  - Antragsteller (Name, Kontaktdaten, Firma)
  - Geplante Nutzung (Wohngebäude, Gewerbe, Infrastruktur)
  - Zeitplan (Beginn, Fertigstellung)
  - Status (Antrag eingereicht, genehmigt, abgelehnt, in Bearbeitung, abgeschlossen)
- Jedes Bauvorhaben muss einer oder mehreren Flächen zugeordnet werden können.

## Initialer Arbeitsablauf

Maria erstellt automatisch ein Assignment-Issue, sobald Ihr Repository durch GitHub Classroom angelegt wurde.

Bearbeiten Sie zuerst dieses Maria-Issue:

1. Erstellen Sie einen eigenen Branch.
2. Ändern Sie den LiaScript-Course-Link oben in dieser `README.md`, sodass er auf Ihr studentisches Repository zeigt.
3. Legen Sie ein leeres C#-Konsolenprojekt an:

   ```bash
   dotnet new console -n Baufflaechenverwaltung
   ```

4. Erstellen Sie eine Pull Request nach `main` und verknüpfen Sie diese mit dem Maria-Issue über `Closes #<Issue-Number>`.
5. Warten Sie auf die automatische Review von Lisa und arbeiten Sie Feedback auf demselben Branch ein.
6. Nach dem Merge erstellen Sie ein eigenes Issue für Kevin.

## Kevin aktivieren

Kevin wird in dieser Übung über ein Label aktiviert.

Erstellen Sie nach der vorbereitenden PR ein neues GitHub-Issue:

- Das Issue muss von Ihnen als Studierende formuliert werden.
- Das Issue muss das Label `kevin` erhalten.
- Das Issue soll Kevin konkret beauftragen, die User Story und Akzeptanzkriterien aus dieser `README.md` in C# umzusetzen.
- Kevin erstellt anschließend eine Pull Request nach `main`.

Kevin bearbeitet keine Issues von Maria oder Jürgen direkt. Sie müssen diese Anforderungen erst in ein eigenes, konkret formuliertes Kevin-Issue übersetzen.

Kevin kann in dieser Übung zwei Arten von Issues bearbeiten:

- **C#-Umsetzung:** Beschreiben Sie konkret, welche Funktionalität im C#-Projekt geändert oder ergänzt werden soll.
- **UML-Dokumentation:** Beschreiben Sie konkret, dass Kevin das UML-Klassendiagramm im Abschnitt „UML-Dokumentation“ dieser `README.md` ergänzen oder verbessern soll.

Formulieren Sie UML-Aufgaben eindeutig mit Begriffen wie `UML`, `PlantUML`, `Klassendiagramm`, `README.md` oder `Klassenstruktur`, damit Kevin die Aufgabe als Dokumentationsauftrag erkennt.

## Lisa Review

Lisa reviewed Pull Requests automatisch.

- Für C#-Pull-Requests wartet Lisa auf den GitHub Actions Workflow `dotnet-build`.
- Für UML-/README-Pull-Requests prüft Lisa, ob der PlantUML-Block im Abschnitt „UML-Dokumentation“ fachlich sinnvoll und LiaScript-kompatibel ist.
- Die CI-Logs und die Konsolenausgabe werden in Lisas Review-Kontext einbezogen.
- Wenn Lisa Änderungen anfordert, arbeiten Sie oder Kevin das Feedback auf demselben Branch ein.
- Ein Merge nach `main` erfolgt erst nach positiver Review.

## Jürgen Issues und Triage

Nach Kevins erster Umsetzung erstellt Jürgen weitere Issues. Diese sind bewusst teilweise unscharf formuliert.

Ihre Aufgabe ist dann:

- Anforderungen aus Jürgens Issues verstehen und trennen.
- Aus dem ersten unscharfen Jürgen-Issue zwei eigene, konkrete Issues erstellen.
- In beiden eigenen Issues das ursprüngliche Jürgen-Issue mit `#<Issue-Number>` referenzieren.
- Issues mit passenden Labels kategorisieren.
- Priorität, Aufwand und Abhängigkeiten einschätzen.
- Höchstens eines der beiden Issues mit `kevin` labeln; mindestens eines bearbeiten Sie selbst per Branch und Pull Request.
- Wenn Sie Kevin mit der UML-Dokumentation beauftragen, muss das Issue ausdrücklich den Abschnitt „UML-Dokumentation“ oder das UML-Klassendiagramm in `README.md` nennen.
- Bei späteren Jürgen-Issues nur dann ein konkretes Kevin-Issue erstellen und mit `kevin` labeln, wenn Sie die Aufgabe bewusst an Kevin delegieren wollen.
- Nicht alles muss sofort umgesetzt werden; begründen Sie, was zurückgestellt oder nicht bearbeitet wird.

## UML-Dokumentation

Falls im Verlauf der Jürgen-Issues ein UML-Klassendiagramm gefordert wird, ergänzen Sie es in diesem Abschnitt.

```text @plantUML
@startuml

@enduml
```
@plantUML.eval(png)

## Aufgabenmaterial

- [Agent-Workflow und interne Aufgabenstruktur](task.md)
