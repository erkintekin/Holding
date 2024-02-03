using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICustomerService
    {

        void CreateCustomer(Customer Customer);
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        void UpdateCustomer(Customer Customer);
        void RemoveCustomer(Customer Customer);

    }
}
