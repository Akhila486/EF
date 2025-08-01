namespace PharmaProject.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Medicine> Medicines { get; set; }
    }
}
