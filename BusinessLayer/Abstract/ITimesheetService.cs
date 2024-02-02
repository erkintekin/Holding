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
<<<<<<< HEAD
        void CreateTimeSheet(Timesheet TimeSheet);
        Task<List<Timesheet>> GetAllTimeSheets();
        Task<Timesheet> GetTimeSheetById(int id);
        void UpdateTimeSheet(Timesheet TimeSheet);
        void RemoveTimeSheet(Timesheet TimeSheet);

=======
        void CreateTimesheet(Timesheet timesheet);
        Task<List<Timesheet>> GetAllTimesheets();
        Task<Timesheet> GetTimesheetById(int id);
        void UpdateTimesheet(Timesheet timesheet);
        void RemoveTimesheet(Timesheet timesheet);
>>>>>>> 21d2f011126ba6a75584e3b7181e2075de6c8aa7
    }
}
