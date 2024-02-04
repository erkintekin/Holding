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
        void CreateCustomer(Customer customer);
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        void UpdateCustomer(Customer customer);
        void RemoveCustomer(Customer customer);
    }
}
