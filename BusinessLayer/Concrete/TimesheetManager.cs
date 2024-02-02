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
        }
    }
}
