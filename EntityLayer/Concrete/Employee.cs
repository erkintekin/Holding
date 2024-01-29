namespace EntityLayer.Concrete
{
    public class Employee
    {
        public int? EmployeeID { get; set; }  // Çalışan ID'si  
        public string? TCKN { get; set; }  // Çalışan TC Kimlik No.su  
        public int? RegNo { get; set; }  // Çalışan sicil no.  
        public string? Name { get; set; }  // Çalışan ismi
        public string? Surname { get; set; }  // Çalışan soyadı
        public string? Mail { get; set; }  // Çalışan maili
        public string? Address { get; set; }  // Çalışan adresi
        public string? Phone { get; set; }  // Çalışan telefon numarası
        public string? Title { get; set; }  // Çalışan ünvanı
        public double? Wage { get; set; }  // Çalışan maaşı (aylık)
        public DateTime? StartDate { get; set; }  // Çalışan işe başlangıç günü
        public DateTime? Birthday { get; } // Çalışan doğum günü  
        public string? Image { get; set; }  // Çalışan fotoğrafı
        public int? DepartmentID { get; set; }  // Çalışana ait departman numarası - Unique
        public Department? Department { get; set; }
        public int? CompanyID { get; set; }  // Çalışana ait şirket-iştirak numarası - Unique
        public Company? Company { get; set; }
        public ICollection<Project>? Projects { get; set; } // Bir çalışan 1'den fazla projede çalışabilir
        public ICollection<Skill>? Skills { get; set; }  // Bir çalışanın 1'den fazla yeteneği olabilir
        public ICollection<Payroll>? Payrolls { get; set; } // Bir çalışanın 1'den fazla bordrosu olabilir (1 aydan eski çalışan ise)
        public ICollection<Timesheet>? Timesheets { get; set; } // Bir çalışanın 1'den fazla zaman çizelgesi olabilir (1 haftadan eski çalışan ise)

        //public int ProjectID { get; set; } 
        //public Project Project { get; set; }
        //public int? SkillID { get; set; }
        //public Skill? Skill { get; set; }
        //public int? PayrollID { get; set; }
        //public Payroll? Payroll { get; set; }

    }
}
