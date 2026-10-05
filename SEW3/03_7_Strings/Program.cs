string produktName = "Mechanische Tastatur";
int artikelnummer = 4217;
int lagerbestand = 8;
double preis = 89.99;

//Erzeuge folgende Ausgabe ausschließlich mit String Interpolation ( $"..." ):
Console.WriteLine("=== Produktinformationen ===");
Console.WriteLine($"Artikelnummer: {artikelnummer}");
Console.WriteLine($"Produkt: {produktName}");
Console.WriteLine($"Preis:  {preis:C}");
Console.WriteLine($"Lagerbestand: {lagerbestand} Stück");
