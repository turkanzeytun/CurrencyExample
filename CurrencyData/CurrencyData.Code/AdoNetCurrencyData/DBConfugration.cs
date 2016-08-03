using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyData.Code.AdoNetCurrencyData
{
    public static class DBConfugration
    {
        static DBConfugration()
        {
            _Provider = ConfigurationManager.AppSettings["Provider"];
            _ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        private static string _Provider;
        public static string Provider
        {
            get { return DBConfugration._Provider; }
        }


        private static string _ConnectionString;
        public static string ConnectionString
        {
            get { return DBConfugration._ConnectionString; }
        }
    }
}
