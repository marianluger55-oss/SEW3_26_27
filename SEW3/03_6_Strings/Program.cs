
Console.WriteLine("Bitte geben Sie einen Dateinamen ein: ");
string? dateiname = Console.ReadLine();
Console.WriteLine(IstGültigeDatei(dateiname));
bool IstGültigeDatei(string? dateiname)
{
    // Prüfe, ob der Dateiname null oder leer ist
    if (string.IsNullOrEmpty(dateiname))
    {
        return false;
    }
    // Prüfe, ob der Dateiname mit ".txt" endet (Groß-/Kleinschreibung ignorieren)
    else if (dateiname.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
    {
        return true;
    }
    else if (dateiname.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
    {
        return true;
    }
    else if (dateiname.EndsWith(".md", StringComparison.OrdinalIgnoreCase))
    {
        return true;
    }
    else
    {
        return false;
    }
}
