using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Damit Umlaute und ß in der Konsole richtig angezeigt werden
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        // Pfad zur Wortliste einlesen
        Console.Write("Geben Sie den Pfad zur Wortliste ein: ");
        string path = Console.ReadLine();

        // Anführungszeichen entfernen
        // (Windows fügt sie bei "Als Pfad kopieren" automatisch hinzu)
        path = path.Trim().Trim('"');

        // So lange nachfragen, bis es die Datei wirklich gibt
        while (File.Exists(path) == false)
        {
            Console.WriteLine("Datei nicht gefunden. Bitte nochmal versuchen.");
            Console.Write("Geben Sie den Pfad zur Wortliste ein: ");
            path = Console.ReadLine().Trim().Trim('"');
        }

        // Wort vom Benutzer einlesen
        Console.Write("Geben Sie ein Wort ein: ");
        string word = Console.ReadLine();

        // Objekt erstellen: Es liest die Wortliste ein und merkt sich das Wort
        ApproximateMatchingString check = new ApproximateMatchingString(word, path);

        // Jeden Vorschlag in einer eigenen Zeile ausgeben
        foreach (string suggestion in check.Suggestions)
        {
            Console.WriteLine(suggestion);
        }
    }
}