using Lab_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_1
{
    class MainClass
    { 
        static readonly List<Client> clientList1 = new()
        {
            new Client("Evgeniy", "Ponasenkov", "8855363", "Napoleonovskaya", "default"),
            new Client("Oleksandr", "Povoroznykl", "32132", "Mariupolskya", "student"),
            new Client("Anton", "Gantonko", "11111", "Andreevskaya", "default"),
            new Client("Vasya", "Ivaniuk", "44444", "Lilavaya", "pensioner"),
            new Client("Bob", "Bobov", "32312", "Sobornaya", "student"),
            new Client("Roman", "Antonov", "984592", "Sobornaya", "pensioner"),
            new Client("Sofia", "Stolepina", "543782", "Mariupolskaya", "student"),
            new Client("Ruslana", "Chekhova", "785492", "Napoleonovskaya", "default"),
            new Client("Ekaterina", "Markova", "895993", "Lilavaya", "pensioner"),
            new Client("Daria", "Philatenko", "943053", "Andreevskaya", "student"),
            new Client("Svetlana", "Ignatenko", "810058", "Sobornaya", "default")
        };

        static readonly List<Book> bookList1 = new()
        {
            new Book("War and Peace", "Lev Tolstoy", "novel", 230, 200),
            new Book("Red and Black", "Stendal", "novel", 150, 100),
            new Book("Dead souls", "Mykola Gogol", "novel", 140, 90),
            new Book("Crime and punishment", "Fedor Dostoevskyi", "novel", 200, 120),
            new Book("The Clown", "Heinrich Böll", "novel", 160, 90),

            new Book("The Bourgeois Gentleman", "Molière", "play", 110, 60),
            new Book("Mina Mazaylo", "Mykola Koolish", "play", 90, 50),
            new Book("Maskarad", "Mikhail Lermontov", "play", 95, 65),

            new Book("Kobzar", "Taras Shevchenko", "poetry", 130, 85),
            new Book("Poetry collection", "Sergey Esenin", "poetry", 120, 85),
            new Book("Poetry collection", "Aleksandr Pushkin", "poetry", 115, 80),

            new Book("Eneida", "Ivan Kotlyarevskiy", "poem", 130, 85),
            new Book("Eneida", "Vergiliy", "poem", 130, 85),
            new Book("Odyssey", "Gomer", "poem", 160, 100),

        };

        static readonly List<Book> bookList2 = new()
        {
            new Book("War and Peace", "Lev Tolstoy", "novel", 230, 200),
            new Book("Red and Black", "Stendal", "novel", 150, 100),
            new Book("History of america", "Nikol Cage", "science", 220, 150),
           
        };

        static readonly List<Rental> rentalList1 = new()
        {
            new Rental(DateTime.Parse("2022-05-03"), DateTime.Parse("2022-05-14"),
                clientList1[0],
                bookList1[0]),

            new Rental(DateTime.Parse("2022-05-06"), DateTime.Parse("2022-05-19"),
                clientList1[1],
                bookList1[1]),

            new Rental(DateTime.Parse("2022-05-05"), DateTime.Parse("2022-06-21"),
                clientList1[2],
                bookList1[2]),

            new Rental(DateTime.Parse("2022-05-08"), DateTime.Parse("2022-06-27"),
                clientList1[8],
                bookList1[4]),

            new Rental(DateTime.Parse("2022-05-07"), DateTime.Parse("2022-06-27"),
                clientList1[3],
                bookList1[3]),

            new Rental(DateTime.Parse("2022-05-06"), DateTime.Parse("2022-05-19"),
                clientList1[1],
                bookList1[9]),

            new Rental(DateTime.Parse("2022-05-06"), DateTime.Parse("2022-05-21"),
                clientList1[1],
                bookList1[5]),

            new Rental(DateTime.Parse("2022-05-03"), DateTime.Parse("2022-05-15"),
                clientList1[3],
                bookList1[8]),

            new Rental(DateTime.Parse("2022-05-03"), DateTime.Parse("2022-06-19"),
                clientList1[5],
                bookList1[10]),
        };

        public static void Main()
        {
            // REQUEST #1
            Console.WriteLine("Request 1");
            Console.WriteLine("Get all rental novels ordered by cost");
            var Request1 = from x in rentalList1
                           orderby x.Book.Cost
                           where x.Book.Genre == "novel"
                           select x;
            foreach (var x in Request1)
            {
                Console.WriteLine(x);
            }

            // REQUEST #2
            Console.WriteLine("Request 2");
            Console.WriteLine("Get the number of each genre from rental list");
            var Request2 = rentalList1
                .GroupBy(x => x.Book.Genre);
            foreach (var x in Request2)
            {
                Console.WriteLine($"    {x.Key} - {x.Count()}");
            }

            // REQUEST #3
            Console.WriteLine("\nRequest 3");
            Console.WriteLine("Get end dates from rentals, where start date is 2022-05-06 and book cost is > 70");

            var Request3 = rentalList1
                .Where(x => x.Book.Cost > 70 && x.StartDate == DateTime.Parse("2022-05-06"))
                .Select(x => x.EndDate);
            foreach (var x in Request3)
            {
                Console.WriteLine(x);
            }

            // REQUEST #4
            Console.WriteLine("\nRequest 4");
            Console.WriteLine("Get all student clients names and phone numbers");
            var Request4 = clientList1
                .Where(x => x.Category == "student").Select(p => new { Name = p.Name, PhoneNumber = p.PhoneNumber });
            foreach (var x in Request4)
            {
                Console.WriteLine(x);
            }

            //REQUEST #5
            Console.WriteLine("\nRequest 5");
            Console.WriteLine("Check if we have end dates for rents later than 2022-05-26");
            bool Request5 = rentalList1
                .Any(x => x.EndDate.CompareTo(DateTime.Parse("2022-05-26")) > 0);
            Console.WriteLine(Request5);

            //REQUEST #6
            Console.WriteLine("\nRequest 6");
            Console.WriteLine("Get first client with pensioner status which took the novel");
            var Request6 = rentalList1
                .Where(x => x.Book.Genre == "novel" && x.Client.Category == "pensioner")
                .OrderBy(x => x.StartDate)
                .Select(p => new { Client = p.Client, BookName = p.Book.Name})
                .FirstOrDefault();
            Console.WriteLine(Request6);

            //REQUEST #7
            Console.WriteLine("\nRequest 7");
            Console.WriteLine("Get clients from Sobornaya street that are renting books");
            var Request7 = from x in rentalList1
                           where x.Client.Address == "Sobornaya"
                           select new
                           {
                               ClientName = x.Client.Name,
                               BookName = x.Book.Name,
                           };
            foreach(var x in Request7)
            {
                Console.WriteLine(x);
            }

            //REQUEST #8
            Console.WriteLine("\nRequest 8");
            Console.WriteLine("Get the number of renting books grouped by street");
            var Request8 = from x in rentalList1
                           group x by x.Client.Address into g
                           select new { Name = g.Key, Count = g.Count(), };
            foreach(var x in Request8)
            {
                Console.WriteLine($"{x.Name} - {x.Count}");
            }

            //REQUEST #9
            Console.WriteLine("\nRequest 9");
            Console.WriteLine("Get the sum of book's rent price by the chosen date");
            var Request9 = rentalList1
                .Where(x => x.StartDate == DateTime.Parse("2022-05-03"))
                .Sum(x => x.Book.Cost);
            Console.WriteLine(Request9);

            //REQUEST #10
            Console.WriteLine("\nRequest 10");
            Console.WriteLine("Get clients and their address which took book with pledge lower than 150 ordered by enddate");
            var Request10 = rentalList1
                .Where(x => x.Book.Pledge < 150)
                .OrderBy(p => p.EndDate)
                .Select(c => new { Address = c.Client.Address, Name = c.Client.Name });
            foreach(var x in Request10)
            {
                Console.WriteLine(x);
            }

            //REQUEST #11
            Console.WriteLine("\nRequest 11");
            Console.WriteLine("Check if someone on Andreevskaya st. is renting poetry book");
            var Request11 = rentalList1
                .Where(x => x.Book.Genre == "poetry")
                .Select(p => p.Client.Address)
                .Contains("Andreevskaya");
            Console.WriteLine(Request11);

            //REQUEST #12
            Console.WriteLine("\nRequest 12");
            Console.WriteLine("Get all books that started with 'T' and order them by cost descending");
            var Request12 = from x in bookList1
                            where x.Name.StartsWith("T")
                            orderby x.Cost descending
                            select x;
            foreach(var x in Request12)
            {
                Console.WriteLine(x);
            }

            //REQUEST #13
            Console.WriteLine("\nRequest 13");
            Console.WriteLine("Concat the book collections");
            var Request13 = bookList1.Concat(bookList2).Select(x => new {Name = x.Name, Author = x.Author});
            foreach(var x in Request13)
            {
                Console.WriteLine(x);
            }

            //REQUEST #14
            Console.WriteLine("\nRequest 14");
            Console.WriteLine("Get dates where there were more than 2 rents");
            var Request14 = rentalList1
                .GroupBy(x => x.StartDate)
                .Where(x => x.Count() > 2);
            foreach(var x in Request14)
            {
                Console.WriteLine($"{x.Key} - {x.Count()}");
            }

            //REQUEST #15
            Console.WriteLine("\nRequest 15");
            Console.WriteLine("Get book's names that costs more than 100");
            var Request15 = bookList1
                .Where(x => x.Cost > 100)
                .OrderByDescending(x => x.Cost)
                .Select(x => x.Name); 
            foreach (var x in Request15)
            {
                Console.WriteLine(x);
            }
        }
    }
}
