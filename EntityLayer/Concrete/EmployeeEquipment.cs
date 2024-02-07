using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class EmployeeEquipment
    {
        [Key]
        public int EmployeeEquipmentID { get; set; }
        public int EquipmentID { get; set; }
        public Equipment? Equipment { get; set; }
        public int EmployeeID { get; set; }
        public Employee? Employee { get; set; }
    }
}
