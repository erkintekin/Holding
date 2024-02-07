using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProjectSkill
    {
        [Key]
        public int ProjectSkillID { get; set; }
        public int ProjectID { get; set; }
        public Project? Project { get; set; }

        public int SkillID { get; set; }
        public Skill? Skill { get; set; }
    }
}
