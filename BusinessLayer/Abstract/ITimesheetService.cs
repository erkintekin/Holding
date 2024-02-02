using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITimesheetService
    {
        void CreateTimesheet(Timesheet timesheet);
        Task<List<Timesheet>> GetAllTimesheets();
        Task<Timesheet> GetTimesheetById(int id);
        void UpdateTimesheet(Timesheet timesheet);
        void RemoveTimesheet(Timesheet timesheet);
    }
}
