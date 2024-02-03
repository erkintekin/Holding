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
        void CreateCompany(Company Company);
        Task<List<Company>> GetAllCompanies();
        Task<Company> GetCompanyById(int id);
        void UpdateCompany(Company Company);
        void RemoveCompany(Company Company);
    }
}
