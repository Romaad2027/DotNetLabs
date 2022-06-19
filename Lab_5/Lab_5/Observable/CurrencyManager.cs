using Lab_5.Listeners;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5.Observable
{
    public class CurrencyManager : ICurrencyManager
    {
        private List<ICurrencyListener> listeners;

        public CurrencyManager()
        {
            listeners = new List<ICurrencyListener>();
        }

        public void AddListener(ICurrencyListener l)
        {
            listeners.Add(l);
        }

        public void RemoveListener(ICurrencyListener l)
        {
            listeners.Remove(l);
        }

        public void NotifyListeners(string data)
        {
            foreach(ICurrencyListener l in listeners)
            {
                l.Update(data);
            }
        }

        public async Task CurrencyRequestAsync()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest
                .Create("https://api.privatbank.ua/p24api/pubinfo?exchange&coursid=5");

            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();

            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            var result = readStream.ReadToEnd();

            response.Close();

            NotifyListeners(result);
        }
    }
}
