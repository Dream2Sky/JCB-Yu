using Autofac;
using Autofac.Integration.Mvc;
using com.jiechengbao.bll;
using com.jiechengbao.dal;
using com.jiechengbao.Ibll;
using com.jiechengbao.Idal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace com.jiechengbao.admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            SetupResolveRules(builder);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private void SetupResolveRules(ContainerBuilder builder)
        {
            builder.RegisterType<AddressBLL>().As<IAddressBLL>();
            builder.RegisterType<AddressDAL>().As<IAddressDAL>();
            builder.RegisterType<AdminDAL>().As<IAdminDAL>();
            builder.RegisterType<AdminBLL>().As<IAdminBLL>();
            builder.RegisterType<MemberDAL>().As<IMemberDAL>();
            builder.RegisterType<MemberBLL>().As<IMemberBLL>();
            builder.RegisterType<OrderDAL>().As<IOrderDAL>();
            builder.RegisterType<OrderBLL>().As<IOrderBLL>();
            builder.RegisterType<CategoryBLL>().As<ICategoryBLL>();
            builder.RegisterType<CategoryDAL>().As<ICategoryDAL>();
            builder.RegisterType<GoodsBLL>().As<IGoodsBLL>();
            builder.RegisterType<GoodsDAL>().As<IGoodsDAL>();
            builder.RegisterType<GoodsCategoryDAL>().As<IGoodsCategoryDAL>();
            builder.RegisterType<GoodsCategoryBLL>().As<IGoodsCategoryBLL>();
            builder.RegisterType<GoodsImagesBLL>().As<IGoodsImagesBLL>();
            builder.RegisterType<GoodsImagesDAL>().As<IGoodsImagesDAL>();
            builder.RegisterType<RulesBLL>().As<IRulesBLL>();
            builder.RegisterType<RulesDAL>().As<IRulesDAL>();
            builder.RegisterType<ReCommendBLL>().As<IReCommendBLL>();
            builder.RegisterType<ReCommendDAL>().As<IReCommendDAL>();
            builder.RegisterType<CarBLL>().As<ICarBLL>();
            builder.RegisterType<CarDAL>().As<ICarDAL>();
            builder.RegisterType<RechargeDAL>().As<IRechargeDAL>();
            builder.RegisterType<CreditRecordBLL>().As<ICreditRecordBLL>();
            builder.RegisterType<CreditRecordDAL>().As<ICreditRecordDAL>();
            builder.RegisterType<ServiceBLL>().As<IServiceBLL>();
            builder.RegisterType<ServiceDAL>().As<IServiceDAL>();
            builder.RegisterType<ServiceConsumePasswordBLL>().As<IServiceConsumePasswordBLL>();
            builder.RegisterType<ServiceConsumePasswordDAL>().As<IServiceConsumePasswordDAL>();
            builder.RegisterType<ServiceConsumeRecordBLL>().As<IServiceConsumeRecordBLL>();
            builder.RegisterType<ServiceConsumeRecordDAL>().As<IServiceConsumeRecordDAL>();
            builder.RegisterType<ServiceQRBLL>().As<IServiceQRBLL>();
            builder.RegisterType<ServiceQRDAL>().As<IServiceQRDAL>();
            builder.RegisterType<ExchangeServiceBLL>().As<IExchangeServiceBLL>();
            builder.RegisterType<ExchangeServiceDAL>().As<IExchangeServiceDAL>();
            builder.RegisterType<ExchangeServiceRecordBLL>().As<IExchangeServiceRecordBLL>();
            builder.RegisterType<ExchangeServiceRecordDAL>().As<IExchangeServiceRecordDAL>();
            builder.RegisterType<ExchangeServiceQRBLL>().As<IExchangeServiceQRBLL>();
            builder.RegisterType<ExchangeServiceQRDAL>().As<IExchangeServiceQRDAL>();
            builder.RegisterType<OrderStatusBLL>().As<IOrderStatusBLL>();
            builder.RegisterType<OrderStatusDAL>().As<IOrderStatusDAL>();
        }
    }
}
