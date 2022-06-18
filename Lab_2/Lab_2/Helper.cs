using Lab_2.Models;
using System.Xml;

namespace Lab_2
{
    public class Helper
    {
        public List<Book> Books { get; set; }
        public List<Rental> Rentals { get; set; }
        public List<Client> Clients { get; set; }

        public Helper()
        {
            GenerateData();
        }

        private void GenerateData()
        {
            Books = new List<Book>()
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

            Clients = new List<Client>()
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

            Rentals = new List<Rental>()
            {
                new Rental(DateTime.Parse("2022-05-03"), DateTime.Parse("2022-05-14"),
                Clients[0],
                Books[0]),

                new Rental(DateTime.Parse("2022-05-06"), DateTime.Parse("2022-05-19"),
                    Clients[1],
                    Books[1]),

                new Rental(DateTime.Parse("2022-05-05"), DateTime.Parse("2022-06-21"),
                    Clients[2],
                    Books[2]),

                new Rental(DateTime.Parse("2022-05-08"), DateTime.Parse("2022-06-27"),
                    Clients[8],
                    Books[4]),

                new Rental(DateTime.Parse("2022-05-07"), DateTime.Parse("2022-06-27"),
                    Clients[3],
                    Books[3]),

                new Rental(DateTime.Parse("2022-05-06"), DateTime.Parse("2022-05-19"),
                    Clients[1],
                    Books[9]),

                new Rental(DateTime.Parse("2022-05-06"), DateTime.Parse("2022-05-21"),
                    Clients[1],
                    Books[5]),

                new Rental(DateTime.Parse("2022-05-03"), DateTime.Parse("2022-05-15"),
                    Clients[3],
                    Books[8]),

                new Rental(DateTime.Parse("2022-05-03"), DateTime.Parse("2022-06-19"),
                    Clients[5],
                    Books[10]),

            };
        }

        public void WriteToFile(string filename)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using(XmlWriter writer = XmlWriter.Create(filename, settings))
            {
                try
                {
                    writer.WriteStartElement("root");

                    writer.WriteStartElement("books");
                    foreach(Book book in Books)
                    {
                        writer.WriteStartElement("book");
                        writer.WriteElementString("name", book.Name);
                        writer.WriteElementString("author", book.Author);
                        writer.WriteElementString("genre", book.Genre);
                        writer.WriteElementString("cost", book.Cost.ToString());
                        writer.WriteElementString("plegde", book.Pledge.ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("clients");
                    foreach (Client client in Clients)
                    {
                        writer.WriteStartElement("client");
                        writer.WriteElementString("name", client.Name);
                        writer.WriteElementString("surname", client.Surname);
                        writer.WriteElementString("phoneNumber", client.PhoneNumber);
                        writer.WriteElementString("category", client.Category);
                        writer.WriteElementString("address", client.Address);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("rentals");
                    foreach (Rental rentals in Rentals)
                    {
                        writer.WriteStartElement("rental");
                        writer.WriteElementString("startDate", rentals.StartDate.ToString());
                        writer.WriteElementString("endDate", rentals.EndDate.ToString());
                        writer.WriteElementString("bookName", rentals.Book.Name);
                        writer.WriteElementString("bookAuthor", rentals.Book.Author);
                        writer.WriteElementString("bookGenre", rentals.Book.Genre);
                        writer.WriteElementString("bookCost", rentals.Book.Cost.ToString());
                        writer.WriteElementString("bookPledge", rentals.Book.Pledge.ToString());

                        writer.WriteElementString("clientName", rentals.Client.Name);
                        writer.WriteElementString("clientSurnmae", rentals.Client.Surname);
                        writer.WriteElementString("clientCategory", rentals.Client.Category);
                        writer.WriteElementString("clientPhoneNumber", rentals.Client.PhoneNumber);
                        writer.WriteElementString("clientAddress", rentals.Client.Address);

                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
