using CurrencyData.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CurrencyData.Code.EFCurrencyData.Mapping
{
    public class ExchangeRateMap : EntityTypeConfiguration<ExchangeRate>
    {
        public ExchangeRateMap()
        {
            // Primary Key
            this.HasKey(t => t.CID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ExchangeRates");
            this.Property(t => t.CID).HasColumnName("CID");
            this.Property(t => t.ExchangeTypeID).HasColumnName("ExchangeTypeID");
            this.Property(t => t.RateDate).HasColumnName("RateDate");
            this.Property(t => t.ExchangeBuying).HasColumnName("ExchangeBuying");
            this.Property(t => t.ExchangeSelling).HasColumnName("ExchangeSelling");
            this.Property(t => t.EffectiveBuying).HasColumnName("EffectiveBuying");
            this.Property(t => t.EffectiveSelling).HasColumnName("EffectiveSelling");

            // Relationships
            this.HasOptional(t => t.ExchangeType)
                .WithMany(t => t.ExchangeRates)
                .HasForeignKey(d => d.ExchangeTypeID);

        }
    }
}
