using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }  // Şirket-İştirak ID'si  
        public string? CompanyName { get; set; }  // Şirket-İştirak adı 
        public ICollection<CompanyProject>? CompanyProjects { get; set; } = new List<CompanyProject>(); // Ara tablo
        public ICollection<Employee>? Employees { get; set; } = new List<Employee>();
        public ICollection<CompanyDepartment>? CompanyDepartments { get; set; } = new List<CompanyDepartment>(); // Ara tablo
        public ICollection<CompanyCustomer>? CompanyCustomers { get; set; } = new List<CompanyCustomer>();

    }
}
