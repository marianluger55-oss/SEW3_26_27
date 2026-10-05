string kunde = "Anna Huber";
decimal netto = 1234.567m;
decimal mwstSatz = 0.20m;
int artikelNr = 42;

// Berechne Mehrwertsseuer und Bruttobetrag und gib die Quittung aus

decimal mwstBetrag = netto * mwstSatz;
decimal brutto = netto + mwstBetrag;

Console.WriteLine("======================================");
Console.WriteLine("Quittung"); 
Console.WriteLine("======================================");
Console.WriteLine($"Kunde: {kunde}");
Console.WriteLine($"Artikelnummer: {artikelNr}");
Console.WriteLine("--------------------------------------");
Console.WriteLine($"Nettobetrag: {netto:C}");
Console.WriteLine($"Mehrwertsteuer ({mwstSatz:P0}): {mwstBetrag:C}");
Console.WriteLine($"Bruttobetrag: {brutto:C}");
Console.WriteLine("======================================");
