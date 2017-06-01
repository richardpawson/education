using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesOrder.Model
{
    public class Order
    {
        public virtual int Id { get; set; }

        public virtual DateTime OrderDate { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Address ShippingAddress { get; set; }

        public virtual Address BillingAddress { get; set; }

        public virtual List<OrderLine> Details { get; set; } = new List<OrderLine>();

        public virtual int TotalValue { get; set; }
    }
}