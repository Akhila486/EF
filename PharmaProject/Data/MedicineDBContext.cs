using Microsoft.EntityFrameworkCore;
using PharmaProject.Models;

namespace PharmaProject.Data
{
    public class MedicineDBContext : DbContext
    {
        public MedicineDBContext(DbContextOptions<MedicineDBContext> options)
    : base(options)
        {

        }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
