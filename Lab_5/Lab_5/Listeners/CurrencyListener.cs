using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_5.Listeners
{
    public class CurrencyListener : ICurrencyListener
    {
        public void Update(string data)
        {
            XDocument doc = XDocument.Parse(data);

            XElement currency = doc.Element("exchangerates");
            
            if(currency != null)
            {
                var res = currency.Descendants("row")
                    .Where(x => x.Element("exchangerate").Attribute("ccy").Value != "BTC")
                    .Select(x => new { 
                        CType = x.Element("exchangerate").Attribute("ccy").Value,
                        CBuy = x.Element("exchangerate").Attribute("buy").Value,
                        CSale = x.Element("exchangerate").Attribute("buy").Value,
                    });

                foreach(var item in res)
                {
                    Console.WriteLine($"CCY: {item.CType}, Buy: {item.CBuy}, Sale: {item.CSale}");
                }
            }
        }
    }
}
