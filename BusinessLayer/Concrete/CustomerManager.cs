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
        }
    }
}
