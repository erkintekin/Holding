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
    public class PayrollManager : IPayrollService
    {
        private readonly IRepository<Payroll> _PayrollRepository;
        public PayrollManager(IRepository<Payroll> PayrollRepository)
        {
            _PayrollRepository = PayrollRepository;
        }
        public void CreatePayroll(Payroll Payroll)
        {
            _PayrollRepository.Create(Payroll);
        }

        public async Task<List<Payroll>>? GetAllPayrolls() => await _PayrollRepository.List.ToListAsync();
        public async Task<Payroll>? GetPayrollById(int id) => await _PayrollRepository.List.FirstOrDefaultAsync(s => s.PayrollID == id);
        public void RemovePayroll(Payroll Payroll)
        {
            _PayrollRepository.Delete(Payroll);
        }
        public void UpdatePayroll(Payroll Payroll)
        {
            _PayrollRepository.Update(Payroll);
        }
    }
}
