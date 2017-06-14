using System;
using NakedObjects.Architecture.Menu;
using NakedObjects.Core.Configuration;
using NakedObjects.Menu;
using NakedObjects.Persistor.Entity.Configuration;
using SalesOrder.DataBase;
using SalesOrder.SeedData;
using SalesOrder.Model;

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
                return new string[] { "SalesOrder", "TechnicalServices" }; 
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
                    typeof(ProductRepository),
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
            config.UsingCodeFirstContext(() => {
                return new SalesOrderDbContext("SalesOrders", new SalesOrderDbInitilializer());
            });
            return config;
        }

        public static IMenu[] MainMenus(IMenuFactory factory)
        {
            return new IMenu[] {
                factory.NewMenu<CustomerRepository>(true, "Customers"),
                factory.NewMenu<OrderRepository>(true, "Orders"),
                factory.NewMenu<ProductRepository>(true, "Products"),
            };
        }
    }
}