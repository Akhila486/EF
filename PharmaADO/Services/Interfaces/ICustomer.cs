using PharmaADO.Models;

namespace PharmaADO.Services.Interfaces
{
    public interface ICustomer
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(int id);

        string CreateCustomers(Customer customer);

        string UpdateCustomers(Customer customer);

        string createCustomerWithMedicine(Customer customer);
    }
}
