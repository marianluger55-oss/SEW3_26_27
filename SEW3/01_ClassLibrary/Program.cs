using AreaCalculation;
using System.Drawing;
using QRCoder; 

Console.WriteLine("Hello, World!");
Console.WriteLine("Bitte Namen eingeben: ");
string? name = Console.ReadLine();
Console.WriteLine("Hallo, " + name + "! Willkommen in der C#-Welt!");

AreaCalculation.Rectangle r1 = new AreaCalculation.Rectangle(5, 10); // full qualified name to avoid ambiguity with System.Drawing.Rectangle
double area1 = r1.CalculateArea();
Console.WriteLine("Die Fläche des Rechtecks ist: " + area1);

AreaCalculation.Square s1 = new AreaCalculation.Square(5);
double area2 = s1.CalculateArea();
Console.WriteLine("Die Fläche des Quadrats ist: " + area2);

//Erstellen eines QR Codes mit der QRCoder-Bibliothek
QRCodeGenerator qrGenerator = new QRCodeGenerator();
QRCodeData qrCodeData = qrGenerator.CreateQrCode("www.josephinum.at", QRCodeGenerator.ECCLevel.Q);
QRCode qrCode = new QRCode(qrCodeData);
Bitmap qrCodeImage = qrCode.GetGraphic(20);
qrCodeImage.Save("qrcode.png"); 

Console.WriteLine("Press any key to exit...");
Console.ReadKey();