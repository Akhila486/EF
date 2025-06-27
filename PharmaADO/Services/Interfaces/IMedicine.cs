using PharmaADO.Models;
namespace PharmaADO.Services.Interfaces
{
    public interface IMedicine
    {
        List<Medicine> GetMedicines();
        Medicine GetMedicineById(int id);
    }
}
