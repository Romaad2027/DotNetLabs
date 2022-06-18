using Lab_3.Products;
using Lab_3.Products.WinterProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Factories
{
    public class WinterFactory : ISeasonFactory
    {
        public IFootWearProduct CreateFootWear()
        {
            return new WinterFootWear();
        }

        public IOutWearProduct CreateOutWear()
        {
            return new WinterOutWear();
        }

        public IUnderWearProduct CreateUnderWear()
        {
            return new WinterUnderWear();
        }
    }
}
