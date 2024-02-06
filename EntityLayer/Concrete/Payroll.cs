using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Payroll
    {
        [Key]
        public int? PayrollID { get; set; }  // Bordro numarası
        public int EmployeeID { get; set; } // Hangi çalışana ait olduğunu belirten özellik
        public Employee? Employee { get; set; } // İlişkili çalışan nesnesi
        public string? Month { get; set; }  // Bordro ayı
        public decimal? BeforeTax { get; set; } //Brüt Maaş
        public decimal? NetWage { get; set; }  // Total maaş
        public decimal? StampTax { get; set; }  // Damga vergisi
        public decimal? SGKCut { get; set; }  // Sigorta kesintisi
        public decimal? TotalTax { get; set; }  //  Toplam vergi tutarı 
        //public int TotalWorkHours { get; set; }  // Timesheet'ten alacak
        public int VacationHours { get; set; }  // Tatilde geçen saat sayısı
        //public int TotalWorkDays { get; set; }     // Saati güne çevirecek
      
    }
}
