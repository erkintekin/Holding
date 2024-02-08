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
        private readonly IRepository<Employee> _employeeRepository;
        public EmployeeManager(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void CreateEmployee(Employee employee)
        {
            _employeeRepository.Create(employee);
        }

        public async Task<List<Employee>> GetAllEmployees() => await _employeeRepository.List.ToListAsync();

        public async Task<Employee> GetEmployeeById(int id) => await _employeeRepository.List.FirstOrDefaultAsync(s => s.EmployeeID == id);
        public void RemoveEmployee(Employee employee)
        {
            _employeeRepository.Delete(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.Update(employee);
        }
    }
}
