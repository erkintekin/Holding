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
<<<<<<< HEAD
        private readonly IRepository<Department> _DepartmentRepository;
        public DepartmentManager(IRepository<Department> DepartmentRepository)
        {
            _DepartmentRepository = DepartmentRepository;
        }
        public void CreateDepartment(Department Department)
        {
            _DepartmentRepository.Create(Department);
        }

        public async Task<List<Department>>? GetAllDepartments() => await _DepartmentRepository.List.ToListAsync();
        public async Task<Department>? GetDepartmentById(int id) => await _DepartmentRepository.List.FirstOrDefaultAsync(s => s.DepartmentID == id);
        public void RemoveDepartment(Department Department)
        {
            _DepartmentRepository.Delete(Department);
        }
        public void UpdateDepartment(Department Department)
        {
            _DepartmentRepository.Update(Department);
=======
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
>>>>>>> 21d2f011126ba6a75584e3b7181e2075de6c8aa7
        }
    }
}
