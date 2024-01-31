using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }  // Müşteri ID'si  
        public string? CustomerName { get; set; }  // Müşteri adı  
        public ICollection<Project>? Projects { get; set; } // 1 müşteri bizden 1'den fazla proje almış olabilir

    }
}
