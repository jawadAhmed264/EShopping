using EShopping.Controllers;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;
using EShopping.Service.CategoryServices;
using EShopping.Service.SupplierServices;
using EShopping.Service.CountryService;
using EShopping.Service.AttributeService;
using EShopping.Service.BrandServices;
using EShopping.Service.CustomerServices;
using EShopping.Service.FAQService;
using EShopping.Service.OrderService;
using EShopping.Service.Order;
using EShopping.Service.ProductService;
using EShopping.Service.ShipperServices;

namespace EShopping
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterType<ICategoryService,CategoryService>();
            container.RegisterType<ISupplierService, SupplierService>();
            container.RegisterType<ICountryService, CountryService>();
            container.RegisterType<IAttributeService, AttributeService>();
            container.RegisterType<IBrandService, BrandService>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IFAQService, FAQService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IShipperService, ShipperServiceService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}