using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CurrencyData.Code;
using CurrencyData.Model;
using CurrencyData.Code.EFCurrencyData.Mapping;

namespace CurrencyData.Code.EFCurrencyData
{
    public partial class CurrencyDataDBContext : DbContext
    {
        static CurrencyDataDBContext()
        {
            Database.SetInitializer<CurrencyDataDBContext>(null);
        }

        //public CurrencyDataDBContext()
        //    : base("Name=CurrencyDataDBContext")
        //{
        //}

        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<ExchangeType> ExchangeTypes { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ExchangeRateMap());
            modelBuilder.Configurations.Add(new ExchangeTypeMap());
    
        }
    }
}
