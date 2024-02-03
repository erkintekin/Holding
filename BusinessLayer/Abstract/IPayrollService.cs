using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPayrollService
    {
        void CreatePayroll(Payroll Payroll);
        Task<List<Payroll>> GetAllPayrolls();
        Task<Payroll> GetPayrollById(int id);
        void UpdatePayroll(Payroll Payroll);
        void RemovePayroll(Payroll Payroll);

    }
}
