using System.Collections.Generic;

namespace SalesOrder.Model
{
    public class Customer
    {
        //Constructor
        public Customer()
        {
            Orders = new List<Order>();
        }

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual List<Order> Orders { get; set; }

        public virtual List<Address> Addresses { get; set; }
    }
}