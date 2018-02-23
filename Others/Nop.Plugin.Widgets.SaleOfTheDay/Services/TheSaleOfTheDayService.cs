using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.SaleOfTheDay.Domain;
using Nop.Core.Data;

namespace Nop.Plugin.Widgets.SaleOfTheDay.Services
{
    public class TheSaleOfTheDayService : ITheSaleOfTheDayService
    {
        private readonly IRepository<TheSaleOfTheDayRecord> _saleofthedayRecordRepository;

        public TheSaleOfTheDayService(IRepository<TheSaleOfTheDayRecord> saleofthedayRecordRepository)
        {
            _saleofthedayRecordRepository = saleofthedayRecordRepository;
        }

        public TheSaleOfTheDayRecord GetTheSaleOfTheDay()
        {
            return _saleofthedayRecordRepository.Table.FirstOrDefault();
        }

        /// <summary>
        /// Logs the specified record.
        /// </summary>
        /// <param name="record">The record.</param>
        public void Insert(TheSaleOfTheDayRecord record)
        {
            _saleofthedayRecordRepository.Insert(record);
        }
    }
}
