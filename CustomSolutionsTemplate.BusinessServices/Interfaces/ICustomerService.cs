using CustomSolutionsTemplate.BusinessServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSolutionsTemplate.BusinessServices.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerViewModel>> GetAllCustomers();
        Task<Guid> AddCustomer(CustomerViewModel customer);
        Task EditCustomer(CustomerViewModel customer);
        Task DeleteCustomer(string customerId);
    }
}
