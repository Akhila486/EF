namespace PharmaProject.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string? Manufacturer { get; set; } = string.Empty;
        public DateTime ExpiredDate { get; set; }
        public DateTime ManufacturingDate { get; set; }
        
        public Customer Customer { get; set; }
        public int CustomerID { get; set; }
    }
}
