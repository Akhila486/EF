namespace PharmaProject.Models
{
    public class ResponseMedicine
    {
            public string? Name { get; set; }
            public double Price { get; set; }
            public DateTime ExpiredDate { get; set; }
            public DateTime ManufacturingDate { get; set; }
            public int CustomerID { get; set; }
            public int Id { get; set; }
    }
}
