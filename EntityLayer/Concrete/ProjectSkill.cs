using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProjectSkill
    {
        public int ProjectID { get; set; }
        public Project? Project { get; set; }

        public int SkillID { get; set; }
        public Skill? Skill { get; set; }
    }
}
