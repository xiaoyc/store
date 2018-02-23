using Nop.Plugin.Widgets.SaleOfTheDay.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.SaleOfTheDay.Services
{
    public interface ITheSaleOfTheDayService
    {
        TheSaleOfTheDayRecord GetTheSaleOfTheDay();
    }
}
