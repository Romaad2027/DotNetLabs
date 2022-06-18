using Lab_3.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client summerClient = new Client(new SummerFactory());
            Console.WriteLine("Wear for Summer");
            summerClient.Run();

            Client autumnClient = new Client(new AutumnFactory());
            Console.WriteLine("Wear for Autumn");
            autumnClient.Run();

            Client winterClient = new Client(new WinterFactory());
            Console.WriteLine("Wear for Winter");
            winterClient.Run();

            Client springClient = new Client(new SpringFactory());
            Console.WriteLine("Wear for Spring");
            springClient.Run();
        }
    }
}
