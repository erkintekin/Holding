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
        }
    }
}
