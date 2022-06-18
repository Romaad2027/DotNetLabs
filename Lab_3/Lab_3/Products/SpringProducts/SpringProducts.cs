using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Products.SpringProducts
{
    public class SpringOutWear : IOutWearProduct
    {
        public string Type { get; set; }
        public string Material { get; set; }

        public SpringOutWear()
        {
            GenerateWear();
        }

        private void GenerateWear()
        {
            Type = "Sweatshirt";
            Material = "Jersey";
        }
    }

    public class SpringUnderWear : IUnderWearProduct
    {
        public string Type { get; set; }
        public string Material { get; set; }

        public SpringUnderWear()
        {
            GenerateWear();
        }

        private void GenerateWear()
        {
            Type = "Pants";
            Material = "Jeans";
        }
    }

    public class SpringFootWear : IFootWearProduct
    {
        public string Type { get; set; }
        public string Material { get; set; }

        public SpringFootWear()
        {
            GenerateWear();
        }

        private void GenerateWear()
        {
            Type = "Sneakers";
            Material = "Jersey";
        }
    }
}
