using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class EmployeeEquipment
    {
        public int EquipmentID { get; set; }
        public Equipment? Equipment { get; set; }   
        public int EmployeeID { get; set; }
        public Employee? Employee { get; set; }
    }
}
