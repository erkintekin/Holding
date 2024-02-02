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
        void CreateCompany(Company company);
        Task<List<Company>> GetAllCompanys();
        Task<Company> GetCompanyById(int id);
        void UpdateCompany(Company company);
        void RemoveCompany(Company company);
    }
}
