using NakedObjects;
using SalesOrder.Model;
using System.Linq;

namespace SalesOrder.Services
{
    public class OrderRepository
    {
        #region Injected Services
        public IDomainObjectContainer Container { set; protected get; }
        #endregion

        public IQueryable<Order> AllOrders()
        {
            return Container.Instances<Order>();
        }

        public Order CreateNewOrder()
        {
            return Container.NewTransientInstance<Order>();
        }
    }
}
