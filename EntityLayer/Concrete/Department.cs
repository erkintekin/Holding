using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Department
    {
        public int? DepartmentID { get; set; } // Departman ID'si  
        public int? DepartmentName { get; set; }  // Departman adı  
        public int? HeadCount { get; set; }   // Toplam işçi sayısı
        public int? Quota { get; set; }       // Toplam kontenjan
        public string? DepartmentInfo { get; set; }   // Departman açıklaması
        public ICollection<Employee> Employees { get; set; }
    }
}
