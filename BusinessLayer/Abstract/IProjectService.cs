using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProjectService
    {
        void CreateProject(Project Project);
        Task<List<Project>> GetAllProjects();
        Task<Project> GetProjectById(int id);
        void UpdateProject(Project Project);
        void RemoveProject(Project Project);
    }
}
