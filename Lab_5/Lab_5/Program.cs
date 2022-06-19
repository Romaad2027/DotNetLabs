using Lab_5.Listeners;
using Lab_5.Observable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Lab_5
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            CurrencyManager currencyManager = new CurrencyManager();
            
            CurrencyListener currencyListener = new CurrencyListener();

            CriptoCurrencyListener criptoCurrencyListener = new CriptoCurrencyListener();

            currencyManager.AddListener(currencyListener);

            currencyManager.AddListener(criptoCurrencyListener);

            bool carryOn = true;

            while (carryOn)
            {
                Console.Write("Press Enter to get currency info(Type 'stop' to quit): ");
                string answer = Console.ReadLine();

                if(answer.ToLower() == "stop")
                {
                    break;
                }

                await currencyManager.CurrencyRequestAsync();
                Console.WriteLine();
            }
        }

    }
}
