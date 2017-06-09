using NakedObjects;
using SalesOrder.Model;
using System.Linq;

namespace SalesOrder.Services
{
    public class CustomerRepository 
    {
        #region Injected Services
        public IDomainObjectContainer Container { set; protected get; }
        #endregion

        public IQueryable<Customer> AllCustomers()
        {
            return Container.Instances<Customer>();
        }

        public Customer CreateNewCustomer()
        {
            return Container.NewTransientInstance< Customer>();
        }
    }
}
