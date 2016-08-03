using CurrencyData.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CurrencyData.Code.AdoNetCurrencyData
{
    public static class ExchangeAccess
    {
        /// <summary>
        /// works with GetExchangeRates stored procedure
        /// gets last Exchange Rates
        /// </summary>
        /// <returns></returns>
        public static DataTable GetExchangeRates()
        {
            DataTable dt = new DataTable();
            using (DbCommand com = GenericDataAccess.CreateCommand())
            {
                com.CommandText = "GetExchangeRates";
                dt = GenericDataAccess.ExecuteSelectCommand(com);
            }
            return dt;
        }

        public static int GetExchangeType(string name)
        {
            DataTable dt = new DataTable();
            using (DbCommand com = GenericDataAccess.CreateCommand())
            {
                com.CommandText = "GetExchangeTypeByName";
                DbParameter param = com.CreateParameter();
                param.ParameterName = "@ExchangeCode";
                param.DbType = DbType.String;
                param.Value = name;
                com.Parameters.Add(param);

                dt = GenericDataAccess.ExecuteSelectCommand(com);
            }
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public static void AddExchangeRate(ExchangeRate rate)
        {
            DbCommand com = GenericDataAccess.CreateCommand();
            com.CommandText = "ExchangeRatesToAddTable";

            DbParameter param = com.CreateParameter();
            param.ParameterName = "@RateDate";
            param.DbType = DbType.Date;
            param.Value = rate.RateDate;
            com.Parameters.Add(param);

            DbParameter param1 = com.CreateParameter();
            param1 = com.CreateParameter();
            param1.ParameterName = "@ExchangeTypeID";
            param1.DbType = DbType.Int32;
            param1.Value = rate.ExchangeTypeID;
            com.Parameters.Add(param1);

            DbParameter param2 = com.CreateParameter();
            param2 = com.CreateParameter();
            param2.ParameterName = "@ExchangeBuying";
            param2.DbType = DbType.Double;
            param2.Value = rate.ExchangeBuying;
            com.Parameters.Add(param2);

            DbParameter param3 = com.CreateParameter();
            param3 = com.CreateParameter();
            param3.ParameterName = "@ExchangeSelling";
            param3.DbType = DbType.Double;
            param3.Value = rate.ExchangeSelling;
            com.Parameters.Add(param3);

            DbParameter param4 = com.CreateParameter();
            param4 = com.CreateParameter();
            param4.ParameterName = "@EffectiveBuying";
            param4.DbType = DbType.Double;
            param4.Value = rate.EffectiveBuying;
            com.Parameters.Add(param4);

            DbParameter param5 = com.CreateParameter();
            param5 = com.CreateParameter();
            param5.ParameterName = "@EffectiveSelling";
            param5.DbType = DbType.Double;
            param5.Value = rate.EffectiveSelling;
            com.Parameters.Add(param5);

            GenericDataAccess.ExecuteNonCommand(com);
        }

        public static DataTable GetCurrencyData()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("Adı", typeof(string)));
            dt.Columns.Add(new DataColumn("Kod", typeof(string)));
            dt.Columns.Add(new DataColumn("Döviz alış", typeof(string)));
            dt.Columns.Add(new DataColumn("Döviz satış", typeof(string)));
            dt.Columns.Add(new DataColumn("Efektif alış", typeof(string)));
            dt.Columns.Add(new DataColumn("Efektif Satış", typeof(string)));

            XmlTextReader rdr = new XmlTextReader("http://www.tcmb.gov.tr/kurlar/today.xml");
            XmlDocument myxml = new XmlDocument();
            myxml.Load(rdr);
            XmlNode tarih = myxml.SelectSingleNode("/Tarih_Date/@Tarih");
            XmlNodeList mylist = myxml.SelectNodes("/Tarih_Date/Currency");
            XmlNodeList adi = myxml.SelectNodes("/Tarih_Date/Currency/Isim");
            XmlNodeList kod = myxml.SelectNodes("/Tarih_Date/Currency/@Kod");
            XmlNodeList doviz_alis = myxml.SelectNodes("/Tarih_Date/Currency/ForexBuying");
            XmlNodeList doviz_satis = myxml.SelectNodes("/Tarih_Date/Currency/ForexSelling");
            XmlNodeList efektif_alis = myxml.SelectNodes("/Tarih_Date/Currency/BanknoteBuying");
            XmlNodeList efektif_satis = myxml.SelectNodes("/Tarih_Date/Currency/BanknoteSelling");

            int x = 6;

            for (int i = 0; i < x; i++)
            {
                dr = dt.NewRow();
                dr[0] = adi.Item(i).InnerText.ToString();
                dr[1] = kod.Item(i).InnerText.ToString();
                dr[2] = doviz_alis.Item(i).InnerText.ToString();
                dr[3] = doviz_satis.Item(i).InnerText.ToString();
                dr[4] = efektif_alis.Item(i).InnerText.ToString();
                dr[5] = efektif_satis.Item(i).InnerText.ToString();
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
