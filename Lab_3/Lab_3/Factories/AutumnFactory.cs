using Lab_3.Products;
using Lab_3.Products.AutumnProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Factories
{
    public class AutumnFactory : ISeasonFactory
    {
        public IFootWearProduct CreateFootWear()
        {
            return new AutumnFootWear();
        }

        public IOutWearProduct CreateOutWear()
        {
            return new AutumnOutWear();
        }

        public IUnderWearProduct CreateUnderWear()
        {
            return new AutumnUnderWear();
        }
    }
}
