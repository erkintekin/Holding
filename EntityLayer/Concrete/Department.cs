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
<<<<<<< HEAD
        public int? DepartmentID { get; set; } // Departman ID'si  
        public string? DepartmentName { get; set; }  // Departman adı  
=======
        public int? DepartmentID { get; set; } // Departman ID'si
        public string? DepartmentName { get; set; }  // Departman adı
>>>>>>> bc03dcdd4fb55b6100b6d9aa94ebb36a0a8848f3
        public int? HeadCount { get; set; }   // Toplam işçi sayısı
        public int? Quota { get; set; }       // Toplam kontenjan
        public string? DepartmentInfo { get; set; }   // Departman açıklaması
        public ICollection<Employee>? Employees { get; set; }
    }
}
