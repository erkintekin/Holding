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
    public class DepartmentManager : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;
        public DepartmentManager(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public void CreateDepartment(Department department)
        {
            _departmentRepository.Create(department);
        }

        public async Task<List<Department>> GetAllDepartments() => await _departmentRepository.List.ToListAsync();
        public async Task<Department> GetDepartmentById(int id) => await _departmentRepository.List.FirstOrDefaultAsync(s => s.DepartmentID == id);
        public void RemoveDepartment(Department department)
        {
            _departmentRepository.Delete(department);
        }
        public void UpdateDepartment(Department department)
        {
            _departmentRepository.Update(department);
        }
    }
}
