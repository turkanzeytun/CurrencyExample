using CurrencyData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyData.Code.Abstract
{
    public interface ICurrencyDAL
    {
        List<ExchangeRate> GetLastExchangeRates();
    }
}
