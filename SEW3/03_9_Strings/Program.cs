


string dateipfad = "C:\\Users\\Thomas\\Dokumente\\notes.txt"; 
string dateipfad2 = @"C:\Users\Thomas\Dokumente\notes.txt";

Console.WriteLine("Dateipfad 1: " + dateipfad);
Console.WriteLine("Dateipfad 2: " + dateipfad2);

// b) 

Console.WriteLine("Hallo \nWelt!"); // \n = Zeilenumbruch
Console.WriteLine(@"Hallo \nWelt!"); // @ = Verbatim-String, \n wird nicht als Escape-Sequenz interpretiert