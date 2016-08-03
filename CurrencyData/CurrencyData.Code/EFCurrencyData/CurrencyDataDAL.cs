using CurrencyData.Code.Abstract;
using CurrencyData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyData.Code.EFCurrencyData
{
    public class CurrencyDataDAL : ICurrencyDAL
    {
        public List<ExchangeRate> GetLastExchangeRates()
        {
            using (var _context = new CurrencyDataDBContext())
            {
                var currencyList = _context.ExchangeRates.OrderByDescending(u => u.CID).Take(6);
                return currencyList.ToList();
            }
        }
    }
}
