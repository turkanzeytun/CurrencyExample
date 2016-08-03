using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyData.Interfaces.Abstract;
using CurrencyData.Model;
using CurrencyData.Code.Abstract;

namespace CurrencyData.BLL.Concrete
{
    public class CurrencyManager : ICurrencyServices
    {        
        private ICurrencyDAL _currencyDAL;

        public CurrencyManager(ICurrencyDAL currencyDAL)
        {
            _currencyDAL = currencyDAL;
        }
        public List<ExchangeRate> GetLastExchangeRates()
        {
            return _currencyDAL.GetLastExchangeRates();
        }
    }
}
