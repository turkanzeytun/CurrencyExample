using System;
using System.Collections.Generic;

namespace CurrencyData.Model
{
    public partial class ExchangeType
    {
        public ExchangeType()
        {
            this.ExchangeRates = new List<ExchangeRate>();
        }

        public int RID { get; set; }
        public string ExchangeName { get; set; }
        public string ExchangeCode { get; set; }
        public virtual ICollection<ExchangeRate> ExchangeRates { get; set; }
    }
}
