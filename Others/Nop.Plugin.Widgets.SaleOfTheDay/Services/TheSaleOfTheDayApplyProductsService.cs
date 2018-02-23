using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.SaleOfTheDay.Domain;
using Nop.Core.Data;

namespace Nop.Plugin.Widgets.SaleOfTheDay.Services
{
    public class TheSaleOfTheDayApplyProductsService : ITheSaleOfTheDayApplyProductsService
    {
        private readonly IRepository<TheSaleOfTheDay_ApplyToProductsRecord> _saleofthedayRecordRepository;

        public TheSaleOfTheDayApplyProductsService(IRepository<TheSaleOfTheDay_ApplyToProductsRecord> saleofthedayRecordRepository)
        {
            _saleofthedayRecordRepository = saleofthedayRecordRepository;
        }
        public IList<TheSaleOfTheDay_ApplyToProductsRecord> GetAppliedProducts(int saleId)
        {
            return _saleofthedayRecordRepository.Table.Where(x => x.TheSaleOfTheDayId == saleId).ToList();
        }
    }
}
