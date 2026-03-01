namespace StoreMate.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int OrderCount { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public string? Status { get; set; }
    }
}
