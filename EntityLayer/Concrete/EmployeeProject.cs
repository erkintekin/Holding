using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class EmployeeProject
    {
        [Key]
        public int EmployeeProjectID { get; set; }
        public int EmployeeID { get; set; }
        public Employee? Employee { get; set; }

        public int ProjectID { get; set; }
        public Project? Project { get; set; }
    }
}
