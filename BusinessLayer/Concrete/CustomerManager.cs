using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
<<<<<<< HEAD
        private readonly IRepository<Customer> _CustomerRepository;
        public CustomerManager(IRepository<Customer> CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }
        public void CreateCustomer(Customer Customer)
        {
            _CustomerRepository.Create(Customer);
        }

        public async Task<List<Customer>>? GetAllCustomers() => await _CustomerRepository.List.ToListAsync();
        public async Task<Customer>? GetCustomerById(int id) => await _CustomerRepository.List.FirstOrDefaultAsync(s => s.CustomerID == id);
        public void RemoveCustomer(Customer Customer)
        {
            _CustomerRepository.Delete(Customer);
        }
        public void UpdateCustomer(Customer Customer)
        {
            _CustomerRepository.Update(Customer);
=======
        private readonly IRepository<Customer> _customerRepository;
        public CustomerManager(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void CreateCustomer(Customer customer)
        {
            _customerRepository.Create(customer);
        }

        public async Task<List<Customer>> GetAllCustomers() => await _customerRepository.List.ToListAsync();
        public async Task<Customer> GetCustomerById(int id) => await _customerRepository.List.FirstOrDefaultAsync(s => s.CustomerID == id);
        public void RemoveCustomer(Customer customer)
        {
            _customerRepository.Delete(customer);
        }
        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.Update(customer);
>>>>>>> 21d2f011126ba6a75584e3b7181e2075de6c8aa7
        }
    }
}
