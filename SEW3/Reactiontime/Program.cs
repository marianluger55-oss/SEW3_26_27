using System.Diagnostics;
using System.Globalization;

namespace VokalReaktion;

// Datensatz für einen Highscore-Eintrag.
// "record" erzeugt automatisch Konstruktor, Properties (unveränderlich) und Gleichheitsvergleich.
record HighScore(string Name, int Punkte, double ReaktionMs, DateTime Datum);

class Program
{
    // ---------- Konfiguration (Konstanten) ----------
    const string DateiName = "highscores.txt"; // Datei, in der die Bestenliste gespeichert wird
    const int Runden = 15;                     // Anzahl der Buchstaben pro Spiel
    const int ReaktionsFensterMs = 1500;       // So lange hat man Zeit, nach dem Buchstaben zu reagieren
    const int MaxEintraege = 10;               // Maximale Länge der Bestenliste
    const string Vokale = "AEIOU";
    const string Konsonanten = "BCDFGHJKLMNPQRSTVWXYZ";

    // Ein gemeinsamer Zufallsgenerator für das ganze Programm
    static readonly Random Zufall = new();

    static void Main()
    {
        Console.Title = "Vokal-Reaktionstest";

        // 1) Name eingeben
        // Wiederholen, bis ein nicht-leerer Name vorliegt.
        // Strichpunkte werden entfernt, weil ";" in der Highscore-Datei als Trennzeichen dient.
        string name;
        do
        {
            Console.Write("Bitte Namen eingeben: ");
            name = (Console.ReadLine() ?? "").Trim().Replace(";", "");
        } while (name.Length == 0);

        // 2) Highscores einlesen und anzeigen
        var scores = LadeHighScores();
        ZeigeHighScores(scores);

        // Spielanleitung
        Console.WriteLine();
        Console.WriteLine($"Hallo {name}! Es erscheinen {Runden} Buchstaben in zufälligen Abständen.");
        Console.WriteLine("Bei einem VOKAL (A, E, I, O, U) sofort LEERTASTE drücken.");
        Console.WriteLine("Bei Konsonanten NICHT drücken.");
        Console.WriteLine("\nStart mit beliebiger Taste ...");
        Console.ReadKey(true); // true = Taste nicht auf der Konsole ausgeben

        // 3) Spiel
        // Zähler für Punkte und die einzelnen Ereignisarten
        int punkte = 0, treffer = 0, verpasst = 0, falschAlarm = 0, fehlstarts = 0;
        var reaktionen = new List<double>(); // Reaktionszeiten aller richtigen Treffer (für den Durchschnitt)

        for (int runde = 1; runde <= Runden; runde++)
        {
            Console.Clear();
            Console.WriteLine($"Runde {runde}/{Runden}   Punkte: {punkte}\n");

            // --- Wartephase ---
            // Zufällige Wartezeit zwischen 1 und 3,5 Sekunden.
            // Wird in dieser Zeit eine Taste gedrückt, zählt das als Fehlstart.
            int warten = Zufall.Next(1000, 3500);
            var sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < warten)
            {
                if (Console.KeyAvailable) // Wurde eine Taste gedrückt?
                {
                    Console.ReadKey(true); // Taste "verbrauchen"
                    fehlstarts++;
                    punkte -= 50;
                    Console.WriteLine("Fehlstart! (-50)");
                    Thread.Sleep(800);

                    // Neue Wartezeit würfeln und Stoppuhr neu starten
                    warten = Zufall.Next(1000, 3500); // neu warten
                    sw.Restart();
                    Console.Clear();
                    Console.WriteLine($"Runde {runde}/{Runden}   Punkte: {punkte}\n");
                }
                Thread.Sleep(1); // CPU entlasten, Schleife nicht mit 100 % Last laufen lassen
            }

            // --- Buchstabe auswählen ---
            // Mit ca. 35 % Wahrscheinlichkeit ein Vokal, sonst ein Konsonant
            // (ohne Gewichtung wären Vokale mit 5 von 26 Buchstaben viel zu selten).
            bool istVokal = Zufall.NextDouble() < 0.35;
            string pool = istVokal ? Vokale : Konsonanten;
            char buchstabe = pool[Zufall.Next(pool.Length)];

            // Tastaturpuffer leeren, damit alte Tastendrücke nicht als Reaktion zählen
            while (Console.KeyAvailable) Console.ReadKey(true);

            // Buchstabe anzeigen und Stoppuhr für die Reaktionszeit starten
            Console.WriteLine($"      >>>  {buchstabe}  <<<\n");
            sw.Restart();

            // --- Reaktionsphase ---
            // Innerhalb des Reaktionsfensters auf einen Tastendruck warten
            bool gedrueckt = false;
            double ms = 0;
            while (sw.ElapsedMilliseconds < ReaktionsFensterMs)
            {
                if (Console.KeyAvailable)
                {
                    ms = sw.Elapsed.TotalMilliseconds; // Reaktionszeit sofort festhalten
                    Console.ReadKey(true);
                    gedrueckt = true;
                    break; // Fenster vorzeitig beenden
                }
                Thread.Sleep(1);
            }

            // 4) Auswertung: richtig gedrückt? + Reaktionszeit
            if (istVokal && gedrueckt)
            {
                // Je schneller, desto mehr Punkte: mindestens 10, maximal 150
                int p = (int)Math.Max(10, (ReaktionsFensterMs - ms) / 10); // max. 150 Punkte
                punkte += p;
                treffer++;
                reaktionen.Add(ms);
                Console.WriteLine($"Richtig! Reaktionszeit: {ms:F0} ms (+{p})");
            }
            else if (istVokal)
            {
                // Vokal erschienen, aber nicht gedrückt
                punkte -= 25;
                verpasst++;
                Console.WriteLine("Vokal verpasst! (-25)");
            }
            else if (gedrueckt)
            {
                // Konsonant erschienen, aber fälschlich gedrückt
                punkte -= 50;
                falschAlarm++;
                Console.WriteLine("Falsch! Das war ein Konsonant. (-50)");
            }
            else
            {
                // Konsonant erschienen und korrekt ignoriert: keine Punkte, keine Strafe
                Console.WriteLine("Richtig ignoriert.");
            }

            Thread.Sleep(900); // Kurze Pause, damit man das Feedback lesen kann
        }

