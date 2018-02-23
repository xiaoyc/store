using Nop.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Plugin.Widgets.SaleOfTheDay.Services;
using Nop.Web.Framework.Infrastructure;
using Nop.Plugin.Widgets.SaleOfTheDay.Data;
using Nop.Data;
using Nop.Core.Data;
using Autofac.Core;
using Nop.Plugin.Widgets.SaleOfTheDay.Domain;

namespace Nop.Plugin.Widgets.SaleOfTheDay
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        private const string CONTEXT_NAME = "nop_object_context_the_sale_of_the_day";

        public int Order { get { return 1; } }

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<TheSaleOfTheDayService>().As<ITheSaleOfTheDayService>().InstancePerLifetimeScope();
            builder.RegisterType<TheSaleOfTheDayApplyProductsService>().As<ITheSaleOfTheDayApplyProductsService>().InstancePerLifetimeScope();

            this.RegisterPluginDataContext<TheSaleOfTheDayRecordObjectContext>(builder, CONTEXT_NAME);

            //override required repository with our custom context
            builder.RegisterType<EfRepository<TheSaleOfTheDayRecord>>()
                .As<IRepository<TheSaleOfTheDayRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            //override required repository with our custom context
            builder.RegisterType<EfRepository<TheSaleOfTheDay_ApplyToProductsRecord>>()
                .As<IRepository<TheSaleOfTheDay_ApplyToProductsRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();
        }
    }
}
