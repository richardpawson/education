namespace SalesOrder.Model
{
    public class Address
    {
        public virtual int Id { get; set; }

        public virtual string Line1 { get; set; }

        public virtual string Line2 { get; set; }

        public virtual string PostCode { get; set; }
    }
}