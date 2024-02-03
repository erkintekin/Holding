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
    public class EmployeeManager : IEmployeeService
    {
        private readonly IRepository<Employee> _EmployeeRepository;
        public EmployeeManager(IRepository<Employee> EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }
        public void CreateEmployee(Employee Employee)
        {
            _EmployeeRepository.Create(Employee);
        }

        public async Task<List<Employee>>? GetAllEmployees() => await _EmployeeRepository.List.ToListAsync();
        public async Task<Employee>? GetEmployeeById(int id) => await _EmployeeRepository.List.FirstOrDefaultAsync(s => s.EmployeeID == id);
        public void RemoveEmployee(Employee Employee)
        {
            _EmployeeRepository.Delete(Employee);
        }
        public void UpdateEmployee(Employee Employee)
        {
            _EmployeeRepository.Update(Employee);
        }
    }
}
