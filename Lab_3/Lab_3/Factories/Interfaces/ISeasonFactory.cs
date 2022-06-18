using Lab_3.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Factories
{
    public interface ISeasonFactory
    {
        IOutWearProduct CreateOutWear();

        IUnderWearProduct CreateUnderWear();

        IFootWearProduct CreateFootWear();
    }
}
