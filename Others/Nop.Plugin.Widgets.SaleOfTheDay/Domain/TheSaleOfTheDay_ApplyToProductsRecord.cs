using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.SaleOfTheDay.Domain
{
    public class TheSaleOfTheDay_ApplyToProductsRecord : BaseEntity
    {
        public int TheSaleOfTheDayId { get; set; }
        public int ProductId { get; set; }

        private ICollection<TheSaleOfTheDay_ApplyToProductsRecord> _applyToProducts;
        public virtual ICollection<TheSaleOfTheDay_ApplyToProductsRecord> ApplyToProducts
        {
            get { return _applyToProducts ?? (_applyToProducts = new List<TheSaleOfTheDay_ApplyToProductsRecord>()); }
            protected set { _applyToProducts = value; }
        }
    }
}
