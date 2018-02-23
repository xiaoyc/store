using Nop.Core;
using Nop.Core.Plugins;
using Nop.Plugin.Widgets.SaleOfTheDay.Data;
using Nop.Services.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.SaleOfTheDay
{
    public class TheSaleOfTheDayPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly TheSaleOfTheDayRecordObjectContext _context;

        private readonly IWebHelper _webHelper;
        public TheSaleOfTheDayPlugin(TheSaleOfTheDayRecordObjectContext context, IWebHelper webHelper)
        {
            _context = context;
            this._webHelper = webHelper;
        }

        public void GetPublicViewComponent(string widgetZone, out string viewComponentName)
        {
            viewComponentName = "WidgetsSaleOfTheDay";
        }

        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsSaleOfTheDay/Configure";
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string> { "home_page_top" };
        }

        public override void Install()
        {
            _context.Install();
            base.Install();
        }

        public override void Uninstall()
        {
            _context.Uninstall();
            base.Uninstall();
        }

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsSaleOfTheDay";
        }
    }
}
