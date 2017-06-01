using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Services
{
    public class GenericRepository<T> where T : class, new()
    {
        #region Injected Services
        public IDomainObjectContainer Container { set; protected get; }
        #endregion

        public IQueryable<T> ListAll()
        {
            return Container.Instances<T>();
        }

        public T CreateNew()
        {
            return Container.NewTransientInstance<T>();
        }
    }
}
