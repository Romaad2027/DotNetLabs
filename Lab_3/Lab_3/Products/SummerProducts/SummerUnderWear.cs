using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Products.SummerProducts
{
    public class SummerUnderWear : IUnderWearProduct
    {
        public string Type { get; set; }
        public string Material { get; set; }

        public SummerUnderWear()
        {
            GenerateWear();
        }

        private void GenerateWear()
        {
            Type = "Shorts";
            Material = "Jersey";
        }
    }
}
