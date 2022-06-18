using Lab_3.Factories;
using Lab_3.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public class Client
    {
        private IOutWearProduct OutWear;

        private IUnderWearProduct UnderWear;

        private IFootWearProduct FootWear;

        public Client(ISeasonFactory factory)
        {
            OutWear = factory.CreateOutWear();

            UnderWear = factory.CreateUnderWear();

            FootWear = factory.CreateFootWear();
        }

        public void Run() 
        {
            Console.WriteLine($"OutWear: {OutWear.Type} {OutWear.Material}");
            Console.WriteLine($"UnderWear: {UnderWear.Type} {UnderWear.Material}");
            Console.WriteLine($"FootWear: {FootWear.Type} {FootWear.Material}\n");
        }
    }
}
