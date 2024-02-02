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
<<<<<<< HEAD
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
=======
        private readonly IRepository<Payroll> _payrollRepository;
        public PayrollManager(IRepository<Payroll> payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }
        public void CreatePayroll(Payroll payroll)
        {
            _payrollRepository.Create(payroll);
        }

        public async Task<List<Payroll>> GetAllPayrolls() => await _payrollRepository.List.ToListAsync();
        public async Task<Payroll> GetPayrollById(int id) => await _payrollRepository.List.FirstOrDefaultAsync(s => s.PayrollID == id);
        public void RemovePayroll(Payroll payroll)
        {
            _payrollRepository.Delete(payroll);
        }
        public void UpdatePayroll(Payroll payroll)
        {
            _payrollRepository.Update(payroll);
>>>>>>> 21d2f011126ba6a75584e3b7181e2075de6c8aa7
        }
    }
}
