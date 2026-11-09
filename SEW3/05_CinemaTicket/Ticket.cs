using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_CinemaTicket
{
    internal class Ticket
    {
        public string MovieTitle { get; set; }
        public int TicketNumber { get; set; }

        public static double Price { get; set; } = 10.0; // Static property for ticket price, default is 10.0
        public static int TicketCounter { get; private set; } = 0; // Static counter for ticket numbers

        public Ticket(string movieTitle)
        {
            this.MovieTitle = movieTitle;
            Ticket.TicketCounter++; // Increment the ticket counter
            this.TicketNumber = Ticket.TicketCounter; // Assign the current ticket number
        }


        public void PrintTicket()
        {
            Console.WriteLine($"Ticket Number: {this.TicketNumber}, Movie Title: {this.MovieTitle}, Price: {Ticket.Price}");
        }

        public static double GetTotalRevenue()
        {
            return Ticket.TicketCounter* Ticket.Price;
        }
    }
}
