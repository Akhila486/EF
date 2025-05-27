namespace PharmaProject.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
    }
}
