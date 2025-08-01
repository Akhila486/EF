using PharmaADO.Models;
namespace PharmaADO.Services.Interfaces
{
    public interface IMedicine
    {
        List<Medicine> GetMedicines();
        Medicine GetMedicineById(int id);

        string CreateMedicines(Medicine medicine);

        string UpdateMedicines(Medicine medicine);

        String DeleteMedicineById(int id);
    }
}
