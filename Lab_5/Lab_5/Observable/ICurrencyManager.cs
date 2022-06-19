using Lab_5.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5.Observable
{
    public interface ICurrencyManager
    {
        void AddListener(ICurrencyListener l);

        void RemoveListener(ICurrencyListener l);

        void NotifyListeners(string data);
    }
}
