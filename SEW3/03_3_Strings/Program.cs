
// Finde den Index des  @ -Zeichens mit  IndexOf() 
string email = "max.mustermann@hblfa.ac.at";

Console.WriteLine("Der Index des @-Zeichens ist: " + email.IndexOf('@'));

//Extrahiere den Benutzernamen (alles vor dem  @ ) mit  Substring() 

Console.WriteLine("Der Benutzername ist: " + email.Substring(0, email.IndexOf('@')));

// Extrahiere die Domain (alles nach dem  @ ).

Console.WriteLine("Die Domain ist: " + email.Substring(email.IndexOf('@') + 1));

// Extrahiere die TLD (alles nach dem letzten Punkt in der Domain)
Console.WriteLine("Die TLD ist: " + email.Substring(email.LastIndexOf('.') + 1));
