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
<<<<<<< HEAD
        void CreateDepartment(Department Department);
        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
        void UpdateDepartment(Department Department);
        void RemoveDepartment(Department Department);

=======
        void CreateDepartment(Department department);
        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
        void UpdateDepartment(Department department);
        void RemoveDepartment(Department department);
>>>>>>> 21d2f011126ba6a75584e3b7181e2075de6c8aa7
    }
}