        // ---------- Endergebnis ----------
        // Durchschnittliche Reaktionszeit (nur über richtige Treffer); 0, falls es keine gab
        double schnitt = reaktionen.Count > 0 ? reaktionen.Average() : 0;
        Console.Clear();
        Console.WriteLine("=== Ergebnis ===");
        Console.WriteLine($"Name:                 {name}");
        Console.WriteLine($"Punkte:               {punkte}");
        Console.WriteLine($"Treffer:              {treffer}");
        Console.WriteLine($"Vokale verpasst:      {verpasst}");
        Console.WriteLine($"Falsch gedrückt:      {falschAlarm}");
        Console.WriteLine($"Fehlstarts:           {fehlstarts}");
        Console.WriteLine($"Ø Reaktionszeit:      {(reaktionen.Count > 0 ? $"{schnitt:F0} ms" : "-")}");

        // 5) Highscore eintragen
        // Neuen Eintrag hinzufügen, nach Punkten absteigend sortieren (bei Gleichstand:
        // schnellere Reaktionszeit zuerst) und auf die besten 10 beschränken.
        scores.Add(new HighScore(name, punkte, schnitt, DateTime.Now));
        scores = scores.OrderByDescending(s => s.Punkte)
                       .ThenBy(s => s.ReaktionMs)
                       .Take(MaxEintraege)
                       .ToList();
        SpeichereHighScores(scores);

        Console.WriteLine();
        ZeigeHighScores(scores);
        Console.WriteLine("\nBeliebige Taste zum Beenden ...");
        Console.ReadKey(true);
    }

    /// <summary>
    /// Liest die Highscores aus der Textdatei. Format pro Zeile: Name;Punkte;ReaktionMs;Datum
    /// Fehlerhafte Zeilen werden stillschweigend übersprungen.
    /// </summary>
    static List<HighScore> LadeHighScores()
    {
        var liste = new List<HighScore>();
        if (!File.Exists(DateiName)) return liste; // Noch keine Datei = leere Liste

        foreach (var zeile in File.ReadAllLines(DateiName))
        {
            var t = zeile.Split(';');
            // Nur gültige Zeilen übernehmen: genau 4 Felder und alle Zahlen/Datum parsebar.
            // InvariantCulture sorgt dafür, dass der Dezimalpunkt unabhängig von der
            // Spracheinstellung des Systems immer gleich gelesen wird.
            if (t.Length == 4
                && int.TryParse(t[1], out int p)
                && double.TryParse(t[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double r)
                && DateTime.TryParse(t[3], CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime d))
            {
                liste.Add(new HighScore(t[0], p, r, d));
            }
        }
        return liste.OrderByDescending(s => s.Punkte).ToList();
    }

    /// <summary>
    /// Schreibt die Highscores zeilenweise in die Textdatei (überschreibt die alte Datei).
    /// </summary>
    static void SpeichereHighScores(List<HighScore> scores)
    {
        // Jeder Eintrag wird zu einer Zeile "Name;Punkte;ReaktionMs;Datum".
        // Format "F1" = eine Nachkommastelle, "s" = sortierbares ISO-Datum (z. B. 2026-10-19T14:30:00).
        var zeilen = scores.Select(s => string.Join(';',
            s.Name,
            s.Punkte,
            s.ReaktionMs.ToString("F1", CultureInfo.InvariantCulture),
            s.Datum.ToString("s", CultureInfo.InvariantCulture)));
        File.WriteAllLines(DateiName, zeilen);
    }

    /// <summary>
    /// Gibt die Bestenliste als formatierte Tabelle in der Konsole aus.
    /// </summary>
    static void ZeigeHighScores(List<HighScore> scores)
    {
        Console.WriteLine("=== Highscores ===");
        if (scores.Count == 0)
        {
            Console.WriteLine("(noch keine Einträge)");
            return;
        }
        // Kopfzeile; ",-3" = linksbündig mit Breite 3, ",8" = rechtsbündig mit Breite 8
        Console.WriteLine($"{"#",-3}{"Name",-15}{"Punkte",8}{"Ø ms",9}  Datum");
        int i = 1; // Platzierung
        foreach (var s in scores)
            Console.WriteLine($"{i++,-3}{s.Name,-15}{s.Punkte,8}{s.ReaktionMs,9:F0}  {s.Datum:dd.MM.yyyy HH:mm}");
    }
}