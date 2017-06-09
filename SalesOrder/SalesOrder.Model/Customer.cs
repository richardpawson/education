using System.Collections.Generic;

namespace SalesOrder.Model
{
    public class Customer
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();     

        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}