using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SkillManager : ISkillService
    {
        private readonly IRepository<Skill> _skillRepository;
        public SkillManager(IRepository<Skill> skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public void CreateSkill(Skill skill)
        {
            _skillRepository.Create(skill);
        }
        public Skill GetSkillById(int id) => _skillRepository.List.FirstOrDefault(s => s.SkillID == id);
        public List<Skill> GetAllSkills() => _skillRepository.List.ToList();
        public void RemoveSkill(Skill skill)
        {
            _skillRepository.Delete(skill);
        }
        public void UpdateSkill(Skill skill)
        {
            _skillRepository.Update(skill);
        }
    }
}
