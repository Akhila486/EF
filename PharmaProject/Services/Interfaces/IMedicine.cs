using PharmaProject.Models;

namespace PharmaProject.Services.Interfaces
{
    public interface IMedicine
    {
        Task<IEnumerable<ResponseMedicine>> GetMedicines();
        Medicine GetMedicineById(int id);
    }
}
