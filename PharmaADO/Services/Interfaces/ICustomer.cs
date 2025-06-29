using PharmaADO.Models;

namespace PharmaADO.Services.Interfaces
{
    public interface ICustomer
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(int id);
    }
}
