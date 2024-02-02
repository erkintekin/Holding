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
<<<<<<< HEAD
        void CreateCustomer(Customer Customer);
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        void UpdateCustomer(Customer Customer);
        void RemoveCustomer(Customer Customer);

=======
        void CreateCustomer(Customer customer);
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        void UpdateCustomer(Customer customer);
        void RemoveCustomer(Customer customer);
>>>>>>> 21d2f011126ba6a75584e3b7181e2075de6c8aa7
    }
}
