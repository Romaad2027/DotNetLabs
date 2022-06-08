using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Models
{
    public class Client
    {
        public string Name;

        public string Surname;

        public string PhoneNumber;

        public string Address;

        public string Category;

        public Client(string name, string surname, string phoneNumber, string address, string category)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Address = address;
            Category = category;
        }

        public override string ToString()
        {
            return string.Format
                ($"(name = {this.Name}; surname = {this.Surname};" +
                $" phone number = {this.PhoneNumber}; address = {this.Address};" +
                $" category = {this.Category};)");
        }
    }
}
