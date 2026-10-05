string wort = "Programmierung";
Console.WriteLine("Das erste Zeichen ist: " + wort[0]);
Console.WriteLine("Das letzte Zeichen ist: " + wort[wort.Length - 1]);

//Berechne den Index des mittleren Zeichens(Länge / 2 ) und gib dieses Zeichen aus 
Console.WriteLine("Das mittlere Zeichen ist: " + wort[wort.Length / 2]);

//Gib alle Zeichen mit ihrem Index über eine  for -Schleife aus
for (int i = 0; i < wort.Length; i++)
{
    Console.WriteLine("Index: " + i + ": " + wort[i]);
}