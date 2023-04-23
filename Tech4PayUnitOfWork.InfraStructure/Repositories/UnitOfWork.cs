using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech4PayUnitOfWork.Core.Interfaces;

namespace Tech4PayUnitOfWork.InfraStructure.Repositories
{
    public partial class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; }
        private readonly DbContextClass _dbContext;

        public UnitOfWork(DbContextClass dbContext,
                           ICustomerRepository customerRepository
                           )
        {
            _dbContext = dbContext;
            CustomerRepository = customerRepository;
            
        }

        public IPersonRepository PersonRepository => throw new NotImplementedException();

        public IProductRepository ProductRepository => throw new NotImplementedException();

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
