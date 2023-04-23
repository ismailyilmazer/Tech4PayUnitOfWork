using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech4PayUnitOfWork.Core.Interfaces;
using Tech4PayUnitOfWork.Core.Model;
using Tech4PayUnitOfWork.Services.Interfaces;

namespace Tech4PayUnitOfWork.Services
{
    public class CustomerService : ICustomerService
    {

        public IUnitOfWork _unitOfWork;


        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateCustomer(Customer customer)
        {

            if (customer != null)
            {
                await _unitOfWork.CustomerRepository.Add(customer);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public async Task<bool> DeleteCustomer(long Id)
        {
            if (Id > 0)
            {
                var customer = await _unitOfWork.CustomerRepository.GetById( Id);
                if (customer != null)
                {
                    _unitOfWork.CustomerRepository.Delete(customer);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }


        public async Task<Customer> GetCustomerById(long Id)
        {
            if (Id > 0)
            {
                var customer = await _unitOfWork.CustomerRepository.GetById(Id);
                if ( customer != null)
                {
                    return customer;
                }
            }
            return null;
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            if (customer != null)
            {
                var customer_u = await _unitOfWork.CustomerRepository.GetById(customer.Id);
                if (customer_u != null)
                {
                    customer_u.FirstName = customer.FirstName;
                    customer_u.Surname = customer.Surname;
                    customer_u.PhoneNumber = customer.PhoneNumber;
                    customer_u.UpdateDate = DateTime.Now;

                    _unitOfWork.CustomerRepository.Update(customer_u);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

     
    }
}