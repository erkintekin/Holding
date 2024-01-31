using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        public int? ProjectNo { get; set; }  // Proje numarası
        public string? ProjectName { get; set; }  // Proje adı
        public double? Price { get; set; }  // Proje tutarı
        public int? Duration { get; set; }  // Proje süresi - Çalışanın timesheet'ine atanmalı
        public string? Proficiencies { get; set; }  // Projenin istediği yeterlilikler
        public ICollection<Employee>? Employees { get; set; }  // Bir projede 1'den fazla çalışan olabilir.
        public int CompanyID { get; set; }  // Bir proje sadece 1 şirkete ait olabilir (her iştirak farklı konseptte olmalı)
        public Company? Company { get; set; }
    }
}
