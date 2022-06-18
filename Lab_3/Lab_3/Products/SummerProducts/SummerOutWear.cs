using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Products.SummerProducts
{
    public class SummerOutWear : IOutWearProduct
    {
        public string Type { get ; set ; }
        public string Material { get; set; }

        public SummerOutWear()
        {
            GenerateWear();
        }

        private void GenerateWear()
        {
            Type = "T-shirt";
            Material = "Jersey";
        }
    }
}
