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
        }
    }
}
