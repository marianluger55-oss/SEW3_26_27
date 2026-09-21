using AreaCalculation;

Console.WriteLine("Hello, World!");
Console.WriteLine("Bitte Namen eingeben: ");
string? name = Console.ReadLine();
Console.WriteLine("Hallo, " + name + "! Willkommen in der C#-Welt!");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

Rectangle r1 = new Rectangle(5, 10);
double area1 = r1.CalculateArea();
Console.WriteLine("Die Fläche des Rechtecks ist: " + area1);

Square s1 = new Square(5);
double area2 = s1.CalculateArea();
Console.WriteLine("Die Fläche des Quadrats ist: " + area2);
