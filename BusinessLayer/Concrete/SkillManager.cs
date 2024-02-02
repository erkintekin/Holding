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
        private readonly IRepository<Skill> _SkillRepository;

        public SkillManager(IRepository<Skill> skillRepository)
        {
            _SkillRepository = skillRepository;
        }
        public void CreateSkill(Skill skill)
        {
            _SkillRepository.Create(skill);
        }

        public async Task<List<Skill>>? GetAllSkills() => await _SkillRepository.List.ToListAsync();
        public async Task<Skill>? GetSkillById(int id) => await _SkillRepository.List.FirstOrDefaultAsync(s => s.SkillID == id);
        public void RemoveSkill(Skill skill)
        {
            _SkillRepository.Delete(skill);
        }
        public void UpdateSkill(Skill skill)
        {
            _SkillRepository.Update(skill);
        }
    }
}