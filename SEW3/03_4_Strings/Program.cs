Console.WriteLine("Bitte einen Satz eingeben: ");
string? satz = Console.ReadLine();

// Ersetze alle Leerzeichen durch Unterstriche mit Replace()

Console.WriteLine("Der Satz mit Unterstrichen: " + satz?.Replace(' ', '_'));

// Ersetze alle Vokale in Kleinbuchstaben durch * 
Console.WriteLine("Der Satz mit Sternchen: " + satz?.ToLower().Replace('a', '*').Replace('e', '*').Replace('i', '*').Replace('o', '*').Replace('u', '*'));

// Gib original Text und ergebnis aus 
Console.WriteLine("Originaltext: " + satz);
Console.WriteLine("Ergebnis: " + satz?.ToLower().Replace('a', '*').Replace('e', '*').Replace('i', '*').Replace('o', '*').Replace('u', '*'));

