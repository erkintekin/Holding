using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Payroll
    {

        public int? PayrollID { get; set; }  // Bordro numarası
        public string? Month { get; set; }  // Bordro ayı
        public int? BeforeTax { get; set; } //Brüt Maaş
        public int? NetWage { get; set; }  // Total maaş
        public int StampTax { get; set; }  // Damga vergisi
        public int SGKCut { get; set; }  // Sigorta kesintisi
        public int TotalTax { get; set; }  //  Toplam vergi tutarı 
        //public int TotalWorkHours { get; set; }  // Timesheet'ten alacak
        public int VacationHours { get; set; }  // Tatilde geçen saat sayısı
        //public int TotalWorkDays { get; set; }     // Saati güne çevirecek
    }
}
