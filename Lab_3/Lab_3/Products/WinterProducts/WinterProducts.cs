using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Products.WinterProducts
{
    public class WinterOutWear : IOutWearProduct
    {
        public string Type { get; set; }
        public string Material { get; set; }

        public WinterOutWear()
        {
            GenerateWear();
        }

        private void GenerateWear()
        {
            Type = "Hoodie";
            Material = "Cotton";
        }
    }

    public class WinterUnderWear : IUnderWearProduct
    {
        public string Type { get; set; }
        public string Material { get; set; }

        public WinterUnderWear()
        {
            GenerateWear();
        }

        private void GenerateWear()
        {
            Type = "Pants";
            Material = "Cotton";
        }
    }

    public class WinterFootWear : IFootWearProduct
    {
        public string Type { get; set; }
        public string Material { get; set; }

        public WinterFootWear()
        {
            GenerateWear();
        }

        private void GenerateWear()
        {
            Type = "Boots";
            Material = "Fur";
        }
    }

}
