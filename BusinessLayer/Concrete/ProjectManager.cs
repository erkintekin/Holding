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
        private readonly IRepository<Project> _projectRepository;
        public ProjectManager(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public void CreateProject(Project project)
        {
            _projectRepository.Create(project);
        }

        public async Task<List<Project>> GetAllProjects() => await _projectRepository.List.ToListAsync();
        public async Task<Project> GetProjectById(int id) => await _projectRepository.List.FirstOrDefaultAsync(s => s.ProjectID == id);
        public void RemoveProject(Project project)
        {
            _projectRepository.Delete(project);
        }
        public void UpdateProject(Project project)
        {
            _projectRepository.Update(project);
        }
    }
}
