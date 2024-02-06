using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Department
    {
        [Key]
        public int? DepartmentID { get; set; } // Departman ID'si  
        public string? DepartmentName { get; set; }  // Departman adı  
        public int? HeadCount { get; set; }   // Toplam işçi sayısı
        public int? Quota { get; set; }       // Toplam kontenjan
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<CompanyDepartment>? CompanyDepartments { get; set; } // Ara tablo

        //public string? DepartmentInfo { get; set; }   // Departman açıklaması
    }
}
