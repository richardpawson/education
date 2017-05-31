using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesOrder.Model
{
    public class Order
    {
        //Constructor
        public Order()
        {
            Details = new List<OrderLine>();
        }

        public virtual int Id { get; set; }

        public virtual DateTime OrderDate { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Address ShippingAddress { get; set; }

        public virtual Address BillingAddress { get; set; }

        public virtual List<OrderLine> Details { get; set; }

        public virtual int TotalValue { get; set; }

    }
}