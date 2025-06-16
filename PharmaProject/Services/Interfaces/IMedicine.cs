using Microsoft.EntityFrameworkCore;
using PharmaProject.Models;

namespace PharmaProject.Services.Interfaces
{
    public interface IMedicine
    {
        List<Medicine> GetMedicines();
        Medicine GetMedicineById(int id);

        Response CreateMedicine(Medicine NewMedicine);
        Response DeleteMedicine(int id);

    }
}
