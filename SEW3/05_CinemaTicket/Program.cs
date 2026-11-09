using _05_CinemaTicket;

Ticket avengers = new Ticket("Avengers: Endgame");
Ticket spiderMan = new Ticket("Spider-Man: Brand New Day");
Ticket spiderMan2 = new Ticket("Spider-Man: Brand New Day");
Ticket spiderMan3 = new Ticket("Spider-Man: Brand New Day");
Ticket bruno = new Ticket("Bruno");
Ticket bruno2 = new Ticket("Bruno");

bruno.PrintTicket();
bruno2.PrintTicket();

// Aufruf einer statischen Methode 
Console.WriteLine($"Total Revenue: {Ticket.GetTotalRevenue()}");
Console.WriteLine($"Total Tickets Sold: {Ticket.TicketCounter}");
