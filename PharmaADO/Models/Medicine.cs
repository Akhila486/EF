namespace PharmaADO.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string? Manufacturer { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime ManufacturingDate { get; set; }

       // public List<Customer> Customer { get; set; }
        public int CustomerID { get; set; }
    }
}
