using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.Models
{
    public class Book
    {
        public string Name;
        public string Author;
        public string Genre;
        public int Pledge;
        public int Cost;

        public Book(string name, string author, string genre, int pledge, int cost)
        {
            Name = name;
            Author = author;
            Genre = genre;
            Pledge = pledge;
            Cost = cost;
        }

        public override string ToString()
        {
            return string.Format
                ($"(name = {this.Name}; author = {this.Author};" +
                $" genre = {this.Genre}; pledge = {this.Pledge} cost = {this.Cost};)");
        }
    }
}

