using PharmaProject.Models;

namespace PharmaProject.Services.Interfaces
{
    public interface IMedicine
    {
        List<Medicine> GetMedicines();
        Medicine GetMedicineById(int id);
    }
}
