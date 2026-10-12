//Satz eingabe 

Console.WriteLine("Bitte geben Sie einen Satz ein:");
string satz = Console.ReadLine();

// Analyse Wort Anzahl 

Console.WriteLine("Anzahl der Wörter: " + (satz.Split(' ').Length));

// Zeichenanzahl ohne Leerzeichen
Console.WriteLine("Anzahl der Zeichen ohne Leerzeichen: " + satz.Replace(" ", "").Length);

// Längstes Wort
string[] wörter = satz.Split(' ');
string längstesWort = "";
foreach (string wort in wörter)
{
    if (wort.Length > längstesWort.Length)
    {
        längstesWort = wort;
    }
}
Console.WriteLine("Längstes Wort: " + längstesWort);

// Satz in Großbuchstaben

Console.WriteLine("Satz in Großbuchstaben: " + satz.ToUpper());

// Satz in Kleinbuchstaben
Console.WriteLine("Satz in Kleinbuchstaben: " + satz.ToLower());