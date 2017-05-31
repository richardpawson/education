namespace SalesOrder.Model
{
    public class OrderLine
    {
        public virtual int Id { get; set; }

        public virtual Product Product { get; set; }

        public virtual int Quantity { get; set; }

        public virtual int SubTotal { get; set; }
    }
}