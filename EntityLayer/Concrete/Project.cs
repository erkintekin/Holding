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
        public int CustomerID { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<ProjectSkill>? ProjectSkills { get; set; } = new List<ProjectSkill>(); // Ara tablo
        public ICollection<CompanyProject>? CompanyProjects { get; set; } = new List<CompanyProject>(); // Ara tablo
        public ICollection<EmployeeProject>? EmployeeProjects { get; set; } = new List<EmployeeProject>(); // Ara tablo



    }
}
