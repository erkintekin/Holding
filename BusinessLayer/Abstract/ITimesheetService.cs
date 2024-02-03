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
        void CreateTimeSheet(Timesheet TimeSheet);
        Task<List<Timesheet>> GetAllTimeSheets();
        Task<Timesheet> GetTimeSheetById(int id);
        void UpdateTimeSheet(Timesheet TimeSheet);
        void RemoveTimeSheet(Timesheet TimeSheet);
    }
}
