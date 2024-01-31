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
        public int? CompanyID { get; set; }  // Şirket-İştirak ID'si  
        public string? CompanyName { get; set; }  // Şirket-İştirak adı 
        public ICollection<Project>? Projects { get; set; }  // 1 şirkette birden fazla proje olabilir
    }
}
