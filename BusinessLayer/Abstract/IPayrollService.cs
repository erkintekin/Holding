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
<<<<<<< HEAD
        void CreatePayroll(Payroll Payroll);
        Task<List<Payroll>> GetAllPayrolls();
        Task<Payroll> GetPayrollById(int id);
        void UpdatePayroll(Payroll Payroll);
        void RemovePayroll(Payroll Payroll);

=======
        void CreatePayroll(Payroll payroll);
        Task<List<Payroll>> GetAllPayrolls();
        Task<Payroll> GetPayrollById(int id);
        void UpdatePayroll(Payroll payroll);
        void RemovePayroll(Payroll payroll);
>>>>>>> 21d2f011126ba6a75584e3b7181e2075de6c8aa7
    }
}
