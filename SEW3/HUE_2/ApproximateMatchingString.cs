using System;
using System.Collections.Generic;
using System.IO;

// Diese Klasse sucht für ein falsch geschriebenes Wort passende richtige Wörter.
// Es werden nur Wörter gefunden, die sich durch genau einen Fehler unterscheiden.
public class ApproximateMatchingString
{
    // Diese Buchstaben werden beim Einfügen und Ersetzen ausprobiert
    private string alphabet = "abcdefghijklmnopqrstuvwxyzäöüß";

    // Das Wort, das der Benutzer eingegeben hat
    private string word;

    // Hier werden alle Wörter aus der Datei gespeichert.
    // Ein HashSet findet Wörter viel schneller als eine normale Liste.
    private HashSet<string> wordList = new HashSet<string>();

    // Der Konstruktor speichert das Wort und liest die Datei mit den Wörtern ein
    public ApproximateMatchingString(string word, string pathToWordList)
    {
        this.word = word;

        // Prüfen, ob es die Datei überhaupt gibt
        if (File.Exists(pathToWordList) == false)
        {
            Console.WriteLine("Datei nicht gefunden: " + pathToWordList);
            return;
        }

        // Alle Zeilen der Datei einlesen
        string[] lines = File.ReadAllLines(pathToWordList);

        // Jede Zeile ist ein Wort und kommt in die Wortliste
        foreach (string line in lines)
        {
            wordList.Add(line.Trim());
        }
    }

    // Gibt alle Vorschläge zurück.
    // Dafür werden alle vier Methoden aufgerufen und die Ergebnisse gesammelt.
    public List<string> Suggestions
    {
        get
        {
            List<string> result = new List<string>();

            AddUnique(result, Insertion());
            AddUnique(result, Deletion());
            AddUnique(result, Replace());
            AddUnique(result, Transposition());

            return result;
        }
    }

    // Ein Buchstabe fehlt im Wort.
    // Wir probieren an jeder Stelle jeden Buchstaben einzufügen.
    // Beispiel: cot -> coat
    private List<string> Insertion()
    {
        List<string> found = new List<string>();

        // Wir gehen bis word.Length, damit wir auch ganz am Ende einfügen können
        for (int i = 0; i <= word.Length; i++)
        {
            foreach (char c in alphabet)
            {
                // Buchstaben an der Stelle i einfügen
                string newWord = word.Insert(i, c.ToString());
                AddIfInList(found, newWord);
            }
        }

        return found;
    }

    // Ein Buchstabe ist zu viel im Wort.
    // Wir löschen nacheinander jeden Buchstaben einmal.
    // Beispiel: coat -> cot
    private List<string> Deletion()
    {
        List<string> found = new List<string>();

        for (int i = 0; i < word.Length; i++)
        {
            // Einen Buchstaben an der Stelle i löschen
            string newWord = word.Remove(i, 1);
            AddIfInList(found, newWord);
        }

        return found;
    }

    // Ein Buchstabe ist falsch.
    // Wir ersetzen jeden Buchstaben durch jeden anderen Buchstaben.
    // Beispiel: coat -> cost
    private List<string> Replace()
    {
        List<string> found = new List<string>();

        for (int i = 0; i < word.Length; i++)
        {
            foreach (char c in alphabet)
            {
                // Buchstaben an der Stelle i löschen und den neuen dort einfügen
                string newWord = word.Remove(i, 1).Insert(i, c.ToString());
                AddIfInList(found, newWord);
            }
        }

        return found;
    }

    // Zwei Buchstaben sind vertauscht.
    // Wir tauschen immer zwei Buchstaben, die nebeneinander stehen.
    // Beispiel: cost -> cots
    private List<string> Transposition()
    {
        List<string> found = new List<string>();

        // Wir gehen nur bis zum vorletzten Buchstaben,
        // weil wir immer mit dem nächsten Buchstaben tauschen
        for (int i = 0; i < word.Length - 1; i++)
        {
            // Das Wort in drei Teile zerlegen:
            // alles davor + die zwei Buchstaben vertauscht + alles danach
            string before = word.Substring(0, i);
            string after = word.Substring(i + 2);
            string newWord = before + word[i + 1] + word[i] + after;

            AddIfInList(found, newWord);
        }

        return found;
    }

    // Prüft, ob das neue Wort in der Wortliste steht.
    // Wenn ja und es noch nicht gefunden wurde, wird es gespeichert.
    private void AddIfInList(List<string> found, string newWord)
    {
        if (wordList.Contains(newWord) && !found.Contains(newWord))
        {
            found.Add(newWord);
        }
    }

    // Kopiert die gefundenen Wörter in die Ergebnisliste.
    // Wörter, die schon drin sind, und das eingegebene Wort selbst werden übersprungen.
    private void AddUnique(List<string> result, List<string> found)
    {
        foreach (string s in found)
        {
            if (s != word && !result.Contains(s))
            {
                result.Add(s);
            }
        }
    }
}