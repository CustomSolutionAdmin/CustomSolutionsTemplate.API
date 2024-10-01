using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomSolutionsTemplate.BusinessServices.Interfaces;
using CustomSolutionsTemplate.BusinessServices.ViewModels;

namespace CustomSolutionsTemplate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // Example action method
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        // Add customer
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerViewModel customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            customer.Id = (await _customerService.AddCustomer(customer)).ToString();
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }

        // Edit customer
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCustomer(string id, [FromBody] CustomerViewModel customer)
        {
            if (customer == null || customer.Id != id)
            {
                return BadRequest();
            }

            await _customerService.EditCustomer(customer);
            return NoContent();
        }

        // Delete customer
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            await _customerService.DeleteCustomer(id);
            return NoContent();
        }
    }
}
