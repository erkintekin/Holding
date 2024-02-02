using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICompanyService
    {
<<<<<<< HEAD
        void CreateCompany(Company Company);
        Task<List<Company>> GetAllCompanies();
        Task<Company> GetCompanyById(int id);
        void UpdateCompany(Company Company);
        void RemoveCompany(Company Company);

=======
        void CreateCompany(Company company);
        Task<List<Company>> GetAllCompanys();
        Task<Company> GetCompanyById(int id);
        void UpdateCompany(Company company);
        void RemoveCompany(Company company);
>>>>>>> 21d2f011126ba6a75584e3b7181e2075de6c8aa7
    }
}
