using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class EmployeeSkill
    {
        public int EmployeeID { get; set; }
        public Employee? Employee { get; set; }

        public int SkillID { get; set; }
        public Skill? Skill { get; set; }
    }
}
