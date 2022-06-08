using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Models
{
    public class Rental
    {
        public DateTime StartDate;
        public DateTime EndDate;
        public Client Client;
        public Book Book;

        public Rental(DateTime StartDate, DateTime EndDate, Client client, Book book)
        {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            Client = client;
            Book = book;
        }

        public override string ToString()
        {
            return string.Format
                ($"(Start date = {this.StartDate}; end date = {this.EndDate};" +
                $" \nclient = {Client.ToString()}\n book = {Book.ToString()}) \n");
        }
    }

}
