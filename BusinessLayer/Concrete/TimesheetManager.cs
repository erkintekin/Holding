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
    public class TimesheetManager : ITimesheetService
    {
<<<<<<< HEAD
        private readonly IRepository<Timesheet> _TimeSheetRepository;
        public TimesheetManager(IRepository<Timesheet> TimeSheetRepository)
        {
            _TimeSheetRepository = TimeSheetRepository;
        }
        public void CreateTimeSheet(Timesheet TimeSheet)
        {
            _TimeSheetRepository.Create(TimeSheet);
        }

        public async Task<List<Timesheet>>? GetAllTimeSheets() => await _TimeSheetRepository.List.ToListAsync();
        public async Task<Timesheet>? GetTimeSheetById(int id) => await _TimeSheetRepository.List.FirstOrDefaultAsync(s => s.TimesheetID == id);
        public void RemoveTimeSheet(Timesheet TimeSheet)
        {
            _TimeSheetRepository.Delete(TimeSheet);
        }
        public void UpdateTimeSheet(Timesheet TimeSheet)
        {
            _TimeSheetRepository.Update(TimeSheet);
=======
        private readonly IRepository<Timesheet> _timesheetRepository;
        public TimesheetManager(IRepository<Timesheet> timesheetRepository)
        {
            _timesheetRepository = timesheetRepository;
        }
        public void CreateTimesheet(Timesheet timesheet)
        {
            _timesheetRepository.Create(timesheet);
        }

        public async Task<List<Timesheet>> GetAllTimesheets() => await _timesheetRepository.List.ToListAsync();
        public async Task<Timesheet> GetTimesheetById(int id) => await _timesheetRepository.List.FirstOrDefaultAsync(s => s.TimesheetID == id);
        public void RemoveTimesheet(Timesheet timesheet)
        {
            _timesheetRepository.Delete(timesheet);
        }
        public void UpdateTimesheet(Timesheet timesheet)
        {
            _timesheetRepository.Update(timesheet);
>>>>>>> 21d2f011126ba6a75584e3b7181e2075de6c8aa7
        }
    }
}
