Console.WriteLine("Bitte geben Sie ein Wort ein: ");
string? wort = Console.ReadLine();

//  Entferne führende und nachgestellte Leerzeichen mit  Trim()
Console.WriteLine("Das Wort ohne führende und nachgestellte Leerzeichen: " + wort?.Trim());

//  Prüfe unabhängig von Groß-/Kleinschreibung, ob die Eingabe „Wien" ist.
if (wort?.Trim().Equals("Wien", StringComparison.OrdinalIgnoreCase) == true)
{
    Console.WriteLine("Die Eingabe ist 'Wien'");
}
else
{
    Console.WriteLine("Die Eingabe ist nicht 'Wien'");
}

