using Nop.Data.Mapping;
using Nop.Plugin.Widgets.SaleOfTheDay.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.SaleOfTheDay.Data
{
    public class TheSaleOfTheDayRecordMap : NopEntityTypeConfiguration<TheSaleOfTheDayRecord>
    {
        public TheSaleOfTheDayRecordMap()
        {
            ToTable("TheSaleOfTheDay");

            //Map the primary key
            HasKey(m => m.Id);
            //Map the additional properties
            Property(m => m.ScheduleStart);
            Property(m => m.Name);
            Property(m => m.ScheduleEnd);
            Property(m => m.StartTime);
            Property(m => m.EndTime);

        } 
    }
}
