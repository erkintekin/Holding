using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Timesheet
    {
        public int? TimesheetID { get; set; }  // Zaman çizelgesi ID'si
        public string? Week { get; set; }  // Zaman çizelgesi hafta adı
        public int Monday { get; set; }
        public int Tuesday { get; set; }
        public int Wednesday { get; set; }
        public int Thursday { get; set; }
        public int Friday { get; set; }
        public int Saturday { get; set; }
        public int Sunday { get; set; }
        public int TotalHours { get; set; }  // Toplam saat
        //ICollection<Employee> Employees { get; set; }


    }
}
