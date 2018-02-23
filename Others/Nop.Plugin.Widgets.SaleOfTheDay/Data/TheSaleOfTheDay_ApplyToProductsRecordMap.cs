using Nop.Data.Mapping;
using Nop.Plugin.Widgets.SaleOfTheDay.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.SaleOfTheDay.Data
{
    public class TheSaleOfTheDay_ApplyToProductsRecordMap : NopEntityTypeConfiguration<TheSaleOfTheDay_ApplyToProductsRecord>
    {
        public TheSaleOfTheDay_ApplyToProductsRecordMap()
        {
            ToTable("TheSaleOfTheDay_ApplyToProducts");

            //Map the primary key
            HasKey(m => m.Id);
            //Map the additional properties
            Property(m => m.ProductId);
            Property(m => m.TheSaleOfTheDayId);

            this.HasMany(m => m.ApplyToProducts).WithOptional().HasForeignKey(x => x.TheSaleOfTheDayId);

        }
    }
}
