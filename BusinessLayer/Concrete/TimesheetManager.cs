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

        }
    }
}
