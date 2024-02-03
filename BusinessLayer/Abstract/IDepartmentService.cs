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
        void CreateDepartment(Department Department);
        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
        void UpdateDepartment(Department Department);
        void RemoveDepartment(Department Department);
    }
}
