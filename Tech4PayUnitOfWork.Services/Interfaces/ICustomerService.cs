using Tech4PayUnitOfWork.Core.Model;

namespace Tech4PayUnitOfWork.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> CreateCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);

        Task<bool> DeleteCustomer(long Id);
        Task<Customer> GetCustomerById(long Id);
    }
}