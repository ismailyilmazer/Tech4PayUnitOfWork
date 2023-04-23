using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech4PayUnitOfWork.Core.Model
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }   
        public int ProductId { get; set; }
        public decimal Price { get; set; }  
        public DateTime CreatedDate { get; set; }
    }
}
