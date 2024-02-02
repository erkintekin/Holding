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
<<<<<<< HEAD
        void CreateProject(Project Project);
        Task<List<Project>> GetAllProjects();
        Task<Project> GetProjectById(int id);
        void UpdateProject(Project Project);
        void RemoveProject(Project Project);

=======
        void CreateProject(Project project);
        Task<List<Project>> GetAllProjects();
        Task<Project> GetProjectById(int id);
        void UpdateProject(Project project);
        void RemoveProject(Project project);
>>>>>>> 21d2f011126ba6a75584e3b7181e2075de6c8aa7
    }
}
