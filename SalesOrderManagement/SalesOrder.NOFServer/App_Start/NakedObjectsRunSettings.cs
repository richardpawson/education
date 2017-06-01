using System;
using NakedObjects.Architecture.Menu;
using NakedObjects.Core.Configuration;
using NakedObjects.Menu;
using NakedObjects.Persistor.Entity.Configuration;
using SalesOrder.Services;
using SalesOrder.Database;
using SalesOrder.SeedData;

namespace NakedObjects.Template {
    public class NakedObjectsRunSettings
    {
        public static string RestRoot
        {
            get { return "rest"; }
        }

        private static string[] ModelNamespaces
        {
            get
            {
                return new string[] { "SalesOrder" }; 
            }
        }

        private static Type[] Types
        {
            get
            {
                return new Type[] { };
            }
        }

        private static Type[] Services
        {
            get
            {
                return new Type[] {
                    typeof(CustomerRepository),
                    typeof(OrderRepository),
                    typeof(ProductRepository)
                };
            }
        }

        public static ReflectorConfiguration ReflectorConfig()
        {
            return new ReflectorConfiguration(Types, Services, ModelNamespaces, MainMenus);
        }

        public static EntityObjectStoreConfiguration EntityObjectStoreConfig()
        {
            var config = new EntityObjectStoreConfiguration();
            var context = new SalesOrderDbContext("SalesOrders");
            config.UsingCodeFirstContext(() => context);
            SalesOrderDbInitilializer.Seed(context);
            return config;
        }

        public static IMenu[] MainMenus(IMenuFactory factory)
        {
            return new IMenu[] {
                factory.NewMenu<CustomerRepository>(true, "Customers"),
                factory.NewMenu<OrderRepository>(true, "Orders"),
                factory.NewMenu<ProductRepository>(true, "Products")
            };
        }
    }
}