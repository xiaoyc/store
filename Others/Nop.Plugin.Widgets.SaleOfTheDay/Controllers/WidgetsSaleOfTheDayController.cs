using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.SaleOfTheDay.Domain;
using Nop.Plugin.Widgets.SaleOfTheDay.Services;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.SaleOfTheDay.Controllers
{
    [Area(AreaNames.Admin)]
    public class WidgetsSaleOfTheDayController : BasePluginController
    {
        private readonly ITheSaleOfTheDayService _saleOfTheDayService;
        private readonly IPermissionService _permissionService;
        public WidgetsSaleOfTheDayController(ITheSaleOfTheDayService saleOfTheDayService,
              IPermissionService permissionService )
        {
            _saleOfTheDayService = saleOfTheDayService;
            _permissionService = permissionService;
        }
        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            return View("~/Plugins/Widgets.SaleOfTheDay/Views/Configure.cshtml");
        }
            public string Get()
        {
            return "11";
        }

        public IActionResult List()
        {
            IList<TheSaleOfTheDayRecord> records = new List<TheSaleOfTheDayRecord>();

            records.Add(new TheSaleOfTheDayRecord() { StartTime = DateTime.Now, EndTime = DateTime.Now, ScheduleEnd = DateTime.Now, ScheduleStart = DateTime.Now });

            return Json(records);
        }
    }
}
