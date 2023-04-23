using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech4PayUnitOfWork.Core.Model;

namespace Tech4PayUnitOfWork.InfraStructure
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {

        }
    
        public DbSet<Customer> Customer { get; set; }


    }
}
