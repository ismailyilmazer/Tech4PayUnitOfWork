using Tech4PayUnitOfWork.Core.Interfaces;
using Tech4PayUnitOfWork.Core.Model;

namespace Tech4PayUnitOfWork.InfraStructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContextClass dbContext) : base(dbContext)
        {
        }
    }
}