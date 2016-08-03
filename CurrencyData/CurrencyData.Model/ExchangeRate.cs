using System;
using System.Collections.Generic;

namespace CurrencyData.Model
{
    public partial class ExchangeRate
    {
        public int CID { get; set; }
        public Nullable<int> ExchangeTypeID { get; set; }
        public Nullable<System.DateTime> RateDate { get; set; }
        public Nullable<decimal> ExchangeBuying { get; set; }
        public Nullable<decimal> ExchangeSelling { get; set; }
        public Nullable<decimal> EffectiveBuying { get; set; }
        public Nullable<decimal> EffectiveSelling { get; set; }
        public virtual ExchangeType ExchangeType { get; set; }
    }
}
