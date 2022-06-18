using Lab_3.Products;
using Lab_3.Products.SpringProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Factories
{
    public class SpringFactory : ISeasonFactory
    {
        public IFootWearProduct CreateFootWear()
        {
            return new SpringFootWear();
        }

        public IOutWearProduct CreateOutWear()
        {
            return new SpringOutWear();
        }

        public IUnderWearProduct CreateUnderWear()
        {
            return new SpringUnderWear();
        }
    }
}
