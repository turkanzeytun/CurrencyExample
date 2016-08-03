using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyData.Code.AdoNetCurrencyData
{
    public static class GenericDataAccess
    {
        public static DataTable ExecuteSelectCommand(DbCommand command)
        {
            DataTable table = new DataTable();
            try
            {
                command.Connection.Open();
                DbDataReader reader = command.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception ex)
            {
                //mail and log
            }
            finally
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
            return table;
        }

        public static void ExecuteNonCommand(DbCommand command)
        {
            //try
            //{
                command.Connection.Open();
                command.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    //mail and log
            //}
            //finally
            //{
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            //}
        }

        public static DbCommand CreateCommand()
        {
            string provider = DBConfugration.Provider;
            string connectionString = DBConfugration.ConnectionString;

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            DbConnection con = factory.CreateConnection();
            con.ConnectionString = connectionString;

            DbCommand command = factory.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = con;
            return command;
        }
    }
}
