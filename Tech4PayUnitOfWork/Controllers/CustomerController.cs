using Microsoft.AspNetCore.Mvc;
using Tech4PayUnitOfWork.ComplexType;
using Tech4PayUnitOfWork.Core.Model;
using Tech4PayUnitOfWork.Services.Interfaces;

namespace Tech4PayUnitOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController:ControllerBase
    {
        public readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerRequest createCustomer)
        {

            Customer customer = new Customer
            {
                Email=createCustomer.Email,
                FirstName=createCustomer.FirstName,
                InsertDate=DateTime.Now,
                PhoneNumber=createCustomer.PhoneNumber,
                Surname=createCustomer.Surname,
                RecordStatus="A", 
            };
            var isPCustomerCreated = await _customerService.CreateCustomer(customer);

            if (isPCustomerCreated)
            {
                return Ok(isPCustomerCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCustomer(long Id)
        {
            var isCustomerCreated = await _customerService.DeleteCustomer(Id);

            if (isCustomerCreated)
            {
                return Ok(isCustomerCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCustomerById(long Id)
        {
            var customer= await _customerService.GetCustomerById(Id);

            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Update the product
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody]Customer customer)
        {
            if (customer != null)
            {
                var isCustomerCreated = await _customerService.UpdateCustomer(customer);
                if (isCustomerCreated)
                {
                    return Ok(isCustomerCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
