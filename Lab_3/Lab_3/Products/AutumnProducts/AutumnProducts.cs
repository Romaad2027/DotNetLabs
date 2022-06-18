using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Products.AutumnProducts
{
    public class AutumnOutWear : IOutWearProduct
    {
        public string Type { get; set; }
        public string Material { get; set; }

        public AutumnOutWear()
        {
            GenerateWear();
        }

        private void GenerateWear()
        {
            Type = "Sweatshirt";
            Material = "Jersey";
        }
    }

    public class AutumnUnderWear : IUnderWearProduct
    {
        public string Type { get; set; }
        public string Material { get; set; }

        public AutumnUnderWear()
        {
            GenerateWear();
        }

        private void GenerateWear()
        {
            Type = "Pants";
            Material = "Jeans";
        }
    }

    public class AutumnFootWear : IFootWearProduct
    {
        public string Type { get; set; }
        public string Material { get; set; }

        public AutumnFootWear()
        {
            GenerateWear();
        }

        private void GenerateWear()
        {
            Type = "Sneakers";
            Material = "Leatherette";
        }
    }
}
