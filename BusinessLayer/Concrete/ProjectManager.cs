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
<<<<<<< HEAD
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
=======
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
>>>>>>> 21d2f011126ba6a75584e3b7181e2075de6c8aa7
        }
    }
}
