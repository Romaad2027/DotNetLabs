using Lab_2;
using Lab_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Lab_1
{
    class MainClass
    {
        public static void Main()
        {
            string filename = "digigi.xml";

            Helper helper = new();
            helper.WriteToFile(filename);

            XDocument xmlDocument = XDocument.Load(filename);

            Console.WriteLine("Request 1");
            Console.WriteLine("Get all rental novels ordered by cost");
            var Request1 = from x in xmlDocument.Descendants("rental")
                           orderby Convert.ToInt32(x.Element("bookCost").Value)
                           where x.Element("bookGenre").Value == "novel"
                           select x;
            foreach (var x in Request1)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine();
            // REQUEST #2
            Console.WriteLine("Request 2");
            Console.WriteLine("Get the number of each genre from rental list");
            var Request2 = xmlDocument.Descendants("rental")
                .GroupBy(x => x.Element("bookGenre").Value);
            foreach (var x in Request2)
            {
                Console.WriteLine($"    {x.Key} - {x.Count()}");
            }

            Console.WriteLine();
            // REQUEST #3
            Console.WriteLine("\nRequest 3");
            Console.WriteLine("Get end dates from rentals, where start date is 2022-05-06 and book cost is > 70");

            var Request3 = xmlDocument.Descendants("rental")
                .Where(x => Convert.ToInt32(x.Element("bookCost").Value) > 70 
                &&
                DateTime.Parse(x.Element("startDate").Value) == DateTime.Parse("2022-05-06"))
                .Select(x => x.Element("endDate").Value);
            foreach (var x in Request3)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            
            // REQUEST #4
            Console.WriteLine("\nRequest 4");
            Console.WriteLine("Get all student clients names and phone numbers");
            var Request4 = xmlDocument.Descendants("client")
                .Where(x => x.Element("category").Value == "student")
                .Select(p => new { Name = p.Element("name").Value, PhoneNumber = p.Element("phoneNumber").Value });
            foreach (var x in Request4)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            
            //REQUEST #5
            Console.WriteLine("\nRequest 5");
            Console.WriteLine("Check if we have end dates for rents later than 2022-05-26");
            bool Request5 = xmlDocument.Descendants("rental")
                .Any(x => DateTime.Parse(x.Element("endDate").Value).CompareTo(DateTime.Parse("2022-05-26")) > 0);
            Console.WriteLine(Request5);
            Console.WriteLine();

            //REQUEST #6
            Console.WriteLine("\nRequest 6");
            Console.WriteLine("Get first client with pensioner status which took the novel");
            var Request6 = xmlDocument.Descendants("rental")
                .Where(x => x.Element("bookGenre").Value == "novel" && x.Element("clientCategory").Value == "pensioner")
                .OrderBy(x => DateTime.Parse(x.Element("startDate").Value))
                .Select(p => new { ClientPhoneNumber = p.Element("clientPhoneNumber").Value, BookName = p.Element("bookName").Value})
                .FirstOrDefault();
            Console.WriteLine(Request6);
            Console.WriteLine();

            
            //REQUEST #7
            Console.WriteLine("\nRequest 7");
            Console.WriteLine("Get clients from Sobornaya street that are renting books");
            var Request7 = from x in xmlDocument.Descendants("rental")
                           where x.Element("clientAddress").Value == "Sobornaya"
                           select new
                           {
                               ClientName = x.Element("clientName").Value,
                               BookName = x.Element("bookName").Value,
                           };

            foreach (var x in Request7)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            
            //REQUEST #8
            Console.WriteLine("\nRequest 8");
            Console.WriteLine("Get the number of renting books grouped by street");
            var Request8 = from x in xmlDocument.Descendants("rental")
                           group x by x.Element("clientAddress").Value into g
                           select new { Name = g.Key, Count = g.Count(), };
            foreach (var x in Request8)
            {
                Console.WriteLine($"{x.Name} - {x.Count}");
            }
            Console.WriteLine();

            
            //REQUEST #9
            Console.WriteLine("\nRequest 9");
            Console.WriteLine("Get the sum of book's rent price by the chosen date");
            var Request9 = xmlDocument.Descendants("rental")
                .Where(x => DateTime.Parse(x.Element("startDate").Value) == DateTime.Parse("2022-05-03"))
                .Sum(x => Convert.ToInt32(x.Element("bookCost").Value));
            Console.WriteLine(Request9);
            Console.WriteLine();

            
            //REQUEST #10
            Console.WriteLine("\nRequest 10");
            Console.WriteLine("Get clients and their address which took book with pledge lower than 150 ordered by enddate");
            var Request10 = xmlDocument.Descendants("rental")
                .Where(x => Convert.ToInt32(x.Element("bookPledge").Value) < 150)
                .OrderBy(p => p.Element("endDate").Value)
                .Select(c => new { Address = c.Element("clientAddress").Value, Name = c.Element("clientName").Value });
            foreach (var x in Request10)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            
            //REQUEST #11
            Console.WriteLine("\nRequest 11");
            Console.WriteLine("Check if someone on Andreevskaya st. is renting poetry book");
            var Request11 = xmlDocument.Descendants("rental")
                .Where(x => x.Element("bookGenre").Value == "poetry")
                .Select(p => p.Element("clientAddress").Value)
                .Contains("Andreevskaya");
            Console.WriteLine(Request11);
            Console.WriteLine();

            
            //REQUEST #12
            Console.WriteLine("\nRequest 12");
            Console.WriteLine("Get all books that started with 'T' and order them by cost descending");
            var Request12 = from x in xmlDocument.Descendants("book")
                            where x.Element("name").Value.StartsWith("T")
                            orderby Convert.ToInt32(x.Element("cost").Value) descending
                            select x.Value;
            foreach (var x in Request12)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            
            //REQUEST #14
            Console.WriteLine("\nRequest 14");
            Console.WriteLine("Get dates where there were more than 2 rents");
            var Request14 = xmlDocument.Descendants("rental")
                .GroupBy(x => x.Element("startDate").Value)
                .Where(x => x.Count() > 2);
            foreach (var x in Request14)
            {
                Console.WriteLine($"{x.Key} - {x.Count()}");
            }
            Console.WriteLine();

            //REQUEST #15
            Console.WriteLine("\nRequest 15");
            Console.WriteLine("Get book's names that costs more than 100");
            var Request15 = xmlDocument.Descendants("book")
                .Where(x => Convert.ToInt32(x.Element("cost").Value) > 100)
                .OrderByDescending(x => x.Element("cost").Value)
                .Select(x => x.Element("name").Value);
            foreach (var x in Request15)
            {
                Console.WriteLine(x);
            }

        }
    }
}