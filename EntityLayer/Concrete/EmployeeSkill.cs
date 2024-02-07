using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class EmployeeSkill
    {
        [Key]
        public int EmployeeSkillID { get; set; }
        public int EmployeeID { get; set; }
        public Employee? Employee { get; set; }

        public int SkillID { get; set; }
        public Skill? Skill { get; set; }
    }
}
