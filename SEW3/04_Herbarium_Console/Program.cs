using FJHerbariumLibrary;

Herbarium herbarium = new Herbarium();

herbarium.Generate("Herbarium_Template-pptx", @"C:\Users\m.luger\OneDrive - HBLFA Francisco Josephinum\Desktop", "metadaten.txt", @"C:\Users\m.luger\OneDrive - HBLFA Francisco Josephinum\Desktop");

Console.WriteLine("Herbarium generation completed. Press any key to exit.");