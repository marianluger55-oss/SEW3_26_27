using FarmLib;
using Spectre.Console;

Farm farm = new Farm("Betrieb Luger");

// 3 Felder erstellen
Field field1 = new Field("Nordfeld", 5, "Mais", 100);
Field field2 = new Field("Südfeld", 3, "Weizen", 80);
Field field3 = new Field("Ostfeld", 4, "Soja", 40);

// Felder zum Betrieb hinzufügen
farm.AddField(field1);
farm.AddField(field2);
farm.AddField(field3);


var table = new Table()
    .AddColumn("[bold]Name[/]")
    .AddColumn("[bold]Kultur[/]")
    .AddColumn("[bold]Fläche (ha)[/]")
    .AddColumn("[bold]Fläche (m²)[/]")
    .AddColumn("[bold]Ertrag (t)[/]");

foreach (Field field in farm.Fields)
{
    table.AddRow(
        field.name,
        field.Crop,
        field.AreaHa.ToString(),
        field.AreaInSquareMeters().ToString(),
        field.TotalYieldTonnes().ToString()
    );
}

// Summenzeile
table.AddRow(
    "[bold]GESAMT[/]",
    "",
    $"[bold]{farm.TotalAreaHa()}[/]",
    $"[bold]{farm.TotalAreaHa() * 10000}[/]",
    $"[bold]{farm.TotalYieldTonnes()}[/]"
);

AnsiConsole.Write(table);

// Status spinner for work
AnsiConsole.Status()
        .Start("Processing...", ctx =>
        {
            Thread.Sleep(2500);
        });

    AnsiConsole.MarkupLine("[green]Done![/]");


// Versuch, die Methode aufzurufen:

// field1.DecitonnesToTonnes();

/*
Fehlermeldung:
CS0122: 'Field.DecitonnesToTonnes()' is inaccessible due to its protection level.

Erklärung:
Die Methode ist als "internal" deklariert und kann deshalb
aus einem anderen Projekt (Assembly) nicht aufgerufen werden.
*/