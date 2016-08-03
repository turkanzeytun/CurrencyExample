using CurrencyData.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CurrencyData.Code.EFCurrencyData.Mapping
{
    public class ExchangeTypeMap : EntityTypeConfiguration<ExchangeType>
    {
        public ExchangeTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.RID);

            // Properties
            this.Property(t => t.ExchangeName)
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.ExchangeCode)
                .IsFixedLength()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("ExchangeTypes");
            this.Property(t => t.RID).HasColumnName("RID");
            this.Property(t => t.ExchangeName).HasColumnName("ExchangeName");
            this.Property(t => t.ExchangeCode).HasColumnName("ExchangeCode");
        }
    }
}
