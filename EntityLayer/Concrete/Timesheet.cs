using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Timesheet
    {
        [Key]
        public int? TimesheetID { get; set; }  // Zaman çizelgesi ID'si
        public string? Year { get; set; }  // Zaman çizelgesi yılı
        public string? Month { get; set; }  // Zaman çizelgesi ayı
        public string? Week { get; set; }  // Zaman çizelgesi haftası
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
