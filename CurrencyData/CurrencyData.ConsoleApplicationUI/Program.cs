using CurrencyData.Code;
using CurrencyData.Code.AdoNetCurrencyData;
using CurrencyData.Model;
//using CurrencyData.Entites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyData.ConsoleApplicationUI
{
    class Program
    {
        static public void Tick(Object stateInfo)
        {
            Console.WriteLine("KAYIT YENİLEME SAATİ: {0}", DateTime.Now.ToString("h:mm:ss"));
            DataTable dt = ExchangeAccess.GetCurrencyData();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int ID = ExchangeAccess.GetExchangeType(dt.Rows[i][1].ToString());
                ExchangeRate exchangeRate = new ExchangeRate();
                exchangeRate.RateDate = DateTime.Now;
                exchangeRate.ExchangeTypeID = ID;
                exchangeRate.ExchangeSelling = Convert.ToDecimal(dt.Rows[i][3]);
                exchangeRate.ExchangeBuying = Convert.ToDecimal(dt.Rows[i][4]);
                exchangeRate.EffectiveSelling = Convert.ToDecimal(dt.Rows[i][5]);
                exchangeRate.EffectiveBuying = Convert.ToDecimal(dt.Rows[i][2]);
                ExchangeAccess.AddExchangeRate(exchangeRate);
            }
        }

        static void Main(string[] args)
        {
            TimerCallback callback = new TimerCallback(Tick);
            Console.WriteLine("MERKEZ BANKASINDAN DÖVİZ BİLGİLERİ ÇEKİLİYOR: {0}\n", DateTime.Now.ToString("h:mm:ss"));
            // dakikada bir çalışacak
            Timer stateTimer = new Timer(callback, null, 0, 60000);
            Console.ReadKey();
        }
    }
}
