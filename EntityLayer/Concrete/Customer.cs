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
        public int ProjectID { get; set; }
        public ICollection<Project>? Projects { get; set; }
        public ICollection<CompanyCustomer>? CompanyCustomers { get; set; } = new List<CompanyCustomer>();


    }
}
