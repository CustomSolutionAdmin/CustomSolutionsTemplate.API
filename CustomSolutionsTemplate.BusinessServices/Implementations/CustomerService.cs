using CustomSolutionsTemplate.BusinessServices.Interfaces;
using CustomSolutionsTemplate.BusinessServices.ViewModels;
using CustomSolutionsTemplate.DataAccess;
using CustomSolutionsTemplate.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSolutionsTemplate.BusinessServices.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomSolutionsTemplateDbContext _context;

        public CustomerService(CustomSolutionsTemplateDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAllCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers.Select(c => new CustomerViewModel
            {
                Id = c.Id.ToString(),
                CustomerName = c.CustomerName,
                CustomerAddress = c.CustomerAddress,
                CustomerEmail = c.CustomerEmail,
                CustomerPhone = c.CustomerPhone
            });
        }

        public async Task<Guid> AddCustomer(CustomerViewModel customer)
        {
            var newCustomer = new Customer
            {                
                CustomerName = customer.CustomerName,
                CustomerAddress = customer.CustomerAddress,
                CustomerEmail = customer.CustomerEmail,
                CustomerPhone = customer.CustomerPhone
            };
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            return newCustomer.Id;
        }

        public async Task EditCustomer(CustomerViewModel customer)
        {
            var existingCustomer = await _context.Customers.FirstOrDefaultAsync(_ => _.Id == new Guid(customer.Id));
            if (existingCustomer != null)
            {
                existingCustomer.CustomerName = customer.CustomerName;
                existingCustomer.CustomerAddress = customer.CustomerAddress;
                existingCustomer.CustomerEmail = customer.CustomerEmail;
                existingCustomer.CustomerPhone = customer.CustomerPhone;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCustomer(string customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(_ => _.Id == new Guid(customerId));
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
