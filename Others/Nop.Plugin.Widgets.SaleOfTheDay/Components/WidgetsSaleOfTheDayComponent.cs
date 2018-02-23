using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Catalog;
using Nop.Plugin.Widgets.SaleOfTheDay.Services;
using Nop.Services.Catalog;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.SaleOfTheDay.Components
{
    [ViewComponent(Name = "WidgetsSaleOfTheDay")]
    public class WidgetsSaleOfTheDayComponent : NopViewComponent
    {
        private readonly ITheSaleOfTheDayService _theSaleOfTheDayService;
        private readonly ITheSaleOfTheDayApplyProductsService _theSaleOfTheDayApplyProductsService;
        private readonly IProductService _productService;
        private readonly IAclService _aclService;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IProductModelFactory _productModelFactory;

        public WidgetsSaleOfTheDayComponent(ITheSaleOfTheDayService theSaleOfTheDayService,
            IProductModelFactory productModelFactory,
            IProductService productService,
            IAclService aclService,
             IStoreMappingService storeMappingService,
            ITheSaleOfTheDayApplyProductsService theSaleOfTheDayApplyProductsService)
        {
            _theSaleOfTheDayApplyProductsService = theSaleOfTheDayApplyProductsService;
            _theSaleOfTheDayService = theSaleOfTheDayService;
            _aclService = aclService;
            _productService = productService;
            _storeMappingService = storeMappingService;
            _productModelFactory = productModelFactory;
        }
        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var model = new SaleOfTheDay.Models.TheSaleOfTheDayModel();

            var day = _theSaleOfTheDayService.GetTheSaleOfTheDay();
            var appliedProducts = _theSaleOfTheDayApplyProductsService.GetAppliedProducts(day.Id);

            model.Name = day.Name;
            model.ScheduleStart = day.ScheduleStart;
            model.ScheduleEnd = day.ScheduleEnd;
            model.StartTime = day.StartTime;
            model.EndTime = day.EndTime;

            //load products
            var products = _productService.GetProductsByIds(appliedProducts.Select(x => x.ProductId).ToArray());
            //ACL and store mapping
            products = products.Where(p => _aclService.Authorize(p) && _storeMappingService.Authorize(p)).ToList();
            //availability dates
            products = products.Where(p => p.IsAvailable()).ToList();

            if (!products.Any())
                return Content("");

            //prepare model
            model.AppliedProducts = _productModelFactory.PrepareProductOverviewModels(products, true, true, null).ToList();


            return View("~/Plugins/Widgets.SaleOfTheDay/Views/PublicInfo.cshtml", model);
        }
    }
}
