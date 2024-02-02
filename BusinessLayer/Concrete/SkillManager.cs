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

        public async Task<List<Skill>> GetAllSkills() => await _skillRepository.List.ToListAsync();
        public async Task<Skill> GetSkillById(int id) => await _skillRepository.List.FirstOrDefaultAsync(s => s.SkillID == id);
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
