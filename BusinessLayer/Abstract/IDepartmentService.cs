using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDepartmentService
    {
        void CreateDepartment(Department department);
        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
        void UpdateDepartment(Department department);
        void RemoveDepartment(Department department);
    }
}
