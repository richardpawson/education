using NakedObjects;
using SalesOrder.Model;
using System.Linq;

namespace SalesOrder.Model
{
    public class ProductRepository
    {
        #region Injected Services
        public IDomainObjectContainer Container { set; protected get; }
        #endregion

        public IQueryable<Product> AllProducts()
        {
            return Container.Instances<Product>();
        }

        public Product CreateNewProduct()
        {
            return Container.NewTransientInstance<Product>();
        }

    }
}
