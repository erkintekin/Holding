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
    public class CompanyManager : ICompanyService
    {
<<<<<<< HEAD
        private readonly IRepository<Company> _CompanyRepository;
        public CompanyManager(IRepository<Company> CompanyRepository)
        {
            _CompanyRepository = CompanyRepository;
        }
        public void CreateCompany(Company Company)
        {
            _CompanyRepository.Create(Company);
        }

        public Task<List<Company>> GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Company>>? GetAllCompanys() => await _CompanyRepository.List.ToListAsync();
        public async Task<Company>? GetCompanyById(int id) => await _CompanyRepository.List.FirstOrDefaultAsync(s => s.CompanyID == id);
        public void RemoveCompany(Company Company)
        {
            _CompanyRepository.Delete(Company);
        }
        public void UpdateCompany(Company Company)
        {
            _CompanyRepository.Update(Company);
=======
        private readonly IRepository<Company> _companyRepository;
        public CompanyManager(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public void CreateCompany(Company company)
        {
            _companyRepository.Create(company);
        }

        public async Task<List<Company>> GetAllCompanys() => await _companyRepository.List.ToListAsync();
        public async Task<Company> GetCompanyById(int id) => await _companyRepository.List.FirstOrDefaultAsync(s => s.CompanyID == id);
        public void RemoveCompany(Company company)
        {
            _companyRepository.Delete(company);
        }
        public void UpdateCompany(Company company)
        {
            _companyRepository.Update(company);
>>>>>>> 21d2f011126ba6a75584e3b7181e2075de6c8aa7
        }
    }
}
