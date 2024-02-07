using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CompanyCustomer
    {
        [Key]
        public int CompanyCustomerID { get; set; }
        public int CompanyID { get; set; }
        public Company? Company { get; set; }
        public int CustomerID { get; set; }
        public Customer? Customer { get; set; }
    }
}
