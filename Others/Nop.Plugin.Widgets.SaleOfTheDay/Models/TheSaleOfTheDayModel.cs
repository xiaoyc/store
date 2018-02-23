using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Mvc.ModelBinding;
using System;
using Nop.Core.Domain.Catalog;
using Nop.Web.Models.Catalog;

namespace Nop.Plugin.Widgets.SaleOfTheDay.Models
{
    public class TheSaleOfTheDayModel
    {
        public TheSaleOfTheDayModel()
        {
            
        }

        public string Name { get; set; }
        public DateTime? ScheduleStart { get; set; }
        public DateTime? ScheduleEnd { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public IEnumerable<ProductOverviewModel> AppliedProducts { get; set; }
    }
}