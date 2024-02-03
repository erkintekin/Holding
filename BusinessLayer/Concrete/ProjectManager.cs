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
    public class ProjectManager : IProjectService
    {
        private readonly IRepository<Project> _ProjectRepository;
        public ProjectManager(IRepository<Project> ProjectRepository)
        {
            _ProjectRepository = ProjectRepository;
        }
        public void CreateProject(Project Project)
        {
            _ProjectRepository.Create(Project);
        }

        public async Task<List<Project>>? GetAllProjects() => await _ProjectRepository.List.ToListAsync();
        public async Task<Project>? GetProjectById(int id) => await _ProjectRepository.List.FirstOrDefaultAsync(s => s.ProjectID == id);
        public void RemoveProject(Project Project)
        {
            _ProjectRepository.Delete(Project);
        }
        public void UpdateProject(Project Project)
        {
            _ProjectRepository.Update(Project);
        }
    }
}
