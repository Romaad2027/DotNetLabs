using Lab_3.Products;
using Lab_3.Products.SummerProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Factories
{
    public class SummerFactory : ISeasonFactory
    {
        public IFootWearProduct CreateFootWear()
        {
            return new SummerFootWear();
        }

        public IOutWearProduct CreateOutWear()
        {
            return new SummerOutWear();
        }

        public IUnderWearProduct CreateUnderWear()
        {
            return new SummerUnderWear();
        }
    }
}
