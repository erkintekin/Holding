using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IEmployeeService
    {
        void CreateEmployee(Employee employee);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        void UpdateEmployee(Employee employee);
        void RemoveEmployee(Employee employee);
    }
}
