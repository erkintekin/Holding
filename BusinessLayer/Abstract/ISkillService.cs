using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISkillService
    {
        void CreateSkill(Skill skill);
        List<Skill> GetAllSkills();
        Skill GetSkillById(int id);
        void UpdateSkill(Skill skill);
        void RemoveSkill(Skill skill);
    }
}
